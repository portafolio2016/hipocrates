using CheekiBreeki.CMH.Terminal.BL;
using CheekiBreeki.CMH.Terminal.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheekiBreeki.CMH.Terminal.Views
{
    public partial class FemEnfermero : Form
    {
        private static AccionesTerminal acciones = new AccionesTerminal();
        private static List<RES_ATENCION> resAtenciones = new List<RES_ATENCION>();
        private static RES_ATENCION resAtencion = null;
        FrmLogin login = null;
        bool closeApp;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   CONSTRUCTOR                                                                                                                //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FemEnfermero(FrmLogin fLogin)
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
        private void btnSesion_Click_1(object sender, EventArgs e)
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
        //   FORM CLOSED                                                                                                                //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void FemEnfermero_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (closeApp)
                Application.Exit();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   OPCIONES DE CUENTA                                                                                                         //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnModificarUser_Click_1(object sender, EventArgs e)
        {
            InitGB(gbOpcionesUsuario);
        }

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
                    if (x)
                    {
                        MessageBox.Show("Contraseña actualizada con exito", "Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        tbContrasenaActual.Text = "";
                        tbContrasenaNueva.Text = "";
                    }
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
                    personal.EMAIL = tbNuevoMail.Text.Trim();
                    bool x = acciones.actualizarPersonal(personal);
                    if (x)
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

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   INIT GB                                                                                                                    //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void InitGB(GroupBox x)
        {
            gbOpcionesUsuario.Hide();
            gbAbrirOrdenAnalisis.Hide();
            gbCerrarOrdenAnalisis.Hide();
            gbMuestrasParaAnalisis.Hide();
            gbAgendaDiaria.Hide();
            //
            //AGREGAR LOS OTROS GB QUE FALTEN
            //
            x.Show();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   ABRIR ORDEN ANALISIS                                                                                                       //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitGB(gbAbrirOrdenAnalisis);
            InitAbrirOrden();
        }

        private void InitAbrirOrden()
        {
            try
            {
                resAtencion = null;
                dgAtencionesAOA.Rows.Clear();
                AccionesTerminal ac = new AccionesTerminal();
                resAtenciones = ac.ResAtencionesAptasParaAnalisis(FrmLogin.usuarioLogeado.Personal.ID_PERSONAL);
                foreach (RES_ATENCION x in resAtenciones)
                {
                    if (x.COMENTARIO == null)
                        x.COMENTARIO = string.Empty;
                    dgAtencionesAOA.Rows.Add(x.ATENCION_AGEN.PACIENTE.NOMBRES_PACIENTE + " " + x.ATENCION_AGEN.PACIENTE.APELLIDOS_PACIENTE,
                                             x.ATENCION_AGEN.FECHOR.Value.ToShortDateString(), x.COMENTARIO);
                }
                if (resAtenciones.Count == 0)
                {
                    btnAbrirOrden.Enabled = false;
                }
                else
                {
                    resAtencion = resAtenciones[0];
                    btnAbrirOrden.Enabled = true;
                }
            }catch(Exception){
                btnAbrirOrden.Enabled = false;
                MessageBox.Show("Dato incorrecto en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnAbrirOrden_Click(object sender, EventArgs e)
        {
            AccionesTerminal ac = new AccionesTerminal();
            if(resAtencion != null){
                bool x = ac.generarOrdenDeAnalisis(resAtencion.ATENCION_AGEN, resAtencion);
                if(x){
                    acciones = new AccionesTerminal();
                    InitAbrirOrden();
                    MessageBox.Show("Orden de análisis abierta", "Abierta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                } 
                else
                    MessageBox.Show("No se ha podido abrir la orden de análisis", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
            else
                MessageBox.Show("No ha seleccionado un examen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgAtencionesAOA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                resAtencion = resAtenciones[e.RowIndex];
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   CERRAR ORDEN ANALISIS                                                                                                      //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void cerrarOrdenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitGB(gbCerrarOrdenAnalisis);
            InitCerrarOrden();
        }

        private void InitCerrarOrden()
        {
            try
            {
                resAtencion = null;
                dgCerrarOrdenAnalisis.Rows.Clear();
                AccionesTerminal ac = new AccionesTerminal();
                List<RES_ATENCION> aux = ac.ResAtencionesAptasParaCerrarAnalisis(FrmLogin.usuarioLogeado.Personal.ID_PERSONAL);
                resAtenciones = new List<RES_ATENCION>();
                foreach (RES_ATENCION x in aux)
                {
                    if (x.ORDEN_ANALISIS.FECHOR_RECEP == null)
                        resAtenciones.Add(x);
                }
                foreach (RES_ATENCION x in resAtenciones)
                {
                    if (x.COMENTARIO == null)
                        x.COMENTARIO = string.Empty;
                    dgCerrarOrdenAnalisis.Rows.Add(x.ATENCION_AGEN.PACIENTE.NOMBRES_PACIENTE + " " + x.ATENCION_AGEN.PACIENTE.APELLIDOS_PACIENTE,
                                             x.ATENCION_AGEN.FECHOR.Value.ToShortDateString(), x.ORDEN_ANALISIS.FECHOR_EMISION.Value.ToShortDateString(), x.COMENTARIO);
                }
                if (resAtenciones.Count == 0)
                {
                    btCerrarOrdenAnalisis.Enabled = false;
                }
                else 
                {
                    resAtencion = resAtenciones[0];
                    btCerrarOrdenAnalisis.Enabled = true;
                }
            }
            catch (Exception)
            {
                btnAbrirOrden.Enabled = false;
                MessageBox.Show("Dato incorrecto en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btCerrarOrdenAnalisis_Click(object sender, EventArgs e)
        {
            AccionesTerminal ac = new AccionesTerminal();
            if (resAtencion != null)
            {
                if(!string.IsNullOrEmpty(file)){
                    string clob = string.Empty;
                    string extension = string.Empty;
                    try
                    {
                        ConversorBase64 conversor = new ConversorBase64();
                        clob = conversor.convertirABase64(file);
                        extension = Path.GetExtension(file).ToString().Substring(1, 3);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error con el archivo adjunto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    resAtencion.ARCHIVO_B64 = clob;
                    resAtencion.EXT_ARCHIVO = extension;
                    bool x = ac.CerrarOrdenAnalisis(resAtencion);
                    if (x)
                    {
                        acciones = new AccionesTerminal();
                        InitCerrarOrden();
                        MessageBox.Show("Orden de análisis cerrada", "Abierta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                        MessageBox.Show("No se ha podido cerrar la orden de análisis", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("No se adjunto un archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No ha seleccionado una orden de análisis", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgCerrarOrdenAnalisis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                resAtencion = resAtenciones[e.RowIndex];
            }
        }

        private void dgCerrarOrdenAnalisis_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 4) return;

            if (resAtencion.ARCHIVO_B64 == null)
                MessageBox.Show("No posee ningún documento adjunto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                ConversorBase64 conv = new ConversorBase64();
                string nombreArchivo = "Resultado atención Nro" + resAtencion.ID_ATENCION_AGEN;
                conv.convertirDesdeBase64(resAtencion.ARCHIVO_B64, nombreArchivo, resAtencion.EXT_ARCHIVO);
                System.Diagnostics.Process.Start(nombreArchivo + "." + resAtencion.EXT_ARCHIVO);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   AGENDA DIARIA                                                                                                              //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void agendaDiariaToolStripMenuItem_Click(object sender, EventArgs e)
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
                    string bloque = "";
                    if (x.BLOQUE.NUM_MINU_INI == 0)
                        bloque = x.BLOQUE.NUM_HORA_INI + ":00 - " + x.BLOQUE.NUM_HORA_FIN + ":" + x.BLOQUE.NUM_MINU_FIN;
                    else if ((x.BLOQUE.NUM_MINU_FIN == 0))
                        bloque = x.BLOQUE.NUM_HORA_INI + ":" + x.BLOQUE.NUM_MINU_INI + " - " + x.BLOQUE.NUM_HORA_FIN + ":00";
                    else
                        bloque = x.BLOQUE.NUM_HORA_INI + ":" + x.BLOQUE.NUM_MINU_INI + " - " + x.BLOQUE.NUM_HORA_FIN + ":" + x.BLOQUE.NUM_MINU_FIN;
                    agendaDiaria.Add(new AgendaDiaria(x.PRESTACION.NOM_PRESTACION, x.PACIENTE.NOMBRES_PACIENTE + " " + x.PACIENTE.APELLIDOS_PACIENTE, bloque, estado));
                }

            }
            dgAgendaDiaria.DataSource = agendaDiaria;

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   MUESTRA LISTA                                                                                                              //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private static List<ATENCION_AGEN> atenciones = new List<ATENCION_AGEN>();
        private static ATENCION_AGEN atencion = new ATENCION_AGEN();

        private void muestrasParaAnálisisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitGB(gbMuestrasParaAnalisis);
            CargarAtencionesSinMuestra();
        }

        private void CargarAtencionesSinMuestra()
        {
            dgAtencionesMPA.Rows.Clear();
            atenciones = acciones.listaAtencionesPagadasDeMedico(FrmLogin.usuarioLogeado.Personal.PERS_MEDICO.FirstOrDefault().ID_PERSONAL_MEDICO);
            if (atenciones != null)
            {
                if (atenciones.Count > 0)
                {
                    foreach (ATENCION_AGEN x in atenciones)
                    {
                        dgAtencionesMPA.Rows.Add(x.PACIENTE.NOMBRES_PACIENTE +" "+x.PACIENTE.APELLIDOS_PACIENTE, x.FECHOR.Value.ToString());
                    }
                    atencion = atenciones[0];
                    btnMuestraLista.Enabled = true;
                }
                else
                {
                    btnMuestraLista.Enabled = false;
                }
            }
            else
            {
                btnMuestraLista.Enabled = false;
            }
        }

        private void btnMuestraLista_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rtComentarioMPA.Text.Trim()))
            {
                bool x = acciones.RegistrarMuestra(atencion.ID_ATENCION_AGEN, rtComentarioMPA.Text);
                if (x)
                {
                    acciones = new AccionesTerminal();
                    CargarAtencionesSinMuestra();
                    MessageBox.Show("La atencion ahora tiene una muestra asociada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }else
                    MessageBox.Show("Error al ingresar muestra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Campo de comentario vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgAtencionesMPA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                atencion = atenciones[e.RowIndex];
            }
        }

        string file = string.Empty;
        private void btnArchivo_CAM_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog buscar = new OpenFileDialog();

                if (buscar.ShowDialog() == DialogResult.OK)
                {
                    //Ruta del archivo
                    rtArchivo_CAM.Text = buscar.FileName;
                    file = buscar.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al encontrar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
