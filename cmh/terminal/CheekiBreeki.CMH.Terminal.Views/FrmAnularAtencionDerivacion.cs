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
    public partial class FrmAnularAtencionDerivacion : Form
    {
        AccionesTerminal at = new AccionesTerminal();
        FrmLogin login = null;
        bool closeApp;

        public FrmAnularAtencionDerivacion(FrmLogin padre)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            login = padre;
            closeApp = true;
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
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            bool res = false;
            try
            {
                ATENCION_AGEN atencion = new ATENCION_AGEN();
                using (var context = new CMHEntities())
                {
                    atencion = context.ATENCION_AGEN.Find(((ComboboxItem)lstAtenciones.SelectedItem).Value);
                }
                res = at.cerrarOrdenAnalisis(atencion);
                ActualizarLista();
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            if (res)
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
                    List<ATENCION_AGEN> atenciones = at.listaAtencionPorDerivacion(rut).ToList();
                    foreach (ATENCION_AGEN atencion in atenciones)
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Value = atencion.ID_ATENCION_AGEN;
                        item.Text = "Atención: " + atencion.ID_ATENCION_AGEN + " - Médico: " + atencion.PERS_MEDICO.PERSONAL.NOMBREFULL;
                        lstAtenciones.Items.Add(item);
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
                lblError.Visible = true;
                lblError.Text = "Error al buscar atenciones";
                lblError.ForeColor = System.Drawing.Color.Red;
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
