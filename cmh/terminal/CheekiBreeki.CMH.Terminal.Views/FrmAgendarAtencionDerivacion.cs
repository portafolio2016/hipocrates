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
    public partial class FrmAgendarAtencionDerivacion : Form
    {
        AccionesTerminal at = new AccionesTerminal();
        FrmLogin login = null;
        bool closeApp;

        public FrmAgendarAtencionDerivacion(FrmLogin padre)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            login = padre;
            closeApp = true;
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public class ObjetoMistico
        {
            public PERS_MEDICO Personal { get; set; }
            public PRESTACION Prestacion { get; set; }
        }

        private void frmAgendarAtencion_Load(object sender, EventArgs e)
        {
            cmbEspecialidad.DataSource = null;
            cmbEspecialidad.ValueMember = "ID_ESPECIALIDAD";
            cmbEspecialidad.DisplayMember = "NOM_ESPECIALIDAD";
            cmbEspecialidad.DataSource = at.listaEspecialidad();
        }

        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEspecialidad = (int)cmbEspecialidad.SelectedValue;

            cmbPersonal.DataSource = null;
            cmbPersonal.ValueMember = "ID_PERSONAL";
            cmbPersonal.DisplayMember = "NOMBREFULL";
            cmbPersonal.DataSource = at.listaPersonales(idEspecialidad);

            cmbPrestacion.DataSource = null;
            cmbPrestacion.ValueMember = "ID_PRESTACION";
            cmbPrestacion.DisplayMember = "NOM_PRESTACION";
            cmbPrestacion.DataSource = at.listaPrestaciones(idEspecialidad);
        }

        private void dtFecha_ValueChanged(object sender, EventArgs e)
        {
            actualizarBloques();
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            bool res = false;
            try
            {
                ATENCION_AGEN atencion = new ATENCION_AGEN();
                PACIENTE paciente = new PACIENTE();
                PRESTACION prestacion = new PRESTACION();
                ESTADO_ATEN estado = new ESTADO_ATEN();
                PERS_MEDICO personalMedico = new PERS_MEDICO();
                BLOQUE bloque = new BLOQUE();
                if (dtFecha.Value < DateTime.Today)
                    res = false;
                else
                {
                    using (var context = new CMHEntities())
                    {
                        estado = context.ESTADO_ATEN.Where(d => d.NOM_ESTADO_ATEN.ToUpper() == "VIGENTE").FirstOrDefault();
                        personalMedico = context.PERS_MEDICO.Find((int)cmbPersonal.SelectedValue);
                    }
                    paciente = at.buscarPaciente(int.Parse(txtRut.Text), txtDv.Text.ToUpper());
                    if (!Util.isObjetoNulo(paciente))
                    {
                        atencion.FECHOR = dtFecha.Value;
                        atencion.ID_PACIENTE = paciente.ID_PACIENTE;
                        atencion.ID_PRESTACION = (int)cmbPrestacion.SelectedValue;
                        atencion.ID_ESTADO_ATEN = estado.ID_ESTADO_ATEN;
                        atencion.ID_PERS_ATIENDE = (int)cmbPersonal.SelectedValue;
                        atencion.ID_PERS_SOLICITA = FrmLogin.usuarioLogeado.Personal.PERS_MEDICO.FirstOrDefault().ID_PERSONAL;
                        atencion.ID_BLOQUE = ((ComboboxItem)cmbHora.SelectedItem).Value;
                        atencion.OBSERVACIONES = rtObservacion.Text;

                        res = at.agendarAtencion(atencion);
                        actualizarBloques();
                    }
                }
            }
            catch (Exception ex)
            {
                res = false;
            }
            if (res)
            {
                lblError.Visible = true;
                lblError.Text = "Orden de análisis correctamente";
                lblError.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Error al agendar atención";
                lblError.ForeColor = System.Drawing.Color.Red;
            }
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
                item.Value = hora.Bloque.ID_BLOQUE;
                cmbHora.Items.Add(item);
                cmbHora.SelectedIndex = 0;
            }
        }

        private void cmbPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Util.isObjetoNulo(cmbPersonal.SelectedValue))
                actualizarBloques();
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

        private void FrmAgendarAtencion_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (closeApp)
                Application.Exit();
        }

        
        

       
    }
}