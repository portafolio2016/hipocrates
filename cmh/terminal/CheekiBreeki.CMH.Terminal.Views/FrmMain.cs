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
        FrmLogin login = null;
        bool closeApp;

        public FrmMain(FrmLogin padre)
        {
            InitializeComponent();
            closeApp = true;
            this.StartPosition = FormStartPosition.CenterScreen;
                

            if (FrmLogin.usuarioLogeado != null)
            {
                lblUsuarioConectado.Text = "Usuario Conectado: " + FrmLogin.usuarioLogeado.NombreUsuario;
                lblPrivilegio.Text = "Privilegio: " + FrmLogin.usuarioLogeado.Privilegio;
                btnSesion.Text = "Cerrar Sesión";
            }
            else
            {
                lblUsuarioConectado.Text = "Debes iniciar sesión";
                lblPrivilegio.Text = "";
                btnSesion.Text = "Iniciar sesión";
            }

            login = padre;
        }

        private void btnSesion_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("¿Seguro que desea cerrar sesión?", "Cerrar sesión",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
           {
               closeApp = false;
               login.camposVacios();
               login.Show();
               this.Close();
               
           }

        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (closeApp)
                Application.Exit();
        }

        private void btnAgendarAtencion_Click(object sender, EventArgs e)
        {
            FrmAgendarAtencion frmAgendar = new FrmAgendarAtencion(login);
            frmAgendar.Show();
            frmAgendar.Activate();
            this.Hide();
        }

        private void btnCrearPaciente_Click(object sender, EventArgs e)
        {
            FrmCrearPaciente frmCrearPaciente = new FrmCrearPaciente(login);
            frmCrearPaciente.Show();
            frmCrearPaciente.Activate();
            this.Hide();
        }

        private void btnIngresarPaciente_Click(object sender, EventArgs e)
        {
            FrmIngresarPaciente frmIngresarPaciente = new FrmIngresarPaciente(login);
            frmIngresarPaciente.Show();
            frmIngresarPaciente.Activate();
            this.Hide();
        }


    }
}
