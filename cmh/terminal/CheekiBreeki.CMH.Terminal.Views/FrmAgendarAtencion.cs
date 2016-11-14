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
    public partial class FrmAgendarAtencion : Form
    {
        AccionesTerminal at = new AccionesTerminal();
        public FrmAgendarAtencion()
        {
            InitializeComponent();
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void frmAgendarAtencion_Load(object sender, EventArgs e)
        {
            cmbEspecialidad.DataSource = at.listaEspecialidad();
            cmbEspecialidad.ValueMember = "ID_ESPECIALIDAD";
            cmbEspecialidad.DisplayMember = "NOM_ESPECIALIDAD";
        }

        private void atencionesMédicasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idEspecialidad = cmbEspecialidad.Text;
            cmbPersonal.DataSource = null;
            cmbPersonal.DataSource = at.listaPersonales(idEspecialidad);
            cmbPersonal.ValueMember = "ID_PERSONAL";
            cmbPersonal.DisplayMember = "NOMBRES";

            cmbPrestacion.DataSource = null;
            cmbPrestacion.DataSource = at.listaPrestaciones(idEspecialidad);
            cmbPrestacion.ValueMember = "ID_PRESTACION";
            cmbPrestacion.DisplayMember = "NOM_PRESTACION";
            
            //actualizarBloques();
        }

        private void dtFecha_ValueChanged(object sender, EventArgs e)
        {
            actualizarBloques();
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
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
                item.Value = hora.Bloque.ID_BLOQUE.ToString();
                cmbHora.Items.Add(item);
                cmbHora.SelectedIndex = 0;
            }
        }

        private void cmbPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            //actualizarBloques();
        }
    }
}
