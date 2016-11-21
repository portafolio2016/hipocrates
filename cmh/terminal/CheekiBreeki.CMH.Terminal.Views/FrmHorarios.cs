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

        public class ComboboxItemObject
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
                        ComboboxItemObject item = new ComboboxItemObject();
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
                        ComboboxItemObject item = new ComboboxItemObject();
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
                lblError.Text = "Error al buscar horarios";
                lblError.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            List<ComboboxItemObject> seleccionados = lstDisponibles.SelectedItems.Cast<ComboboxItemObject>().ToList();
            foreach (ComboboxItemObject item in seleccionados)
            {
                lstDisponibles.Items.Remove(item);
            }
            lstAsignados.Items.AddRange(seleccionados.ToArray());
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            List<ComboboxItemObject> seleccionados = lstAsignados.SelectedItems.Cast<ComboboxItemObject>().ToList();
            foreach (ComboboxItemObject item in seleccionados)
            {
                lstAsignados.Items.Remove(item);
            }
            lstDisponibles.Items.AddRange(seleccionados.ToArray());
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            lblError.Visible = true;
            lblError.Text = "Actualizando horarios...";
            btnGuardarCambios.Enabled = false;
            lblError.ForeColor = System.Drawing.Color.Violet;
            List<ComboboxItemObject> seleccionados = lstAsignados.Items.Cast<ComboboxItemObject>().ToList();
            List<BLOQUE> bloquesAsignados = new List<BLOQUE>();
            foreach (ComboboxItemObject item in seleccionados)
            {
                BLOQUE nuevo = new BLOQUE();
                nuevo.ID_BLOQUE = int.Parse(item.Value.ToString());
                bloquesAsignados.Add(nuevo);
            }
            bool res = at.guardarCambiosHorarios(bloquesAsignados, int.Parse(txtRut.Text));

            if (res)
            {
                lblError.Visible = true;
                lblError.Text = "Horarios actualizados correctamente";
                lblError.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Error al actualizar horarios";
                lblError.ForeColor = System.Drawing.Color.Red;
            }
            btnGuardarCambios.Enabled = true;
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
