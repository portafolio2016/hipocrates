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
    public partial class FrmAnularAtencion : Form
    {
        AccionesTerminal at = new AccionesTerminal();
        PAGO pago = new PAGO();
        FrmLogin login = null;
        bool closeApp;

        public FrmAnularAtencion(FrmLogin padre)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            login = padre;
            closeApp = true;
            btnAnular.Enabled = false;
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
                        bono = context.BONO.Find(pago.ID_BONO);
                        aseguradora = context.ASEGURADORA.Find(bono.ID_ASEGURADORA);
                    }
                }
                if(necesitaDevolucion)
                {
                    lblSubtotal.Text = atencion.PRESTACION.PRECIO_PRESTACION.ToString();
                    lblTotal.Text = pago.MONTO_PAGO.ToString();
                    lblDescuento.Text = pago.BONO.CANT_BONO.ToString();
                    lblAseguradora.Text = aseguradora.NOM_ASEGURADORA;
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
