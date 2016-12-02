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
    public partial class FrmEnfermero : Form
    {
        private static AccionesTerminal acciones = new AccionesTerminal();
        private static DateTime fechaReporte;
        FrmLogin login = null;
        bool closeApp;

        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   CONSTRUCTOR                                                                                                                //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FrmEnfermero(FrmLogin fLogin)
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
        //   FORM CLOSED                                                                                                                //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void FrmJefeOp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (closeApp)
                Application.Exit();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   OPCIONES DE CUENTA                                                                                                         //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnModificarUser_Click(object sender, EventArgs e)
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
            gbAgendaDiaria.Hide();
            gbCerrarAtencionMedica.Hide();
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
            //TEST
            //agendaDiaria.Add(new AgendaDiaria("testttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttts", "testtttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttts", "testtttttttttttttttttttttttttttttttttttttttttttt", true));
            //TEST
            dgAgendaDiaria.DataSource = agendaDiaria;

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   CERRAR ATENCION                                                                                                            //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        string file = string.Empty;

        private void cerrarExamenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitGB(gbCerrarAtencionMedica);
        }
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

        private void btnCrearResultado_CAM_Click(object sender, EventArgs e)
        {
            bool res;
            try
            {
                AccionesTerminal at = new AccionesTerminal();
                ConversorBase64 conversor = new ConversorBase64();
                RES_ATENCION resultadoAtencion = new RES_ATENCION();
                resultadoAtencion.ATENCION_ABIERTA = false;
                resultadoAtencion.COMENTARIO = rtComentario_CAM.Text;

                resultadoAtencion.ID_ATENCION_AGEN = ((ComboboxItem)lstAtenciones_CAM.SelectedItem).Value;
                string clob = conversor.convertirABase64(file);
                resultadoAtencion.ARCHIVO_B64 = clob;
                string extension = Path.GetExtension(file).ToString().Substring(1, 3);
                resultadoAtencion.EXT_ARCHIVO = extension;

                //Busque atención
                ATENCION_AGEN atencionAg = at.buscarAtencionAgendadaID(((ComboboxItem)lstAtenciones_CAM.SelectedItem).Value);
                //Actualice atención
                res = at.cerrarOrdenDeAnalisis(atencionAg, file);
                if (res)
                    res = at.nuevoResultadoAtencion(resultadoAtencion);
                res = at.nuevoResultadoAtencion(resultadoAtencion);
            }
            catch (Exception ex)
            {
                res = false;

            }

            if (res == true)
                MessageBox.Show("Creada el resultado de atención", "Creada", MessageBoxButtons.OK, MessageBoxIcon.None);
            else
                MessageBox.Show("Error al crear resultado de atención", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnBuscarPaciente_CAM_Click(object sender, EventArgs e)
        {
            AccionesTerminal at = new AccionesTerminal();
            bool res = false;
            // int rut = int.Parse(txtRutPaciente_CAM.Text);
            lblError_CAM.Visible = false;
            lstAtenciones_CAM.Items.Clear();
            try
            {
                if (!Util.rutValido(int.Parse(txtRutPaciente_CAM.Text), txtDV_CAM.Text))
                    res = false;
                else
                {

                    List<ATENCION_AGEN> atenciones = at.listaAtencionesPagadas(int.Parse(txtRutPaciente_CAM.Text)).ToList();

                    if (atenciones.Count <= 0)
                    {
                        MessageBox.Show("No tiene ninguna atención", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    foreach (ATENCION_AGEN atencion in atenciones)
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Value = atencion.ID_ATENCION_AGEN;
                        item.Text = "Atención: " + atencion.ID_ATENCION_AGEN + " - Médico: " + atencion.PERS_MEDICO.PERSONAL.NOMBREFULL;
                        lstAtenciones_CAM.Items.Add(item);
                    }

                    res = true;
                }
            }
            catch (Exception ex)
            {
                res = false;
            }
            if (!res)
            {
                lblError_CAM.Visible = true;
                lblError_CAM.Text = "Error al buscar atenciones";
                lblError_CAM.ForeColor = System.Drawing.Color.Red;
            }
            if (Util.isObjetoNulo(lstAtenciones_CAM.SelectedValue))
            {
                btnCrearResultado_CAM.Enabled = false;
            }
        }

        private void lstAtenciones_CAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCrearResultado_CAM.Enabled = true;
        }

        private void txtRut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != 'k') && (e.KeyChar != 'K'))
            {
                e.Handled = true;
            }
        }
    }
}
