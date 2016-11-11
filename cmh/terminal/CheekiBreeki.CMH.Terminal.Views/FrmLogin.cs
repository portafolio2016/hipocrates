using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheekiBreeki.CMH.Terminal.Views
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
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
            UsuarioLogeado usuarioLogeado = null;
            usuarioLogeado = Login.iniciarSesion(usuario, password);
            MessageBox.Show(usuarioLogeado.NombreUsuario);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
