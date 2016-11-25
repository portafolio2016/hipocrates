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
    public partial class FrmAgendarAtencion : Form
    {
        AccionesTerminal at = new AccionesTerminal();
        private static List<ENTRADA_FICHA> entradaList;
        //private static PACIENTE paciente;
        FrmLogin login = null;
        bool closeApp;

        public FrmAgendarAtencion(FrmLogin fLogin)
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
            comprobarEstadoCaja();
        }

        #region Funciones comunes
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

        private void FrmPrueba_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (closeApp)
                Application.Exit();
        }

        private void btnModificarUser_Click(object sender, EventArgs e)
        {
            InitGB(gbOpcionesUsuario);
        }

        private void InitGB(GroupBox x)
        {
            gbOpcionesUsuario.Hide();
            x.Show();
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
                    bool x = at.actualizarPersonal(personal);
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
                    ;
                    personal.EMAIL = tbNuevoMail.Text.Trim();
                    bool x = at.actualizarPersonal(personal);
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
        //   BOTONES DEL MENU                                                                                                           //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void agendarHoraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAgendarAtencion frmAgendar = new FrmAgendarAtencion(login);
            frmAgendar.Show();
            frmAgendar.Activate();
            this.Hide();
        }

        private void anularHoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAnularAtencion frmAnularAtencion = new FrmAnularAtencion(login);
            frmAnularAtencion.Show();
            frmAnularAtencion.Activate();
            this.Hide();
        }

        private void crearPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCrearPaciente frmCrearPaciente = new FrmCrearPaciente(login);
            frmCrearPaciente.Show();
            frmCrearPaciente.Activate();
            this.Hide();
        }

        private void ingresarPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngresarPaciente frmIngresarPaciente = new FrmIngresarPaciente(login);
            frmIngresarPaciente.Show();
            frmIngresarPaciente.Activate();
            this.Hide();
        }

        private void abrirCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbrirCaja frmAbrirCaja = new FrmAbrirCaja(login);
            frmAbrirCaja.Show();
            frmAbrirCaja.Activate();
            this.Hide();
        }

        private void cerrarCjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCerrarCaja frmCerrarCaja = new FrmCerrarCaja(login);
            frmCerrarCaja.Show();
            frmCerrarCaja.Activate();
            this.Hide();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   DESACTIVAR BOTONES SEGUN ESTADO CAJA                                                                                       //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void comprobarEstadoCaja()
        {
            UsuarioLogeado usuario = FrmLogin.usuarioLogeado;
            if (usuario.Privilegio.ToUpper() == "OPERADOR")
            {
                if (!Util.isObjetoNulo(at.buscarCajaCerrada(usuario.Personal.FUNCIONARIO.FirstOrDefault())))
                {
                    abrirCajaToolStripMenuItem.Enabled = false;
                    ingresarPacienteToolStripMenuItem.Enabled = false;
                    anularHoraToolStripMenuItem.Enabled = false;
                    cerrarCjaToolStripMenuItem.Enabled = false;
                }
                else if (!Util.isObjetoNulo(at.buscarCajaAbierta(usuario.Personal.FUNCIONARIO.FirstOrDefault())))
                {
                    abrirCajaToolStripMenuItem.Enabled = false;
                    ingresarPacienteToolStripMenuItem.Enabled = true;
                    anularHoraToolStripMenuItem.Enabled = true;
                    cerrarCjaToolStripMenuItem.Enabled = true;
                }
                else
                {
                    abrirCajaToolStripMenuItem.Enabled = true;
                    ingresarPacienteToolStripMenuItem.Enabled = false;
                    anularHoraToolStripMenuItem.Enabled = false;
                    cerrarCjaToolStripMenuItem.Enabled = false;
                }
            }
            else
            {
                abrirCajaToolStripMenuItem.Enabled = false;
                cerrarCjaToolStripMenuItem.Enabled = false;
                ingresarPacienteToolStripMenuItem.Enabled = false;
                anularHoraToolStripMenuItem.Enabled = false;
            }

        }
        #endregion

        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public class ObjetoMistico
        {
            public PERS_MEDICO Personal { get; set; }
            public PRESTACION Prestacion { get; set; }
        }

        private void frmAgendarAtencion_Load(object sender, EventArgs e)
        {
            cmbEspecialidad.DataSource = null;
            cmbEspecialidad.ValueMember = "ID_ESPECIALIDAD";
            cmbEspecialidad.DisplayMember = "NOM_ESPECIALIDAD";
            cmbEspecialidad.DataSource = at.listaEspecialidad();
        }

        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEspecialidad = (int)cmbEspecialidad.SelectedValue;

            cmbPersonal.DataSource = null;
            cmbPersonal.ValueMember = "ID_PERSONAL";
            cmbPersonal.DisplayMember = "NOMBREFULL";
            cmbPersonal.DataSource = at.listaPersonales(idEspecialidad);

            cmbPrestacion.DataSource = null;
            cmbPrestacion.ValueMember = "ID_PRESTACION";
            cmbPrestacion.DisplayMember = "NOM_PRESTACION";
            cmbPrestacion.DataSource = at.listaPrestaciones(idEspecialidad);
        }

        private void dtFecha_ValueChanged(object sender, EventArgs e)
        {
            actualizarBloques();
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            string mensajeCorrecto = "Atención agendada correctamente";
            string mensajeError = string.Empty;
            lblError.Visible = false;
            try
            {
                ATENCION_AGEN atencion = new ATENCION_AGEN();
                PACIENTE paciente = new PACIENTE();
                PRESTACION prestacion = new PRESTACION();
                ESTADO_ATEN estado = new ESTADO_ATEN();
                PERS_MEDICO personalMedico = new PERS_MEDICO();
                BLOQUE bloque = new BLOQUE();
                if (dtFecha.Value < DateTime.Today)
                    mensajeError = "La fecha de atención ha expirado";
                else
                {
                    using (var context = new CMHEntities())
                    {
                        estado = context.ESTADO_ATEN.Where(d => d.NOM_ESTADO_ATEN.ToUpper() == "VIGENTE").FirstOrDefault();
                        personalMedico = context.PERS_MEDICO.Find((int)cmbPersonal.SelectedValue);
                    }
                    if (txtRut.Text == string.Empty || txtDv.Text == string.Empty)
                        mensajeError = "Complete los campos de RUT";
                    else
                    {
                        paciente = at.buscarPaciente(int.Parse(txtRut.Text), txtDv.Text.ToUpper());
                        if (!Util.isObjetoNulo(paciente))
                        {
                            atencion.FECHOR = dtFecha.Value;
                            atencion.ID_PACIENTE = paciente.ID_PACIENTE;
                            atencion.ID_PRESTACION = (int)cmbPrestacion.SelectedValue;
                            atencion.ID_ESTADO_ATEN = estado.ID_ESTADO_ATEN;
                            atencion.ID_PERS_ATIENDE = (int)cmbPersonal.SelectedValue;
                            atencion.ID_BLOQUE = ((ComboboxItem)cmbHora.SelectedItem).Value;
                            if (!at.agendarAtencion(atencion))
                                mensajeError = "Error al agendar atención";
                            actualizarBloques();
                        }
                        else
                            mensajeError = "Paciente no encontrado";
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError = "Error al agendar atención";
            }
            if (mensajeError == string.Empty)
                MessageBox.Show(mensajeCorrecto, "Creada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void actualizarBloques()
        {
            cmbHora.Items.Clear();
            PERSONAL personal = new PERSONAL();
            personal.ID_PERSONAL = (int)cmbPersonal.SelectedValue;
            PERS_MEDICO persMedico = at.buscarPersonalMedico(personal);

            DateTime dia = dtFecha.Value;

            HorasDisponibles horas = at.horasDisponiblesMedico(persMedico, dia);
            foreach (HoraDisponible hora in horas.Horas)
            {
                ComboboxItem item = new ComboboxItem();
                if (hora.MinuIni == 0)
                    item.Text = hora.HoraFin + ":00 - " + hora.HoraFin + ":" + hora.MinuFin;
                else if ((hora.MinuFin == 0))
                    item.Text = hora.HoraFin + ":" + hora.MinuIni + " - " + hora.HoraFin + ":00";
                else
                    item.Text = hora.HoraFin + ":" + hora.MinuIni + " - " + hora.HoraFin + ":" + hora.MinuFin;
                item.Value = hora.Bloque.ID_BLOQUE;
                cmbHora.Items.Add(item);
                cmbHora.SelectedIndex = 0;
            }
        }

        private void cmbPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Util.isObjetoNulo(cmbPersonal.SelectedValue))
                actualizarBloques();
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

        private void FrmAgendarAtencion_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (closeApp)
                Application.Exit();
        }


    }
}
