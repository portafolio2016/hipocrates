using CheekiBreeki.CMH.Terminal.BL;
using CheekiBreeki.CMH.Terminal.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheekiBreeki.CMH.Terminal.Views
{
    public partial class FrmMedico : Form
    {
        FrmLogin login = null;
        bool closeApp;
        private static AccionesTerminal acciones = new AccionesTerminal();

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   CONSTRUCTOR                                                                                                                //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FrmMedico(FrmLogin fLogin)
        {
            InitializeComponent();
            closeApp = true;
            login = fLogin;
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
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   CERRAR SESION                                                                                                              //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cerrar sesión?", "Cerrar sesión",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                closeApp = false;
                login.camposVacios();
                login.Show();
                this.Close();

            }
            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   OPCIONES DE CUENTA                                                                                                         //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbContrasenaActual.Text.Trim()) && !string.IsNullOrEmpty(tbContrasenaNueva.Text.Trim()))
            {
                if (Util.isObjetoNulo(Login.verificarUsuario(FrmLogin.usuarioLogeado.Personal.EMAIL, tbContrasenaActual.Text)))
                {
                    MessageBox.Show("La contraseña ingresada no es correcta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    PERSONAL personal = Login.verificarUsuario(FrmLogin.usuarioLogeado.Personal.EMAIL, tbContrasenaActual.Text);
                    personal.HASHED_PASS = Util.hashMD5(tbContrasenaNueva.Text.TrimStart().TrimEnd());
                    bool x = acciones.actualizarPersonal(personal);
                    if(x)
                        MessageBox.Show("Contraseña actualizada con exito", "Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    else
                        MessageBox.Show("Error al actualizar contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (string.IsNullOrEmpty(tbContrasenaActual.Text.Trim()) && string.IsNullOrEmpty(tbContrasenaNueva.Text.Trim()))
            {
                MessageBox.Show("Los dos campos estan vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(tbContrasenaActual.Text.Trim()))
            {
                MessageBox.Show("El campo de constraseña actual esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(tbContrasenaNueva.Text.Trim()))
            {
                MessageBox.Show("El campo de constraseña nueva esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCambiarEmail_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbNuevoMail.Text.Trim()) && Util.isEmailValido(tbNuevoMail.Text.Trim()))
            {
                if (MessageBox.Show("¿Seguro que desea cambiar su email?", "Cambiar Email",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    PERSONAL personal = FrmLogin.usuarioLogeado.Personal;
;
                    personal.EMAIL = tbNuevoMail.Text.Trim();
                    bool x = acciones.actualizarPersonal(personal);
                    if(x)
                    {
                        closeApp = false;
                        login.camposVacios();
                        login.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al modificar el email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
            else if (string.IsNullOrEmpty(tbNuevoMail.Text.Trim()))
            {
                MessageBox.Show("Campo de email vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!Util.isEmailValido(tbNuevoMail.Text.Trim()))
            {
                MessageBox.Show("Email invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnModificarUser_Click(object sender, EventArgs e)
        {
            InitGB(gbOpcionesUsuario);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   INIT GB                                                                                                                    //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void InitGB(GroupBox x)
        {
            gbAbrirConsultaMedica.Hide();
            gbCerrarConsultaMedica.Hide();
            gbOpcionesUsuario.Hide();
            //
            //AGREGAR LOS OTROS GB QUE FALTEN
            //
            x.Show();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   AGENDA DIARIA                                                                                                              //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void agendaDiariaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InitGB(gbAgendaDiaria);
            CargarAgendaDiaria();
        }

        private void CargarAgendaDiaria()
        {
            List<ATENCION_AGEN> listaAtenciones = acciones.revisarAgendaDiaria(FrmLogin.usuarioLogeado.Personal.RUT, DateTime.Now);
            List<AgendaDiaria> agendaDiaria = new List<AgendaDiaria>();
            if (listaAtenciones.Count > 0)
            {
                
                foreach (ATENCION_AGEN x in listaAtenciones)
                {
                    bool estado = false;
                    if (x.ESTADO_ATEN.NOM_ESTADO_ATEN == "Cerrado")
                        estado = true;
                    agendaDiaria.Add(new AgendaDiaria(x.PRESTACION.NOM_PRESTACION, x.PACIENTE.NOMBRES_PACIENTE+" "+x.PACIENTE.APELLIDOS_PACIENTE, x.FECHOR.ToString(), estado));
                }
               
            }
            //TEST
            //agendaDiaria.Add(new AgendaDiaria("testttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttts", "testtttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttts", "testtttttttttttttttttttttttttttttttttttttttttttt", true));
            //TEST
            dgAgendaDiaria.DataSource = agendaDiaria;

        }

        private void FrmMedico_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (closeApp)
                Application.Exit();
        }

       

       


    }
}
