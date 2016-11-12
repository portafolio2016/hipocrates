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
    public partial class FrmMain : Form
    {

        public FrmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            if (FrmLogin.usuarioLogeado != null)
            {
                lblUsuarioConectado.Text = "Usuario Conectado: " + FrmLogin.usuarioLogeado.NombreUsuario;
                lblPrivilegio.Text = "Privilegio: " + FrmLogin.usuarioLogeado.Privilegio;
                btnSesion.Text = "Cerrar Sesión";
            }
            else
            {
                lblUsuarioConectado.Text = "Inicia sesión";
                lblPrivilegio.Text = "";
                btnSesion.Text = "Iniciar sesión";
            }

        }


        private void btnSesion_Click(object sender, EventArgs e)
        {
            if (FrmLogin.usuarioLogeado != null)
            {
                Login.cerrarSesion(FrmLogin.usuarioLogeado);
                this.Close();
            }
            else
            {
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Activate();
                frmLogin.Show();
            }
            
        }

       

       


    }
}
