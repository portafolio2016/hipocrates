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
    public partial class FrmCrearPaciente : Form
    {

        FrmLogin login = null;
        bool closeApp;

        public FrmCrearPaciente(FrmLogin padre)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            login = padre;
            closeApp = true;

            ComboboxItem masculino = new ComboboxItem();
            masculino.Text = "Masculino";
            masculino.Value = "M";
            ComboboxItem femenino = new ComboboxItem();
            femenino.Text = "Femenino";
            femenino.Value = "F";
            cmbSexo.Items.Add(masculino);
            cmbSexo.Items.Add(femenino);
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

        private void btnCrear_Click(object sender, EventArgs e)
        {
            bool res = false;

            if (res)
            {
                lblError.Visible = true;
                lblError.Text = "Paciente creado correctamente";
                lblError.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Error al crear pacientes";
                lblError.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void FrmCrearPaciente_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (closeApp)
                Application.Exit();
        }
    }
}
