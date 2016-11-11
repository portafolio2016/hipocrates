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


namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AccionesTerminal at = new AccionesTerminal();
            comboBox1.DataSource = at.listaEspecialidad().ToList();
            comboBox1.ValueMember = "ID_ESPECIALIDAD";
            comboBox1.DisplayMember = "NOM_ESPECIALIDAD";
        }
    }
}
