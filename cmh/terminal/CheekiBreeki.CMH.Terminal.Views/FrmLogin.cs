using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheekiBreeki.CMH.Terminal.BL;

namespace CheekiBreeki.CMH.Terminal.Views
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            lblAdvertenciaUsuario.Visible = false;
            lblAdvertenciaContrasena.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string usuario = txtUsuario.Text;
            string password = txtContrasena.Text;

            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || !Util.isEmailValido(usuario))
            {
                lblAdvertenciaUsuario.Visible = true;
                lblAdvertenciaUsuario.Text = "Email no valido";
            }
            else
            {
                lblAdvertenciaUsuario.Visible = false;

            }

            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                lblAdvertenciaContrasena.Visible = true;
                lblAdvertenciaContrasena.Text = "Contraseña vacía";
            }
            else
            {
                lblAdvertenciaContrasena.Visible = false;
            }

            if (!string.IsNullOrWhiteSpace(txtUsuario.Text) && !string.IsNullOrWhiteSpace(txtContrasena.Text)
                && Util.isEmailValido(usuario))
            {
                UsuarioLogeado usuarioLogeado = null;
                usuarioLogeado = Login.iniciarSesion(usuario, password);
                if (usuarioLogeado != null)
                {
                    MessageBox.Show(usuarioLogeado.Privilegio);
                }
                else
                {
                    MessageBox.Show("Usuario y contraseña invalidas!");
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblAdvertencia_Click(object sender, EventArgs e)
        {

        }
    }
}
