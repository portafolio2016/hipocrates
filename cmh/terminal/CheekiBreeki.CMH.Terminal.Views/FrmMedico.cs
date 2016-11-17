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
        private static List<ENTRADA_FICHA> entradaList;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   CONSTRUCTOR                                                                                                                //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FrmMedico(FrmLogin fLogin)
        {
            InitializeComponent();
            closeApp = true;
            entradaList = new List<ENTRADA_FICHA>();
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
            gbAgendaDiaria.Hide();
            gbVerFichaMedica.Hide();
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

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   VER FICHA MEDICA                                                                                                           //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void verFichaMédicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitGB(gbVerFichaMedica);
        }

        private void btnBuscarVFM_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbRUNVFM.Text.Trim()) && !string.IsNullOrEmpty(tbVerificadorVFM.Text.Trim()))
            {
                if (ValidaRut(tbRUNVFM.Text +"-"+ tbVerificadorVFM.Text))
                {
                    PACIENTE paciente = acciones.buscarPaciente(Int32.Parse(tbRUNVFM.Text),tbVerificadorVFM.Text);
                    if (paciente != null)
                    {
                        //Ruta buena
                        lbNombreVFM.Text = "Nombre: "+paciente.NOMBRES_PACIENTE + " " + paciente.APELLIDOS_PACIENTE;
                        lbEmailVFM.Text = "Email: " + paciente.EMAIL_PACIENTE;
                        lbRun.Text = "RUN: " + paciente.RUT + "-" + paciente.DIGITO_VERIFICADOR;
                        lbSexoVFM.Text = "Sexo: " + paciente.SEXO;
                        lbFechaNacVFM.Text = "Fecha nacimiento: " + paciente.FEC_NAC.Value.ToShortDateString();

                        entradaList = new List<ENTRADA_FICHA>(paciente.ENTRADA_FICHA);
                        if (entradaList != null)
                        {
                            foreach (ENTRADA_FICHA aux in entradaList)
                            {
                                dgEntradaVFM.Rows.Add(aux.NOMBRE_ENTRADA, "Ver", aux.FECHA_ENTRADA.ToString());
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Paciente no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Run invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (string.IsNullOrEmpty(tbRUNVFM.Text.Trim()))
            {
                MessageBox.Show("Campo de RUN vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(tbRUNVFM.Text.Trim()))
            {
                MessageBox.Show("Campo de digito verificador vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool ValidaRut(string rut)
        {
            rut = rut.Replace(".", "").ToUpper();
            Regex expresion = new Regex("^([0-9]+-[0-9K])$");
            string dv = rut.Substring(rut.Length - 1, 1);
            if (!expresion.IsMatch(rut))
            {
                return false;
            }
            char[] charCorte = { '-' };
            string[] rutTemp = rut.Split(charCorte);
            if (dv != Digito(int.Parse(rutTemp[0])))
            {
                return false;
            }
            return true;
        }

        public static string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
        }

        private void dgEntradaVFM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >=0)
            {
                FrmContenidoEntrada frmCont = new FrmContenidoEntrada(entradaList[e.RowIndex].CONTENIDO_ENTRADA);
                frmCont.Show();
                frmCont.Activate();
            }
        }

       

       


    }
}
