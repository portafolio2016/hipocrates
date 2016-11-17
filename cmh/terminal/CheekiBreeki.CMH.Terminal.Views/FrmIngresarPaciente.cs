using CheekiBreeki.CMH.Terminal.BL;
using CheekiBreeki.CMH.Terminal.DAL;
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
    public partial class FrmIngresarPaciente : Form
    {
        AccionesTerminal at = new AccionesTerminal();
        FrmLogin login = null;
        bool closeApp;

        public FrmIngresarPaciente(FrmLogin padre)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            login = padre;
            closeApp = true;
            btnIngresar.Enabled = false;
        }

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
            mostrarLabelPaciente();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
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
                res1 = true;
            }
            catch (Exception ex)
            {
                res1 = false;
            }
            if (res1 && res2)
            {
                lblError.Visible = true;
                lblError.Text = "Paciente ingresado correctamente";
                lblError.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Error al ingresar paciente";
                lblError.ForeColor = System.Drawing.Color.Red;
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
                lblDescuento.Text = (int.Parse(lblSubtotal.Text) - int.Parse(lblTotal.Text)).ToString();
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

        private void FrmIngresarPaciente_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (closeApp)
                Application.Exit();
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
