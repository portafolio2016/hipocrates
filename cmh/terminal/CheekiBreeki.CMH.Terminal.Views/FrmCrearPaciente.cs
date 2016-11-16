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
            cmbSexo.SelectedIndex = 0;
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
            try
            {
                if (dtFechaNacimiento.Value > DateTime.Today)
                    res = false;
                else if (!Util.rutValido(int.Parse(txtRut.Text), txtDv.Text))
                    res = false;
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Creando paciente...";
                    lblError.ForeColor = System.Drawing.Color.Violet;
                    btnCrear.Enabled = false;

                    AccionesTerminal at = new AccionesTerminal();
                    PACIENTE paciente = new PACIENTE();

                    paciente.NOMBRES_PACIENTE = txtNombres.Text;
                    paciente.APELLIDOS_PACIENTE = txtApellidos.Text;
                    paciente.RUT = int.Parse(txtRut.Text);
                    paciente.DIGITO_VERIFICADOR = txtDv.Text;
                    paciente.EMAIL_PACIENTE = txtCorreo.Text;
                    paciente.SEXO = ((ComboboxItem)cmbSexo.SelectedItem).Value;
                    paciente.FEC_NAC = dtFechaNacimiento.Value;

                    res = at.nuevoPaciente(paciente);
                }
            }
            catch (Exception ex)
            {
                res = false;
            }
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
            btnCrear.Enabled = true;
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

        private void FrmCrearPaciente_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (closeApp)
                Application.Exit();
        }
    }
}
