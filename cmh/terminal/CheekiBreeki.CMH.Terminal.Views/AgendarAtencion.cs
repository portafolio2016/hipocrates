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
    public partial class frmAgendarAtencion : Form
    {
        public frmAgendarAtencion()
        {
            InitializeComponent();
        }

        private void frmAgendarAtencion_Load(object sender, EventArgs e)
        {
            AccionesTerminal at = new AccionesTerminal();
            comboBox1.DataSource = at.listaEspecialidad().ToList();
            comboBox1.ValueMember = "ID_ESPECIALIDAD";
            comboBox1.DisplayMember = "NOM_ESPECIALIDAD";
        }

        private void atencionesMédicasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
