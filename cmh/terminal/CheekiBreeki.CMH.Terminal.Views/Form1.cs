using CheekiBreeki.CMH.Terminal.BL;
using CheekiBreeki.CMH.Terminal.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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

        private void atenciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void frmAgendarAtencion_Load(object sender, EventArgs e)
        {
            AccionesTerminal at = new AccionesTerminal();
            using (var context = new CMHEntities())
            {
                //this.eSPECIALIDADTableAdapter.Fill(this.dataSet1.ESPECIALIDAD);
                //DbSet<ESPECIALIDAD> especialidades = at.listaEspecialidad();
                cmbEspecialidad.DataSource = context.ESPECIALIDAD;
                cmbEspecialidad.ValueMember = "ID_ESPECIALIDAD";
                cmbEspecialidad.DisplayMember = "NOM_ESPECIALIDAD";
            }
        }
    }
}
