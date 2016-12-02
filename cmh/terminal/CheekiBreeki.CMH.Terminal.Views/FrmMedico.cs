using CheekiBreeki.CMH.Terminal.BL;
using CheekiBreeki.CMH.Terminal.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace CheekiBreeki.CMH.Terminal.Views
{
    public partial class FrmMedico : Form
    {
        FrmLogin login = null;
        bool closeApp;
        private static AccionesTerminal acciones = new AccionesTerminal();
        private static List<ENTRADA_FICHA> entradaList;
        private static PACIENTE paciente;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   CONSTRUCTOR                                                                                                                //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FrmMedico(FrmLogin fLogin)
        {
            InitializeComponent();
            closeApp = true;
            entradaList = new List<ENTRADA_FICHA>();
            login = fLogin;
            this.StartPosition = FormStartPosition.CenterScreen;

            if (FrmLogin.usuarioLogeado != null)
            {
                lblUsuarioConectado.Text = "Usuario Conectado: " + FrmLogin.usuarioLogeado.NombreUsuario;
                lblPrivilegio.Text = "Privilegio: " + FrmLogin.usuarioLogeado.Privilegio;
                btnSesion.Text = "Cerrar Sesión";
            }
            else
            {
                lblUsuarioConectado.Text = "Debes iniciar sesión";
                lblPrivilegio.Text = "";
                btnSesion.Text = "Iniciar sesión";
            }

            //rtArchivo_CAM.Enabled = false;
            //btnArchivo_CAM.Enabled = false;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   CERRAR SESION                                                                                                              //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cerrar sesión?", "Cerrar sesión",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                closeApp = false;
                login.camposVacios();
                login.Show();
                this.Close();

            }
            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   OPCIONES DE CUENTA                                                                                                         //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbContrasenaActual.Text.Trim()) && !string.IsNullOrEmpty(tbContrasenaNueva.Text.Trim()))
            {
                if (Util.isObjetoNulo(Login.verificarUsuario(FrmLogin.usuarioLogeado.Personal.EMAIL, tbContrasenaActual.Text)))
                {
                    MessageBox.Show("La contraseña ingresada no es correcta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    PERSONAL personal = Login.verificarUsuario(FrmLogin.usuarioLogeado.Personal.EMAIL, tbContrasenaActual.Text);
                    personal.HASHED_PASS = Util.hashMD5(tbContrasenaNueva.Text.TrimStart().TrimEnd());
                    bool x = acciones.actualizarPersonal(personal);
                    if (x)
                    {
                        MessageBox.Show("Contraseña actualizada con exito", "Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        tbContrasenaActual.Text = "";
                        tbContrasenaNueva.Text = "";
                    }
                    else
                        MessageBox.Show("Error al actualizar contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (string.IsNullOrEmpty(tbContrasenaActual.Text.Trim()) && string.IsNullOrEmpty(tbContrasenaNueva.Text.Trim()))
            {
                MessageBox.Show("Los dos campos estan vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(tbContrasenaActual.Text.Trim()))
            {
                MessageBox.Show("El campo de constraseña actual esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(tbContrasenaNueva.Text.Trim()))
            {
                MessageBox.Show("El campo de constraseña nueva esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCambiarEmail_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbNuevoMail.Text.Trim()) && Util.isEmailValido(tbNuevoMail.Text.Trim()))
            {
                if (MessageBox.Show("¿Seguro que desea cambiar su email?", "Cambiar Email",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    PERSONAL personal = FrmLogin.usuarioLogeado.Personal;
                    personal.EMAIL = tbNuevoMail.Text.Trim();
                    bool x = acciones.actualizarPersonal(personal);
                    if(x)
                    {
                        closeApp = false;
                        login.camposVacios();
                        login.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al modificar el email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
            else if (string.IsNullOrEmpty(tbNuevoMail.Text.Trim()))
            {
                MessageBox.Show("Campo de email vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!Util.isEmailValido(tbNuevoMail.Text.Trim()))
            {
                MessageBox.Show("Email invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCambiarCuentaOC_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbNroCuenta.Text))
            {
                CUEN_BANCARIA cuenta = new CUEN_BANCARIA();
                cuenta.ID_BANCO = ((ComboboxItem)cbBanco.SelectedItem).Value;
                cuenta.ID_TIPO_C_BANCARIA = ((ComboboxItem)cbTipoCuenta.SelectedItem).Value;
                cuenta.NUM_C_BANCARIA = tbNroCuenta.Text;
                bool x = acciones.actualizarCuentaBancariaUsing(cuenta, FrmLogin.usuarioLogeado.Personal.ID_PERSONAL);
                if (x)
                {
                    MessageBox.Show("Se ha actualizado la cuenta bancaria con exito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    tbNroCuenta.Text = "";
                }
                else
                    MessageBox.Show("No se pudo actualizar la cuenta bancaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("El numero de cuenta bancaria esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarUser_Click(object sender, EventArgs e)
        {
            InitGB(gbOpcionesUsuario);
            LoadCB();
            tbNroCuenta.Text = "";
        }

        private void LoadCB()
        {
            List<BANCO> bancos = acciones.ObtenerBancos();
            List<TIPO_C_BANCARIA> tiposcuenta = acciones.ObtenerTiposCuentaBancaria();
            cbBanco.Items.Clear();
            cbTipoCuenta.Items.Clear();
            foreach (BANCO x in bancos)
            {
                ComboboxItem cbi = new ComboboxItem();
                cbi.Value = x.ID_BANCO;
                cbi.Text = x.NOMBRE;
                cbBanco.Items.Add(cbi);
            }
            foreach (TIPO_C_BANCARIA x in tiposcuenta)
            {
                ComboboxItem cbi = new ComboboxItem();
                cbi.Value = x.ID_TIPO_C_BANCARIA;
                cbi.Text = x.NOM_C_BANCARIA;
                cbTipoCuenta.Items.Add(cbi);
            }
            if (cbBanco.Items.Count > 0)
            {
                cbBanco.SelectedIndex = 0;
            }
            else
            {
                btnCambiarCuentaOC.Enabled = false;
                MessageBox.Show("No se encontraron bancos para listar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cbTipoCuenta.Items.Count > 0)
            {
                cbTipoCuenta.SelectedIndex = 0;
            }
            else
            {
                btnCambiarCuentaOC.Enabled = false;
                MessageBox.Show("No se encontraron tipos de cuentas bancarias para listar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   INIT GB                                                                                                                    //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void InitGB(GroupBox x)
        {
            gbActualizarFichaMedica.Hide();
            gbOpcionesUsuario.Hide();
            gbAgendaDiaria.Hide();
            gbVerFichaMedica.Hide();
            gbActualizarFichaMedica.Hide();
            gbAbrirConsultaMedica.Hide();
            gbCerrarAtencionMedica.Hide();
            //
            //AGREGAR LOS OTROS GB QUE FALTEN
            //
            x.Show();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   AGENDA DIARIA                                                                                                              //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void agendaDiariaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InitGB(gbAgendaDiaria);
            CargarAgendaDiaria();
        }

        private void CargarAgendaDiaria()
        {
            List<ATENCION_AGEN> listaAtenciones = acciones.revisarAgendaDiaria(FrmLogin.usuarioLogeado.Personal.RUT, DateTime.Now);
            List<AgendaDiaria> agendaDiaria = new List<AgendaDiaria>();
            if (listaAtenciones.Count > 0)
            {
                
                foreach (ATENCION_AGEN x in listaAtenciones)
                {
                    bool estado = false;
                    if (x.ESTADO_ATEN.NOM_ESTADO_ATEN == "Cerrado")
                        estado = true;
                    agendaDiaria.Add(new AgendaDiaria(x.PRESTACION.NOM_PRESTACION, x.PACIENTE.NOMBRES_PACIENTE+" "+x.PACIENTE.APELLIDOS_PACIENTE, x.FECHOR.ToString(), estado));
                }
               
            }
            //TEST
            //agendaDiaria.Add(new AgendaDiaria("testttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttts", "testtttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttts", "testtttttttttttttttttttttttttttttttttttttttttttt", true));
            //TEST
            dgAgendaDiaria.DataSource = agendaDiaria;

        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   FORM CLOSED                                                                                                                //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void FrmMedico_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (closeApp)
                Application.Exit();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   VER FICHA MEDICA                                                                                                           //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void verFichaMédicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitGB(gbVerFichaMedica);
            tbRUNVFM.Text = "";
            tbVerificadorVFM.Text = "";
            lbNombreVFM.Text = "";
            lbEmailVFM.Text = "";
            lbRun.Text = "";
            lbSexoVFM.Text = "";
            lbFechaNacVFM.Text = "";
            dgEntradaVFM.Rows.Clear();
        }

        private void btnBuscarVFM_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbRUNVFM.Text.Trim()) && !string.IsNullOrEmpty(tbVerificadorVFM.Text.Trim()))
            {
                if (ValidaRut(tbRUNVFM.Text +"-"+ tbVerificadorVFM.Text))
                {
                    AccionesTerminal ac = new AccionesTerminal();
                    string rut = tbRUNVFM.Text.Replace(".", "").ToUpper();
                    paciente = ac.buscarPaciente(Int32.Parse(rut), tbVerificadorVFM.Text);
                    if (paciente != null)
                    {
                        //Ruta buena
                        lbNombreVFM.Text = "Nombre: "+paciente.NOMBRES_PACIENTE + " " + paciente.APELLIDOS_PACIENTE;
                        lbEmailVFM.Text = "Email: " + paciente.EMAIL_PACIENTE;
                        lbRun.Text = "RUN: " + paciente.RUT + "-" + paciente.DIGITO_VERIFICADOR;
                        lbSexoVFM.Text = "Sexo: " + paciente.SEXO;
                        lbFechaNacVFM.Text = "Fecha nacimiento: " + paciente.FEC_NAC.Value.ToShortDateString();

                        entradaList = new List<ENTRADA_FICHA>(paciente.ENTRADA_FICHA);
                        dgEntradaVFM.Rows.Clear();
                        if (entradaList != null)
                        {
                            foreach (ENTRADA_FICHA aux in entradaList)
                            {
                                dgEntradaVFM.Rows.Add(aux.NOMBRE_ENTRADA, "Ver", aux.TIPO_FICHA.NOM_TIPO_FICHA, aux.FECHA_ENTRADA.ToString());
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Paciente no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Run invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (string.IsNullOrEmpty(tbRUNVFM.Text.Trim()))
            {
                MessageBox.Show("Campo de RUN vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(tbRUNVFM.Text.Trim()))
            {
                MessageBox.Show("Campo de digito verificador vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool ValidaRut(string rut)
        {
            rut = rut.Replace(".", "").ToUpper();
            Regex expresion = new Regex("^([0-9]+-[0-9K])$");
            string dv = rut.Substring(rut.Length - 1, 1);
            if (!expresion.IsMatch(rut))
            {
                return false;
            }
            char[] charCorte = { '-' };
            string[] rutTemp = rut.Split(charCorte);
            if (dv != Digito(int.Parse(rutTemp[0])))
            {
                return false;
            }
            return true;
        }

        public static string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
        }

        private void dgEntradaVFM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >=0)
            {
                FrmContenidoEntrada frmCont = new FrmContenidoEntrada(entradaList[e.RowIndex].CONTENIDO_ENTRADA);
                frmCont.Show();
                frmCont.Activate();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   ACTUALIZAR FICHAS MEDICAS                                                                                                  //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void actualizarFichaMédicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitGB(gbActualizarFichaMedica);
            tbRUNAFM.Text = "";
            tbVerificadorAFM.Text = "";
            btnAgregarEntradaAFM.Enabled = false;
            lbNombreAFM.Text = "";
            lbEmailAFM.Text = "";
            lbRunAFM.Text = "";
            lbSexoAFM.Text = "";
            lbFechaNacAFM.Text = "";
            cbTipoEntradaAFM.Items.Clear();
        }

        private void btnBuscarAFM_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbRUNAFM.Text.Trim()) && !string.IsNullOrEmpty(tbVerificadorAFM.Text.Trim()))
            {
                if (ValidaRut(tbRUNAFM.Text + "-" + tbVerificadorAFM.Text))
                {
                    AccionesTerminal ac = new AccionesTerminal();
                    string rut = tbRUNAFM.Text.Replace(".", "").ToUpper();
                    paciente = ac.buscarPaciente(Int32.Parse(rut), tbVerificadorAFM.Text);
                    if (paciente != null)
                    {
                        //Ruta buena
                        lbNombreAFM.Text = "Nombre: " + paciente.NOMBRES_PACIENTE + " " + paciente.APELLIDOS_PACIENTE;
                        lbEmailAFM.Text = "Email: " + paciente.EMAIL_PACIENTE;
                        lbRunAFM.Text = "RUN: " + paciente.RUT + "-" + paciente.DIGITO_VERIFICADOR;
                        lbSexoAFM.Text = "Sexo: " + paciente.SEXO;
                        lbFechaNacAFM.Text = "Fecha nacimiento: " + paciente.FEC_NAC.Value.ToShortDateString();
                        bool x = InitComboBox();
                        if(x)
                            btnAgregarEntradaAFM.Enabled = true;
                        else
                        {
                            btnAgregarEntradaAFM.Enabled = false;
                            MessageBox.Show("No se pueden cargar los tipos de entrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Paciente no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Run invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (string.IsNullOrEmpty(tbRUNVFM.Text.Trim()))
            {
                MessageBox.Show("Campo de RUN vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(tbRUNVFM.Text.Trim()))
            {
                MessageBox.Show("Campo de digito verificador vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarEntradaAFM_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tbNombreEntradaAFM.Text.Trim()) && !string.IsNullOrEmpty(rtContenidoEntradaAFM.Text.Trim())){
                ENTRADA_FICHA aux = new ENTRADA_FICHA();
                aux.CONTENIDO_ENTRADA = rtContenidoEntradaAFM.Text;
                aux.NOMBRE_ENTRADA = tbNombreEntradaAFM.Text;
                aux.FECHA_ENTRADA = DateTime.Now;
                aux.ID_PACIENTE = paciente.ID_PACIENTE;
                aux.ID_TIPO_FICHA = ((ComboboxItem)cbTipoEntradaAFM.SelectedItem).Value;
                bool result = acciones.agregarEntradaFicha(aux);
                if (result)
                {
                    MessageBox.Show("Entrada ingresada con exito", "Entrada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    tbNombreEntradaAFM.Text = "";
                    rtContenidoEntradaAFM.Text = "";
                }
                else
                {
                    MessageBox.Show("La entrada no ha sido ingresada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (string.IsNullOrEmpty(tbNombreEntradaAFM.Text.Trim()))
            {
                MessageBox.Show("El nombre de entrada esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(rtContenidoEntradaAFM.Text.Trim()))
            {
                MessageBox.Show("El contenido de entrada esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private bool InitComboBox()
        {
            List<TIPO_FICHA> tipoFichas = acciones.ObtenerTiposFicha();
            cbTipoEntradaAFM.Items.Clear();
            if (tipoFichas != null)
            {
                if (tipoFichas.Count != 0)
                {
                    foreach (TIPO_FICHA tipo in tipoFichas)
                    {
                        ComboboxItem aux = new ComboboxItem();
                        aux.Text = tipo.NOM_TIPO_FICHA;
                        aux.Value = tipo.ID_TIPO_FICHA;
                        cbTipoEntradaAFM.Items.Add(aux);
                    }
                    cbTipoEntradaAFM.SelectedIndex = 0; 
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   ABRIR CONSULTA MEDICA                                                                                                      //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void abrirConsultaMédicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitGB(gbAbrirConsultaMedica);
        }

        private void actualizarBloques()
        {
            AccionesTerminal at = new AccionesTerminal();
            cmbHora_ACM.Items.Clear();
            PERSONAL personal = new PERSONAL();
            personal.ID_PERSONAL = (int)cmbPersonal_ACM.SelectedValue;
            PERS_MEDICO persMedico = at.buscarPersonalMedico(personal);

            DateTime dia = dtFecha_ACM.Value;

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
                cmbHora_ACM.Items.Add(item);
                cmbHora_ACM.SelectedIndex = 0;
            }
        }

        private void FrmMedico_Load(object sender, EventArgs e)
        {
            AccionesTerminal at = new AccionesTerminal();
            cmbEspecialidad_ACM.DataSource = null;
            cmbEspecialidad_ACM.ValueMember = "ID_ESPECIALIDAD";
            cmbEspecialidad_ACM.DisplayMember = "NOM_ESPECIALIDAD";
            cmbEspecialidad_ACM.DataSource = at.listaEspecialidad();
        }

        private void cmbEspecialidad_ACM_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccionesTerminal at = new AccionesTerminal();
            int idEspecialidad = (int)cmbEspecialidad_ACM.SelectedValue;

            cmbPersonal_ACM.DataSource = null;
            cmbPersonal_ACM.ValueMember = "ID_PERSONAL";
            cmbPersonal_ACM.DisplayMember = "NOMBREFULL";
            cmbPersonal_ACM.DataSource = at.listaPersonales(idEspecialidad);

            cmbPrestacion_ACM.DataSource = null;
            cmbPrestacion_ACM.ValueMember = "ID_PRESTACION";
            cmbPrestacion_ACM.DisplayMember = "NOM_PRESTACION";
            cmbPrestacion_ACM.DataSource = at.listaPrestaciones(idEspecialidad);
        }

        private void dtFecha_ACM_ValueChanged(object sender, EventArgs e)
        {
            actualizarBloques();
        }

        private void cmbPersonal_ACM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Util.isObjetoNulo(cmbPersonal_ACM.SelectedValue))
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

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            string mensajeCorrecto = "Atención agendada correctamente";
            string mensajeError = string.Empty;
            lblError_ACM.Visible = false;
            try
            {
                AccionesTerminal at = new AccionesTerminal();
                ATENCION_AGEN atencion = new ATENCION_AGEN();
                PACIENTE paciente = new PACIENTE();
                PRESTACION prestacion = new PRESTACION();
                ESTADO_ATEN estado = new ESTADO_ATEN();
                PERS_MEDICO personalMedico = new PERS_MEDICO();
                BLOQUE bloque = new BLOQUE();
                if (dtFecha_ACM.Value < DateTime.Today)
                    mensajeError = "La fecha de atención ha expirado";
                else
                {
                    using (var context = new CMHEntities())
                    {
                        estado = context.ESTADO_ATEN.Where(d => d.NOM_ESTADO_ATEN.ToUpper() == "VIGENTE").FirstOrDefault();
                        personalMedico = context.PERS_MEDICO.Find((int)cmbPersonal_ACM.SelectedValue);
                    }
                    if (txtRut_ACM.Text == string.Empty || txtDv_ACM.Text == string.Empty)
                        mensajeError = "Complete los campos de RUT";
                    else
                    {
                        paciente = at.buscarPaciente(int.Parse(txtRut_ACM.Text), txtDv_ACM.Text.ToUpper());
                        if (!Util.isObjetoNulo(paciente))
                        {
                            atencion.FECHOR = dtFecha_ACM.Value;
                            atencion.ID_PACIENTE = paciente.ID_PACIENTE;
                            atencion.ID_PRESTACION = (int)cmbPrestacion_ACM.SelectedValue;
                            atencion.ID_ESTADO_ATEN = estado.ID_ESTADO_ATEN;
                            atencion.ID_PERS_ATIENDE = (int)cmbPersonal_ACM.SelectedValue;
                            atencion.ID_BLOQUE = ((ComboboxItem)cmbHora_ACM.SelectedItem).Value;
                            atencion.OBSERVACIONES = rtObservacion.Text;
                            atencion.ID_PERS_SOLICITA = FrmLogin.usuarioLogeado.Personal.ID_PERSONAL;
                            if (!at.agendarAtencion(atencion))
                                mensajeError = "Error al agendar atención";
                            actualizarBloques();
                        }
                        else
                            mensajeError = "Paciente no encontrado";
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError = "Error al agendar atención";
            }
            if (mensajeError == string.Empty)
                MessageBox.Show(mensajeCorrecto, "Creada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   CERRAR ATENCION                                                                                                            //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cerrarConsultaMédicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitGB(gbCerrarAtencionMedica);
        }

        string file = string.Empty;

        //No médico
        /*
        private void btnArchivo_CAM_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog buscar = new OpenFileDialog();

                if (buscar.ShowDialog() == DialogResult.OK)
                {
                    //Ruta del archivo
                    rtArchivo_CAM.Text = buscar.FileName;
                    file = buscar.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al encontrar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */

        private void btnCrearResultado_CAM_Click(object sender, EventArgs e)
        {
            bool res;
            try
            {
                AccionesTerminal at = new AccionesTerminal();
               // ConversorBase64 conversor = new ConversorBase64();
                RES_ATENCION resultadoAtencion = new RES_ATENCION();
                resultadoAtencion.ATENCION_ABIERTA = false;
                resultadoAtencion.COMENTARIO = rtComentario_CAM.Text;

                resultadoAtencion.ID_ATENCION_AGEN = ((ComboboxItem)lstAtenciones_CAM.SelectedItem).Value;
                //string clob = conversor.convertirABase64(file);
               //resultadoAtencion.ARCHIVO_B64 = clob;
                //string extension  = Path.GetExtension(file).ToString().Substring(1, 3);
                //resultadoAtencion.EXT_ARCHIVO = extension;
                
                //Busque atención
                ATENCION_AGEN atencionAg = at.buscarAtencionAgendadaID(((ComboboxItem)lstAtenciones_CAM.SelectedItem).Value);
                //Actualice atención
                at.actualuzarAtencionAgendadaEstado(atencionAg);

                res = at.nuevoResultadoAtencion(resultadoAtencion);
                actualizarBloquesMisticos();
            }
            catch(Exception ex)
            {
                res = false;
            }

            if (res == true)
                MessageBox.Show("Creado el resultado de atención", "Creada", MessageBoxButtons.OK, MessageBoxIcon.None);
            else
                MessageBox.Show("Error al crear resultado de atención", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnBuscarPaciente_CAM_Click(object sender, EventArgs e)
        {
            AccionesTerminal at = new AccionesTerminal();
            bool res = false;
            // int rut = int.Parse(txtRutPaciente_CAM.Text);
            lblError_CAM.Visible = false;
            lstAtenciones_CAM.Items.Clear();
            try
            {
                if (!Util.rutValido(int.Parse(txtRutPaciente_CAM.Text), txtDV_CAM.Text))
                    res = false;
                else
                {
                    
                    List<ATENCION_AGEN> atenciones = at.listaAtencionesPagadasPersonalMedicoLogueado(int.Parse(txtRutPaciente_CAM.Text),FrmLogin.usuarioLogeado.Personal.PERS_MEDICO.FirstOrDefault().ID_PERSONAL_MEDICO).ToList();

                    if (atenciones.Count <= 0)
                    {
                        MessageBox.Show("No tiene ninguna atención", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    foreach (ATENCION_AGEN atencion in atenciones)
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Value = atencion.ID_ATENCION_AGEN;
                        item.Text = "Atención: " + atencion.ID_ATENCION_AGEN + " - Médico: " + atencion.PERS_MEDICO.PERSONAL.NOMBREFULL;
                        lstAtenciones_CAM.Items.Add(item);
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
                lblError_CAM.Visible = true;
                lblError_CAM.Text = "Error al buscar atenciones";
                lblError_CAM.ForeColor = System.Drawing.Color.Red;
            }
            if (Util.isObjetoNulo(lstAtenciones_CAM.SelectedValue))
            {
                btnCrearResultado_CAM.Enabled = false;
            }
            
        }

        private void actualizarBloquesMisticos()
        {
            AccionesTerminal at = new AccionesTerminal();
            lstAtenciones_CAM.Items.Clear();
            List<ATENCION_AGEN> atenciones = at.listaAtencionesPagadas(int.Parse(txtRutPaciente_CAM.Text)).ToList();

            
            foreach (ATENCION_AGEN atencion in atenciones)
            {
                ComboboxItem item = new ComboboxItem();
                item.Value = atencion.ID_ATENCION_AGEN;
                item.Text = "Atención: " + atencion.ID_ATENCION_AGEN + " - Médico: " + atencion.PERS_MEDICO.PERSONAL.NOMBREFULL;
                lstAtenciones_CAM.Items.Add(item);
            }
        }

        private void lstAtenciones_CAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCrearResultado_CAM.Enabled = true;
        }


    }
}
