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
            lblAdvertencia.Visible = false;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string usuario = string.Empty;
            string password = string.Empty;

            if (!string.IsNullOrWhiteSpace(txtUsuario.Text) && !string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                usuario = txtUsuario.Text;
                password = txtContrasena.Text;
                if (Util.isEmailValido(usuario))
                {
                    UsuarioLogeado usuarioLogeado = null;
                    usuarioLogeado = Login.iniciarSesion(usuario, password);
                    MessageBox.Show(usuarioLogeado.NombreUsuario);
                }
                else
                {
                    lblAdvertencia.Visible = true;
                    lblAdvertencia.Text = "Email no válido";
                }
            }
            else
            {
                lblAdvertencia.Visible = true;
                lblAdvertencia.Text = "Usuario ó contraseña vacía";
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
