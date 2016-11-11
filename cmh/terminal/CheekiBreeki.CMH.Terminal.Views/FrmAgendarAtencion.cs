using CheekiBreeki.CMH.Terminal.BL;
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
            cmbPersonal.DataSource = at.listaPersonales(idEspecialidad);
            cmbPersonal.ValueMember = "ID_PERSONAL";
            cmbPersonal.DisplayMember = "NOMBRES";
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
        }
    }
}
