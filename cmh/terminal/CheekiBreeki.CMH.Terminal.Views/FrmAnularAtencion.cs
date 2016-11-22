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
    public partial class FrmAnularAtencion : Form
    {
        private static AccionesTerminal at = new AccionesTerminal();
        private static List<ENTRADA_FICHA> entradaList;
        PAGO pago = new PAGO();
        FrmLogin login = null;
        bool closeApp;

        public FrmAnularAtencion(FrmLogin fLogin)
        {
            InitializeComponent();
            closeApp = true;
            entradaList = new List<ENTRADA_FICHA>();
            login = fLogin;
            btnAnular.Enabled = false;
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

        private void FrmAnularAtencion_FormClosed(object sender, FormClosedEventArgs e)
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
            mostrarLabelPaciente();
            ActualizarLista();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            bool res1 = false, res2 = false;
            bool necesitaDevolucion = false;
            try
            {
                ATENCION_AGEN atencion = new ATENCION_AGEN();
                using (var context = new CMHEntities())
                {
                    atencion = context.ATENCION_AGEN.Find(((ComboboxItem)lstAtenciones.SelectedItem).Value);
                    atencion.ESTADO_ATEN = context.ESTADO_ATEN.Find(atencion.ID_ESTADO_ATEN);
                    if (atencion.ESTADO_ATEN.NOM_ESTADO_ATEN.ToUpper() == "PAGADO")
                        necesitaDevolucion = true;
                }
                res1 = at.anularAtencion(atencion);
                if (atencion.ESTADO_ATEN.NOM_ESTADO_ATEN.ToUpper() == "PAGADO")
                    res2 = at.devolverPago(pago, txtRazon.Text);
                ActualizarLista();
            }
            catch (Exception ex)
            {
                res1 = false;
            }
            if (!necesitaDevolucion && res1)
            {
                lblError.Visible = true;
                lblError.Text = "Atención anulada correctamente";
                lblError.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                if (res1 && res2)
                {
                    lblError.Visible = true;
                    lblError.Text = "Atención anulada correctamente";
                    lblError.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Error al anular atención";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    txtRazon.Text = string.Empty;
                }
            }
        }

        private void ActualizarLista()
        {
            bool res = false;
            int rut = int.Parse(txtRut.Text);
            lblError.Visible = false;
            lstAtenciones.Items.Clear();
            try
            {
                if (!Util.rutValido(rut, txtDv.Text))
                    res = false;
                else
                {
                    List<ATENCION_AGEN> atenciones = at.listaAtencionesVigentesPagadas(rut).ToList();
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
                    res = true;
                }
            }
            catch (Exception ex)
            {
                res = false;
            }
            if (!res)
            {
                lblError.Visible = true;
                lblError.Text = "Error al buscar atenciones";
                lblError.ForeColor = System.Drawing.Color.Red;
            }
            if (Util.isObjetoNulo(lstAtenciones.SelectedValue))
                btnAnular.Enabled = false;
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

        private void lstAtenciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarLabelDescuento();
            try
            {
                ATENCION_AGEN atencion = new ATENCION_AGEN();
                PACIENTE paciente = new PACIENTE();
                PRESTACION prestacion = new PRESTACION();
                BONO bono = new BONO();
                ASEGURADORA aseguradora = new ASEGURADORA();
                ResultadoVerificacionSeguro seguro = new ResultadoVerificacionSeguro();
                bool necesitaDevolucion = false;

                using (var context = new CMHEntities())
                {
                    atencion = context.ATENCION_AGEN.Find(((ComboboxItem)lstAtenciones.SelectedItem).Value);
                    atencion.ESTADO_ATEN = context.ESTADO_ATEN.Find(atencion.ID_ESTADO_ATEN);
                    if (atencion.ESTADO_ATEN.NOM_ESTADO_ATEN.ToUpper() == "PAGADO")
                        necesitaDevolucion = true;
                    if (necesitaDevolucion)
                    {
                        paciente = context.PACIENTE.Find(atencion.ID_PACIENTE);
                        prestacion = context.PRESTACION.Find(atencion.ID_PRESTACION);
                        pago = context.PAGO.Where(d => d.ID_ATENCION_AGEN == atencion.ID_ATENCION_AGEN).FirstOrDefault();
                        if (pago.ID_BONO != null)
                        {
                            bono = context.BONO.Find(pago.ID_BONO);
                            aseguradora = context.ASEGURADORA.Find(bono.ID_ASEGURADORA);
                        }
                    }
                }
                if (necesitaDevolucion)
                {
                    lblSubtotal.Text = atencion.PRESTACION.PRECIO_PRESTACION.ToString();
                    lblTotal.Text = pago.MONTO_PAGO.ToString();
                    if (pago.ID_BONO != null)
                    {
                        lblDescuento.Text = pago.BONO.CANT_BONO.ToString();
                        lblAseguradora.Text = aseguradora.NOM_ASEGURADORA;
                    }
                    else
                    {
                        lblDescuento.Text = "0";
                        lblAseguradora.Text = "No tiene seguro";
                    }
                    btnAnular.Enabled = true;
                    lblError.Visible = false;
                }
                else
                    btnAnular.Enabled = true;

            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error al buscar pago";
                lblError.ForeColor = System.Drawing.Color.Red;
                lblSubtotal.Text = string.Empty;
                lblTotal.Text = string.Empty;
                lblDescuento.Text = string.Empty;
                btnAnular.Enabled = false;
            }
        }

    }
}
