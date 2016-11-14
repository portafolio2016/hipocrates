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
            this.StartPosition = FormStartPosition.CenterScreen;
            //Label de validaciones iniciados invisibles
            lblAdvertenciaUsuario.Visible = false;
            lblAdvertenciaContrasena.Visible = false;
            lblDatosInvalidos.Visible = false;
        }

        #region Botón iniciar sesión
        public static UsuarioLogeado usuarioLogeado = null;
       

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
                 
                usuarioLogeado = Login.iniciarSesion(usuario, password);
                if (usuarioLogeado != null)
                {
                    lblDatosInvalidos.Visible = false;
                    this.Hide();

                    switch (usuarioLogeado.Privilegio.ToUpper())
                    {
                        case "OPERADOR":
                            FrmMain frmMain = new FrmMain(this);
                            frmMain.Show();
                            frmMain.Activate();
                        break;

                        case "JEFE DE OPERADOR":

                        break;

                        case "MEDICO":

                        break;

                        case "ENFERMERO":

                        break;

                        case "TECNOLOGO":

                        break;


                            
                    }

                }
                else
                {
                    lblDatosInvalidos.Visible = true;
                    
                }
               
            }

        }
        #endregion

        #region Campos vacíos
        public void camposVacios()
        {
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            lblDatosInvalidos.Visible = false;
            lblAdvertenciaUsuario.Visible = false;
            lblAdvertenciaContrasena.Visible = false;
        }
        #endregion


    }
}
