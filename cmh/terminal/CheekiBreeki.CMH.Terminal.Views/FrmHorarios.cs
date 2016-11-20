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
    public partial class FrmHorarios : Form
    {
        AccionesTerminal at = new AccionesTerminal();
        FrmLogin login = null;
        bool closeApp;

        public FrmHorarios(FrmLogin fLogin)
        {
            InitializeComponent();
            closeApp = true;
            login = fLogin;
            this.StartPosition = FormStartPosition.CenterScreen;

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

        private void brnBuscarHorarios_Click(object sender, EventArgs e)
        {
            bool res = false;
            int rut = int.Parse(txtRut.Text);
            lblError.Visible = false;
            lstDisponibles.Items.Clear();
            lstAsignados.Items.Clear();
            try
            {
                if (!Util.rutValido(rut, txtDv.Text))
                    res = false;
                else
                {
                    // Bloques disponibles
                    List<BLOQUE> bloquesDisponibles = at.obtenerBloquesDisponibles(int.Parse(txtRut.Text));
                    foreach (BLOQUE bloques in bloquesDisponibles)
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Value = bloques.ID_BLOQUE;
                        if (bloques.NUM_MINU_INI == 0)
                            item.Text = bloques.DIA_SEM.NOMBRE_DIA + ": " + bloques.NUM_HORA_INI + ":00 - " + bloques.NUM_HORA_FIN + ":" + bloques.NUM_MINU_FIN;
                        else if ((bloques.NUM_MINU_FIN == 0))
                            item.Text = bloques.DIA_SEM.NOMBRE_DIA + ": " + bloques.NUM_HORA_INI + ":" + bloques.NUM_MINU_INI + " - " + bloques.NUM_HORA_FIN + ":00";
                        else
                            item.Text = bloques.DIA_SEM.NOMBRE_DIA + ": " + bloques.NUM_HORA_INI + ":" + bloques.NUM_MINU_INI + " - " + bloques.NUM_HORA_FIN + ":" + bloques.NUM_MINU_FIN;
                        lstDisponibles.Items.Add(item);
                    }

                    // Bloques asignados
                    List<BLOQUE> bloquesAsignados = at.obtenerBloquesAsignados(int.Parse(txtRut.Text));
                    foreach (BLOQUE bloques in bloquesAsignados)
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Value = bloques.ID_BLOQUE;
                        if (bloques.NUM_MINU_INI == 0)
                            item.Text = bloques.DIA_SEM.NOMBRE_DIA + ": " + bloques.NUM_HORA_INI + ":00 - " + bloques.NUM_HORA_FIN + ":" + bloques.NUM_MINU_FIN;
                        else if ((bloques.NUM_MINU_FIN == 0))
                            item.Text = bloques.DIA_SEM.NOMBRE_DIA + ": " + bloques.NUM_HORA_INI + ":" + bloques.NUM_MINU_INI + " - " + bloques.NUM_HORA_FIN + ":00";
                        else
                            item.Text = bloques.DIA_SEM.NOMBRE_DIA + ": " + bloques.NUM_HORA_INI + ":" + bloques.NUM_MINU_INI + " - " + bloques.NUM_HORA_FIN + ":" + bloques.NUM_MINU_FIN;
                        lstAsignados.Items.Add(item);
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {

        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            //List<ComboboxItem> seleccionados = lstDisponibles.SelectedItems;

        }
    }
}
