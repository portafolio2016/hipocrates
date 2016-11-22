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
            string mensajeError = string.Empty;
            string usuario = txtUsuario.Text;
            string password = txtContrasena.Text;

            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || !Util.isEmailValido(usuario))
                mensajeError = "Email no valido";
            else if (string.IsNullOrWhiteSpace(txtContrasena.Text))
                mensajeError = "Contraseña vacía";

            if (!string.IsNullOrWhiteSpace(txtUsuario.Text) && !string.IsNullOrWhiteSpace(txtContrasena.Text)
                && Util.isEmailValido(usuario))
            {
                usuarioLogeado = Login.iniciarSesion(usuario, password);
                if (usuarioLogeado != null)
                {
                    lblDatosInvalidos.Visible = false;
                    switch (usuarioLogeado.Privilegio.ToUpper())
                    {
                        case "OPERADOR":
                            FrmOperador frmOperador = new FrmOperador(this);
                            frmOperador.Show();
                            frmOperador.Activate();
                            this.Hide();
                            break;

                        case "JEFE DE OPERADOR":
                            FrmJefeOp frmJefeOp = new FrmJefeOp(this);
                            frmJefeOp.Show();
                            frmJefeOp.Activate();
                            this.Hide();
                            break;

                        case "MEDICO":
                            FrmMedico frmMedico = new FrmMedico(this);
                            frmMedico.Show();
                            frmMedico.Activate();
                            this.Hide();
                            break;

                        case "ENFERMERO":
                            FemEnfermero frmEnfermero = new FemEnfermero(this);
                            frmEnfermero.Show();
                            frmEnfermero.Activate();
                            this.Hide();
                            break;

                        case "TECNOLOGO":
                            FrmMain frmMain4 = new FrmMain(this);
                            frmMain4.Show();
                            frmMain4.Activate();
                            this.Hide();
                            break;
                    }
                }
                else
                    mensajeError = "Usuario o contraseña inválido";
            }
            if (mensajeError != string.Empty)
                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
