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
    public partial class FrmIngresarPaciente : Form
    {
        private static AccionesTerminal at = new AccionesTerminal();
        private static List<ENTRADA_FICHA> entradaList;
        //private static PACIENTE paciente;
        FrmLogin login = null;
        bool closeApp;

        public FrmIngresarPaciente(FrmLogin fLogin)
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

        private void FrmIngresarPaciente_FormClosed(object sender, FormClosedEventArgs e)
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
            public Object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void brnBuscarAtenciones_Click(object sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string mensajeCorrecto = "Paciente ingresado correctamente";
            string mensajeError = string.Empty;
            bool res1 = false, res2 = false;
            try
            {
                UsuarioLogeado usuario = FrmLogin.usuarioLogeado;
                ATENCION_AGEN atencion = new ATENCION_AGEN();
                PAGO pago = new PAGO();
                CAJA caja = new CAJA();
                using (var context = new CMHEntities())
                {
                    atencion = context.ATENCION_AGEN.Find(((ComboboxItem)lstAtenciones.SelectedItem).Value);
                }
                caja = at.buscarCajaAbierta(usuario.Personal.FUNCIONARIO.FirstOrDefault());

                pago.ID_ATENCION_AGEN = atencion.ID_ATENCION_AGEN;
                pago.MONTO_PAGO = int.Parse(lblTotal.Text);
                pago.ID_CAJA = caja.ID_CAJA;

                res1 = at.ingresarPaciente(atencion);
                res2 = at.registrarPago(pago, lblAseguradora.Text, int.Parse(lblDescuento.Text));
                ActualizarLista();
            }
            catch (Exception ex)
            {
                mensajeError = "Error al ingresar paciente";
            }
            if (res1 && res2)
                MessageBox.Show(mensajeCorrecto, "Creada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void ActualizarLista()
        {
            string mensajeError = string.Empty;
            lblError.Visible = false;
            lstAtenciones.Items.Clear();
            try
            {
                int rut = int.Parse(txtRut.Text);
                if (!Util.rutValido(rut, txtDv.Text))
                    mensajeError = "RUT no válido";
                else
                {
                    List<ATENCION_AGEN> atenciones = at.listaAtencionesVigentes(rut).ToList();
                    foreach (ATENCION_AGEN atencion in atenciones)
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Value = atencion.ID_ATENCION_AGEN;
                        item.Text = "Atención: " + atencion.ID_ATENCION_AGEN + " - Médico: " + atencion.PERS_MEDICO.PERSONAL.NOMBREFULL;
                        lstAtenciones.Items.Add(item);
                    }
                    PACIENTE paciente = at.buscarPaciente(rut, txtDv.Text);
                    lblNombre.Text = paciente.NOMBRES_PACIENTE + " " + paciente.APELLIDOS_PACIENTE;
                    lblEdad.Text = paciente.FEC_NAC.Value.Date.ToShortDateString();
                    lblSexo.Text = paciente.SEXO;
                    lblRutInfo.Text = paciente.RUT + "-" + paciente.DIGITO_VERIFICADOR;
                    mostrarLabelPaciente();
                }
            }
            catch (Exception ex)
            {
                mensajeError = "Error al buscar atenciones";
            }
            if (mensajeError == string.Empty)
                mostrarLabelPaciente();
            else
                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (Util.isObjetoNulo(lstAtenciones.SelectedValue))
                btnIngresar.Enabled = false;
        }

        private void mostrarLabelPaciente()
        {
            bool estado = true;
            lblNombre.Visible = estado;
            lblEdad.Visible = estado;
            lblSexo.Visible = estado;
            lblRutInfo.Visible = estado;
        }

        private void mostrarLabelDescuento()
        {
            bool estado = true;
            lblSubtotal.Visible = estado;
            lblDescuento.Visible = estado;
            lblTotal.Visible = estado;
            lblAseguradora.Visible = estado;

            lblSubtotal.Text = string.Empty;
            lblTotal.Text = string.Empty;
            lblDescuento.Text = string.Empty;
            lblAseguradora.Text = string.Empty;
        }

        private void lstAtenciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Visible = true;
            lblError.Text = "Consultando aseguradora...";
            lblError.ForeColor = System.Drawing.Color.Violet;
            mostrarLabelDescuento();
            try
            {
                ATENCION_AGEN atencion = new ATENCION_AGEN();
                PACIENTE paciente = new PACIENTE();
                PRESTACION prestacion = new PRESTACION();
                ResultadoVerificacionSeguro seguro = new ResultadoVerificacionSeguro();
                using (var context = new CMHEntities())
                {
                    atencion = context.ATENCION_AGEN.Find(((ComboboxItem)lstAtenciones.SelectedItem).Value);
                    paciente = context.PACIENTE.Find(atencion.ID_PACIENTE);
                    prestacion = context.PRESTACION.Find(atencion.ID_PRESTACION);
                }

                seguro = at.verificarSeguro(prestacion, paciente);
                lblSubtotal.Text = atencion.PRESTACION.PRECIO_PRESTACION.ToString();
                lblTotal.Text = seguro.Descuento.ToString();
                if (seguro.Aseguradora == "No tiene seguro")
                {
                    lblTotal.Text = atencion.PRESTACION.PRECIO_PRESTACION.ToString();
                    lblDescuento.Text = "0";
                }
                else
                {
                    lblTotal.Text = seguro.Descuento.ToString();
                    lblDescuento.Text = (int.Parse(lblSubtotal.Text) - int.Parse(lblTotal.Text)).ToString();
                }
                lblAseguradora.Text = seguro.Aseguradora;
                btnIngresar.Enabled = true;
                lblError.Visible = false;
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error al buscar descuento";
                lblError.ForeColor = System.Drawing.Color.Red;
                lblSubtotal.Text = string.Empty;
                lblTotal.Text = string.Empty;
                lblDescuento.Text = string.Empty;
                btnIngresar.Enabled = false;
            }
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
