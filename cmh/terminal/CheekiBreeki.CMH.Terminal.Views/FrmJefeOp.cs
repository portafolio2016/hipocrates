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
    public partial class FrmJefeOp : Form
    {
        private static AccionesTerminal acciones = new AccionesTerminal();
        FrmLogin login = null;
        bool closeApp;

        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   CONSTRUCTOR                                                                                                                //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FrmJefeOp(FrmLogin fLogin)
        {
            InitializeComponent();
            closeApp = true;
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

            #region ComboBox Cargo
            ComboboxItem item = new ComboboxItem();
            item.Text = "Médico";
            item.Value = 0;
            cbCargo_MP.Items.Add(item);

            ComboboxItem item2 = new ComboboxItem();
            item2.Text = "Enfermero";
            item2.Value = 1;
            cbCargo_MP.Items.Add(item2);

            ComboboxItem item3 = new ComboboxItem();
            item3.Text = "Tecnólogo";
            item3.Value = 2;
            cbCargo_MP.Items.Add(item3);

            ComboboxItem item4 = new ComboboxItem();
            item4.Text = "Operador";
            item4.Value = 3;
            cbCargo_MP.Items.Add(item4);

            ComboboxItem item5 = new ComboboxItem();
            item5.Text = "Jefe de Operador";
            item5.Value = 4;
            cbCargo_MP.Items.Add(item5);
            cbCargo_MP.SelectedIndex = 0;
            #endregion

            #region ComboBox Tipo cuenta y Banco
            AccionesTerminal at = new AccionesTerminal();
            cbBanco_MP.DataSource = null;
            cbBanco_MP.ValueMember = "ID_BANCO";
            cbBanco_MP.DisplayMember = "NOMBRE";
            cbBanco_MP.DataSource = at.ObtenerBancos();

            cbTipoCuenta_MP.DataSource = null;
            cbTipoCuenta_MP.ValueMember = "ID_TIPO_C_BANCARIA";
            cbTipoCuenta_MP.DisplayMember = "NOM_C_BANCARIA";
            cbTipoCuenta_MP.DataSource = at.ObtenerTiposCuentaBancaria();
            #endregion

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
        //   FORM CLOSED                                                                                                                //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void FrmJefeOp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (closeApp)
                Application.Exit();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   OPCIONES DE CUENTA                                                                                                         //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnModificarUser_Click(object sender, EventArgs e)
        {
            InitGB(gbOpcionesUsuario);
        }

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
                    if (x)
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

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   INIT GB                                                                                                                    //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void InitGB(GroupBox x)
        {

            gbOpcionesUsuario.Hide();
            gbLogPagoHonorarios.Hide();
            gbMantenedorPersonal.Hide();
            gbMantenerPrestacion.Hide();
            //
            //AGREGAR LOS OTROS GB QUE FALTEN
            //
            x.Show();
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   LOG PAGO HONORARIO                                                                                                         //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnBuscarLPH_Click(object sender, EventArgs e)
        {
            AccionesTerminal ac = new AccionesTerminal();
            dgLogs.Rows.Clear();
            List<LOGPAGOHONORARIO> logList = new List<LOGPAGOHONORARIO>();
            logList = ac.ObtenerLogPagoHonorario();
            if (logList != null)
            {
                if(logList.Count != 0){
                    foreach (LOGPAGOHONORARIO log in logList)
                    {
                        if (log.FECHOR.Value.Month == dtFechaLPH.Value.Month && log.FECHOR.Value.Year == dtFechaLPH.Value.Year)
                        {
                            dgLogs.Rows.Add(log.CUEN_BANCARIA.PERS_MEDICO.PERSONAL.NOMBREFULL, log.CUEN_BANCARIA.BANCO.NOMBRE, log.CUEN_BANCARIA.TIPO_C_BANCARIA.NOM_C_BANCARIA, log.CUEN_BANCARIA.NUM_C_BANCARIA, "$"+log.TOTAL);
                        }
                    }
                    if(dgLogs.Rows.Count <= 0){
                        MessageBox.Show("No hay pagos en la fecha indicada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No hay registro de pagos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error al obtener los pagos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logPagosHonorarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitGB(gbLogPagoHonorarios);
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   Mantenedor Personal                                                                                                        //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        int rutBuscar_MP = 0;

        private void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitGB(gbMantenedorPersonal);
        }

        #region Validaciones de campos
        private void txtCampo_KeyPress(object sender, KeyPressEventArgs e)
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
        #endregion

        private void btnCargarDatos_MP_Click(object sender, EventArgs e)
        {
            try
            {
                AccionesTerminal at = new AccionesTerminal();
                int rut = int.Parse(txtRutPersonal_MP.Text);
                rutBuscar_MP = int.Parse(txtRutPersonal_MP.Text);
                string verificar = txtVerificador_MP.Text;

                PERSONAL p1 = at.buscarPersonal(rut, verificar);

                txtNombres_MP.Text = p1.NOMBRES;
                txtApellidos_MP.Text = p1.APELLIDOS;
                txtEmail_MP.Text = p1.EMAIL;
                txtRutPersonalCargado_MP.Text = p1.RUT.ToString();
                txtVerificadorCargado_MP.Text = p1.VERIFICADOR;
                txtRemuneracion_MP.Text = p1.REMUNERACION.ToString();
                txtDescuento_MP.Text = p1.PORCENT_DESCUENTO.ToString();

                if (!Util.isObjetoNulo(p1.FUNCIONARIO.FirstOrDefault()))
                {
                    if (p1.FUNCIONARIO.FirstOrDefault().CARGO.NOMBRE_CARGO.ToUpper() == "OPERADOR")
                    {
                        cbCargo_MP.SelectedIndex = 3;
                        cbCargo_MP.Enabled = false;
                    }
                    else if (p1.FUNCIONARIO.FirstOrDefault().CARGO.NOMBRE_CARGO.ToUpper() == "JEFE DE OPERADOR")
                    {
                        cbCargo_MP.SelectedIndex = 4;
                        cbCargo_MP.Enabled = false;
                    }
                }
                else if (!Util.isObjetoNulo(p1.PERS_MEDICO.FirstOrDefault()))
                {
                    if (p1.PERS_MEDICO.FirstOrDefault().ESPECIALIDAD.NOM_ESPECIALIDAD.ToUpper() == "MEDICO")
                    {
                        cbCargo_MP.SelectedIndex = 0;
                        txtCuentaBanc_MP.Text = p1.PERS_MEDICO.FirstOrDefault().CUEN_BANCARIA.FirstOrDefault().NUM_C_BANCARIA;
                        cbTipoCuenta_MP.SelectedIndex = cbTipoCuenta_MP.FindStringExact(p1.PERS_MEDICO.FirstOrDefault().CUEN_BANCARIA.FirstOrDefault().TIPO_C_BANCARIA.NOM_C_BANCARIA);
                        cbBanco_MP.SelectedIndex = cbBanco_MP.FindStringExact(p1.PERS_MEDICO.FirstOrDefault().CUEN_BANCARIA.FirstOrDefault().BANCO.NOMBRE);
                        cbCargo_MP.Enabled = false;
                    }
                    else if (p1.PERS_MEDICO.FirstOrDefault().ESPECIALIDAD.NOM_ESPECIALIDAD.ToUpper() == "ENFERMERO")
                    {
                        cbCargo_MP.SelectedIndex = 1;
                        cbCargo_MP.Enabled = false;
                    }
                    else if (p1.PERS_MEDICO.FirstOrDefault().ESPECIALIDAD.NOM_ESPECIALIDAD.ToUpper() == "TECNOLOGO")
                    {
                        cbCargo_MP.SelectedIndex = 2;
                        cbCargo_MP.Enabled = false;
                    }

                }


                btnGuardar_MP.Enabled = true;
                btnEliminar_MP.Enabled = true;
                btnRegistrar_MP.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Campo Run vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrearPersonal_MP_Click(object sender, EventArgs e)
        {
            cbCargo_MP.Enabled = true;
            limpiarCampos_MP();
            btnRegistrar_MP.Enabled = true;
            btnGuardar_MP.Enabled = false;
            btnEliminar_MP.Enabled = false;
        }


        #region Capturar y limpiar datos 
        private void limpiarCampos_MP()
        {
            txtNombres_MP.Text = string.Empty;
            txtApellidos_MP.Text = string.Empty;
            txtEmail_MP.Text = string.Empty;
            txtContrasena_MP.Text = string.Empty;
            txtRutPersonalCargado_MP.Text = string.Empty;
            txtVerificadorCargado_MP.Text = string.Empty;
            txtRemuneracion_MP.Text = string.Empty;
            txtDescuento_MP.Text = string.Empty;
            txtCuentaBanc_MP.Text = string.Empty;

        }

        
        #endregion

        private void btnRegistrar_MP_Click(object sender, EventArgs e)
        {
            try
            {
                AccionesTerminal at = new AccionesTerminal();
                PERSONAL p1 = new PERSONAL();

                //CapturarDatos
                p1.NOMBRES = txtNombres_MP.Text;
                p1.APELLIDOS = txtApellidos_MP.Text;
                p1.EMAIL = txtEmail_MP.Text;
                p1.HASHED_PASS = Util.hashMD5(txtContrasena_MP.Text);
                p1.RUT = int.Parse(txtRutPersonalCargado_MP.Text);
                p1.VERIFICADOR = txtVerificadorCargado_MP.Text;
                p1.REMUNERACION = int.Parse(txtRemuneracion_MP.Text);
                p1.PORCENT_DESCUENTO = byte.Parse(txtDescuento_MP.Text);
                p1.ACTIVO = true;

                if (!Util.isEmailValido(p1.EMAIL))
                {
                    throw new Exception();
                }

                if (!Util.rutValido(p1.RUT,p1.VERIFICADOR))
                {
                    throw new Exception();
                }

                int privi = ((ComboboxItem)cbCargo_MP.SelectedItem).Value;
                if (privi == 0 && (txtCuentaBanc_MP.Text=="" || (txtCuentaBanc_MP.Text == string.Empty))) 
                {
                    throw new Exception();
                }
                
                p1.ID_PERSONAL = at.nuevoPersonalId(p1);

                if (p1.ID_PERSONAL == 0)
                {
                    throw new Exception();
                }
                
                /*
                if (((ComboboxItem)cbCargo_MP.SelectedItem).Text == "Médico")
                {
                    string cuentaBancaria = txtCuentaBanc_MP.Text;

                }
                */
                
                using (var context = new CMHEntities())
                {
                    switch (privi)
                    {
                        case 0: // Médico
                            
                            PERS_MEDICO persMedico = new PERS_MEDICO();
                            persMedico.ID_ESPECIALIDAD = context.ESPECIALIDAD.Where(d => d.NOM_ESPECIALIDAD.ToUpper() == "MEDICO").FirstOrDefault().ID_ESPECIALIDAD;
                            persMedico.ID_PERSONAL = p1.ID_PERSONAL;
                            persMedico.ID_PERSONAL_MEDICO = at.nuevoPersonalMedicoID(persMedico);
                            at.asignarBloques(persMedico);
                            CUEN_BANCARIA cuentaB = new CUEN_BANCARIA();
                            cuentaB.ID_PERS_MEDICO = persMedico.ID_PERSONAL_MEDICO;
                            cuentaB.ID_TIPO_C_BANCARIA = ((TIPO_C_BANCARIA)cbTipoCuenta_MP.SelectedItem).ID_TIPO_C_BANCARIA;
                            
                            cuentaB.NUM_C_BANCARIA = txtCuentaBanc_MP.Text;
                            cuentaB.ID_BANCO = ((BANCO)cbBanco_MP.SelectedItem).ID_BANCO;
                            at.crearCuentaBancaria(cuentaB);

                            break;

                        case 1: // Enfermero
                            PERS_MEDICO persEnfermero = new PERS_MEDICO();
                            persEnfermero.ID_ESPECIALIDAD = context.ESPECIALIDAD.Where(d => d.NOM_ESPECIALIDAD.ToUpper() == "ENFERMERO").FirstOrDefault().ID_ESPECIALIDAD;
                            persEnfermero.ID_PERSONAL = p1.ID_PERSONAL;
                            at.nuevoPersonalMedico(persEnfermero);
                            at.asignarBloques(persEnfermero);

                            break;

                        case 2: // Tecnólogo
                            PERS_MEDICO persTecnologo = new PERS_MEDICO();
                            persTecnologo.ID_ESPECIALIDAD = context.ESPECIALIDAD.Where(d => d.NOM_ESPECIALIDAD.ToUpper() == "TECNOLOGO").FirstOrDefault().ID_ESPECIALIDAD;
                            persTecnologo.ID_PERSONAL = p1.ID_PERSONAL;
                            at.nuevoPersonalMedico(persTecnologo);
                            at.asignarBloques(persTecnologo);
                            break;

                        case 3: // Operador
                            FUNCIONARIO funcOperador = new FUNCIONARIO();
                            funcOperador.ID_CARGO_FUNCI = context.CARGO.Where(d => d.NOMBRE_CARGO.ToUpper() == "OPERADOR").FirstOrDefault().ID_CARGO_FUNCI;
                            funcOperador.ID_PERSONAL = p1.ID_PERSONAL;
                            at.nuevoFuncionario(funcOperador);
                            break;

                        case 4: // Jefe de operador
                            FUNCIONARIO funcJefeOperador = new FUNCIONARIO();
                            funcJefeOperador.ID_CARGO_FUNCI = context.CARGO.Where(d => d.NOMBRE_CARGO.ToUpper() == "JEFE DE OPERADOR").FirstOrDefault().ID_CARGO_FUNCI;
                            funcJefeOperador.ID_PERSONAL = p1.ID_PERSONAL;
                            at.nuevoFuncionario(funcJefeOperador);
                            break;
                    }
                }

                MessageBox.Show("¡Personal creado exitosamente!", "Personal", MessageBoxButtons.OK, MessageBoxIcon.None);
                limpiarCampos_MP();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void cbCargo_MP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboboxItem)cbCargo_MP.SelectedItem).Text == "Médico")
            {
                txtCuentaBanc_MP.Enabled = true;
                cbTipoCuenta_MP.Enabled = true;
                cbBanco_MP.Enabled = true;
            }
            else
            {
                txtCuentaBanc_MP.Enabled = false;
                cbTipoCuenta_MP.Enabled = false;
                cbBanco_MP.Enabled = false;
            }
                
        }

        private void btnGuardar_MP_Click(object sender, EventArgs e)
        {
            try
            {
                AccionesTerminal at = new AccionesTerminal();
                PERSONAL p1 = at.buscarPersonal(rutBuscar_MP);

                p1.NOMBRES = txtNombres_MP.Text;
                p1.APELLIDOS = txtApellidos_MP.Text;
                p1.EMAIL = txtEmail_MP.Text;
                if (txtContrasena_MP.Text != "" || txtContrasena_MP.Text != string.Empty)
                {
                    p1.HASHED_PASS = Util.hashMD5(txtContrasena_MP.Text);
                }
                p1.RUT = int.Parse(txtRutPersonalCargado_MP.Text);
                p1.VERIFICADOR = txtVerificadorCargado_MP.Text;
                p1.REMUNERACION = int.Parse(txtRemuneracion_MP.Text);
                p1.PORCENT_DESCUENTO = byte.Parse(txtDescuento_MP.Text);
                

                if (!Util.isEmailValido(p1.EMAIL))
                {
                    throw new Exception();
                }

                if (!Util.rutValido(p1.RUT, p1.VERIFICADOR))
                {
                    throw new Exception();
                }

                at.actualizarPersonal(p1, int.Parse(txtRutPersonal_MP.Text));
                
                if (((ComboboxItem)cbCargo_MP.SelectedItem).Value == 0) //Medico
                {
                    CUEN_BANCARIA cuentaBancariaMedica = new CUEN_BANCARIA();
                    cuentaBancariaMedica.ID_PERS_MEDICO = p1.PERS_MEDICO.FirstOrDefault().ID_PERSONAL_MEDICO;
                    cuentaBancariaMedica.ID_TIPO_C_BANCARIA = ((TIPO_C_BANCARIA)cbTipoCuenta_MP.SelectedItem).ID_TIPO_C_BANCARIA;
                    cuentaBancariaMedica.NUM_C_BANCARIA = txtCuentaBanc_MP.Text;
                    cuentaBancariaMedica.ID_BANCO = ((BANCO)cbBanco_MP.SelectedItem).ID_BANCO;
                    at.actualizarCuentaBancaria(cuentaBancariaMedica);
                }

                MessageBox.Show("¡Personal actualizado exitosamente!", "Personal", MessageBoxButtons.OK, MessageBoxIcon.None);
                limpiarCampos_MP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error actualizar datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           


        }

        private void btnEliminar_MP_Click(object sender, EventArgs e)
        {
            try
            {
                AccionesTerminal at = new AccionesTerminal();
                PERSONAL p1 = at.buscarPersonal(rutBuscar_MP);
                at.desactivarPersonal(p1);
                limpiarCampos_MP();
                txtRutPersonal_MP.Text = string.Empty;
                txtVerificador_MP.Text = string.Empty;
                MessageBox.Show("¡Personal desactivado exitosamente!", "Personal", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception ex) 
            { 
                 MessageBox.Show("Error Desactivar personal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   MANTENEDOR PRESTACION                                                                                                      //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static List<EQUIPO_REQ> equiposReq = new List<EQUIPO_REQ>();

        private void prestaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitGB(gbMantenerPrestacion);
            InitMantenerPrestacion();
            InitTipoPrestacion();
            acciones = new AccionesTerminal();
        }

        #region InitMantenerPrestacion
        private void InitMantenerPrestacion()
        {
            tbCodigoPrestacionMPre.Text = "";
            tbNombrePrestacionMPre.Text = "";
            tbPrecioPrestacionMPre.Text = "";
            tbCodigoMPre.Text = "";
            cbPrestacionesMPre.Items.Clear();
            cbTipoPrestacionMPre.Items.Clear();
            lbxEquiposMPre.Items.Clear();
            lbxEquiposPrestacionMPre.Items.Clear();
            btnRegistrarMPre.Enabled = false;
            btnGuardarMpre.Enabled = false;
            btnEliminarMPre.Enabled = false;
            btnCargarPorLista.Enabled = false;
            AccionesTerminal ac = new AccionesTerminal();
            List<PRESTACION> prestaciones = ac.listaPrestaciones();
            if (prestaciones == null)
                prestaciones = new List<PRESTACION>();
            foreach (PRESTACION x in prestaciones)
            {
                ComboboxItem cbi = new ComboboxItem();
                cbi.Text = x.NOM_PRESTACION;
                cbi.Value = x.ID_PRESTACION;
                cbPrestacionesMPre.Items.Add(cbi);
            }
            if (prestaciones.Count > 0)
            {
                btnCargarPorLista.Enabled = true;
                cbPrestacionesMPre.SelectedIndex = 0;
            }
        }
        private void InitTipoPrestacion()
        {
            AccionesTerminal ac = new AccionesTerminal();
            List<TIPO_PRES> tipoPrestaciones = ac.listaTipoPrestaciones();
            if (tipoPrestaciones == null)
                tipoPrestaciones = new List<TIPO_PRES>();
            foreach (TIPO_PRES x in tipoPrestaciones)
            {
                ComboboxItem cbi = new ComboboxItem();
                cbi.Text = x.NOM_TIPO_PREST;
                cbi.Value = x.ID_TIPO_PRESTACION;
                cbTipoPrestacionMPre.Items.Add(cbi);
            }
            if (tipoPrestaciones.Count > 0)
            {
                btnCargarPorLista.Enabled = true;
                cbTipoPrestacionMPre.SelectedIndex = 0;
            }
            else
            {
                btnRegistrarMPre.Enabled = false;
                btnGuardarMpre.Enabled = false;
                btnEliminarMPre.Enabled = false;
                btnCargarPorLista.Enabled = false;
                btnCargarPorCodigoMPre.Enabled = false;
                btnNuevaPrestacionMPre.Enabled = false;
                MessageBox.Show("No se pueden crear prestaciones si no existen tipos de prestación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        //NUEVO
        private void btnNuevaPrestacionMPre_Click(object sender, EventArgs e)
        {
            lbxEquiposMPre.Items.Clear();
            lbxEquiposPrestacionMPre.Items.Clear();
            tbCodigoPrestacionMPre.Text = "";
            tbNombrePrestacionMPre.Text = "";
            tbPrecioPrestacionMPre.Text = "";
            tbCodigoMPre.Text = "";
            tbCodigoMPre.Enabled = true;
            if (cbTipoPrestacionMPre.Items.Count > 0)
            {
                cbTipoPrestacionMPre.SelectedIndex = 0;
            }
            btnRegistrarMPre.Enabled = true;

            List<TIPO_EQUIPO> tipoEquipos = acciones.listaTipoEquipos();
            if (tipoEquipos == null)
                tipoEquipos = new List<TIPO_EQUIPO>();
            foreach (TIPO_EQUIPO x in tipoEquipos)
            {
                ComboboxItem cbi = new ComboboxItem();
                cbi.Text = x.NOMBRE_TIPO_EQUIPO;
                cbi.Value = x.ID_TIPO_EQUIPO;
                lbxEquiposMPre.Items.Add(cbi);
            }
        }

        //>>
        private void btnAddMPre_Click(object sender, EventArgs e)
        {
            EQUIPO_REQ equipoReq = new EQUIPO_REQ();
            try{
                bool existe = false;
                foreach (EQUIPO_REQ x in equiposReq)
                {
                    if (((ComboboxItem)lbxEquiposMPre.SelectedItem).Value == x.ID_TIPO_EQUIPO)
                    {
                        x.CANTIDAD++;
                        existe = true;
                    }
                }
                if (!existe)
                {
                    TIPO_EQUIPO tipoEquip = new TIPO_EQUIPO();
                    tipoEquip.ID_TIPO_EQUIPO = ((ComboboxItem)lbxEquiposMPre.SelectedItem).Value;
                    tipoEquip.NOMBRE_TIPO_EQUIPO = ((ComboboxItem)lbxEquiposMPre.SelectedItem).Text;
                    equipoReq.CANTIDAD = 1;
                    equipoReq.ID_TIPO_EQUIPO = tipoEquip.ID_TIPO_EQUIPO;
                    equipoReq.TIPO_EQUIPO = tipoEquip;
                    equiposReq.Add(equipoReq);
                }

                RefrescarEquiposPrestacion();
            }catch(Exception){
                MessageBox.Show("No se ha seleccionado un equipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //<<
        private void btnRemoveMPre_Click(object sender, EventArgs e)
        {
            try
            {
                EQUIPO_REQ equipoReq = null;
                foreach (EQUIPO_REQ x in equiposReq)
                {
                    if (((ComboboxItem)lbxEquiposPrestacionMPre.SelectedItem).Value == x.ID_TIPO_EQUIPO)
                    {
                        x.CANTIDAD--;
                        if(x.CANTIDAD == 0){
                            equipoReq = x;
                        }
                    }
                }
                if (equipoReq != null)
                    equiposReq.Remove(equipoReq);
                RefrescarEquiposPrestacion(((ComboboxItem)lbxEquiposPrestacionMPre.SelectedItem).Value);
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha seleccionado un equipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Refrescar equipos
        private void RefrescarEquiposPrestacion()
        {
            lbxEquiposPrestacionMPre.Items.Clear();
            foreach (EQUIPO_REQ x in equiposReq)
            {
                ComboboxItem cbi = new ComboboxItem();
                cbi.Text = "[" + x.CANTIDAD + "]  " + x.TIPO_EQUIPO.NOMBRE_TIPO_EQUIPO;
                cbi.Value = x.TIPO_EQUIPO.ID_TIPO_EQUIPO;
                lbxEquiposPrestacionMPre.Items.Add(cbi);
            }
        }
        private void RefrescarEquiposPrestacion(int id)
        {
            lbxEquiposPrestacionMPre.Items.Clear();
            int index = 0;
            int indexId = 0;
            foreach (EQUIPO_REQ x in equiposReq)
            {
                ComboboxItem cbi = new ComboboxItem();
                cbi.Text = "[" + x.CANTIDAD + "]  " + x.TIPO_EQUIPO.NOMBRE_TIPO_EQUIPO;
                cbi.Value = x.TIPO_EQUIPO.ID_TIPO_EQUIPO;
                lbxEquiposPrestacionMPre.Items.Add(cbi);
                if (id == cbi.Value)
                    indexId = index;
                index++;
            }
            if (equiposReq.Count > 0)
                lbxEquiposPrestacionMPre.SelectedIndex = indexId;
        }

        //REGISTRAR
        private void btnRegistrarMPre_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbNombrePrestacionMPre.Text.Trim()) && !string.IsNullOrEmpty(tbPrecioPrestacionMPre.Text.Trim()) && !string.IsNullOrEmpty(tbCodigoMPre.Text.Trim()))
            {
                int precio;
                if (Int32.TryParse(tbPrecioPrestacionMPre.Text, out precio))
                {
                    if(!acciones.CodigoPrestacionExiste(tbCodigoMPre.Text.Trim())){
                        PRESTACION prestacion = new PRESTACION();
                        prestacion.ID_ESPECIALIDAD = ((ComboboxItem)cbTipoPrestacionMPre.SelectedItem).Value;//Funciona siempre y cuando tenga el mismo orden de index que con tipo prestacion
                        prestacion.ID_TIPO_PRESTACION = ((ComboboxItem)cbTipoPrestacionMPre.SelectedItem).Value;
                        prestacion.NOM_PRESTACION = tbNombrePrestacionMPre.Text;
                        prestacion.CODIGO_PRESTACION = tbCodigoMPre.Text;
                        prestacion.PRECIO_PRESTACION = precio;
                        prestacion.ACTIVO = true;
                        bool x = acciones.CrearPrestacion(prestacion, equiposReq);
                        if (x)
                        {
                            InitMantenerPrestacion();
                            InitTipoPrestacion();
                            acciones = new AccionesTerminal();
                            MessageBox.Show("Prestación ingresada con exito", "Prestació ingresada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido registrar la prestación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Una prestación ya existe con ese codigo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("El valor del precio no es numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(tbNombrePrestacionMPre.Text.Trim())) 
            {
                MessageBox.Show("Campo nombre vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(tbPrecioPrestacionMPre.Text.Trim()))
            {
                MessageBox.Show("Campo precio vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(string.IsNullOrEmpty(tbCodigoMPre.Text.Trim()))
            {
                MessageBox.Show("Campo código vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //CARGAR X LISTA
        private void btnCargarPorLista_Click(object sender, EventArgs e)
        {
            PRESTACION pres = acciones.buscarPrestacionMedica(((ComboboxItem)cbPrestacionesMPre.SelectedItem).Value);
            if (pres != null)
            {
                btnRegistrarMPre.Enabled = false;
                btnGuardarMpre.Enabled = true;
                btnEliminarMPre.Enabled = true;
                tbCodigoMPre.Enabled = false;
                tbNombrePrestacionMPre.Text = pres.NOM_PRESTACION;
                tbPrecioPrestacionMPre.Text = pres.PRECIO_PRESTACION.ToString();
                tbCodigoMPre.Text = pres.CODIGO_PRESTACION;
                cbTipoPrestacionMPre.SelectedIndex = (int)pres.ID_TIPO_PRESTACION - 1;

                lbxEquiposMPre.Items.Clear();
                List<TIPO_EQUIPO> tipoEquipos = acciones.listaTipoEquipos();
                if (tipoEquipos == null)
                    tipoEquipos = new List<TIPO_EQUIPO>();
                foreach (TIPO_EQUIPO x in tipoEquipos)
                {
                    ComboboxItem cbi = new ComboboxItem();
                    cbi.Text = x.NOMBRE_TIPO_EQUIPO;
                    cbi.Value = x.ID_TIPO_EQUIPO;
                    lbxEquiposMPre.Items.Add(cbi);
                }

                equiposReq = new List<EQUIPO_REQ>(pres.EQUIPO_REQ);
                RefrescarEquiposPrestacion();
            }
            else
            {
                MessageBox.Show("No se pudo encontrar la prestación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarMpre_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbNombrePrestacionMPre.Text.Trim()) && !string.IsNullOrEmpty(tbPrecioPrestacionMPre.Text.Trim()) && !string.IsNullOrEmpty(tbCodigoMPre.Text.Trim()))
            {
                int precio;
                if (Int32.TryParse(tbPrecioPrestacionMPre.Text, out precio))
                {
                    PRESTACION prestacion = new PRESTACION();
                    prestacion.ID_ESPECIALIDAD = ((ComboboxItem)cbTipoPrestacionMPre.SelectedItem).Value;//Funciona siempre y cuando tenga el mismo orden de index que con tipo prestacion
                    prestacion.ID_TIPO_PRESTACION = ((ComboboxItem)cbTipoPrestacionMPre.SelectedItem).Value;
                    prestacion.NOM_PRESTACION = tbNombrePrestacionMPre.Text;
                    prestacion.CODIGO_PRESTACION = tbCodigoMPre.Text;
                    prestacion.PRECIO_PRESTACION = precio;
                    prestacion.ACTIVO = true;
                    bool x = acciones.ActualizarPrestacion(prestacion, equiposReq);
                    if (x)
                    {
                        InitMantenerPrestacion();
                        InitTipoPrestacion();
                        acciones = new AccionesTerminal();
                        MessageBox.Show("Prestación modificada con exito", "Prestació ingresada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido registrar la prestación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("El valor del precio no es numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(tbNombrePrestacionMPre.Text.Trim()))
            {
                MessageBox.Show("Campo nombre vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(tbPrecioPrestacionMPre.Text.Trim()))
            {
                MessageBox.Show("Campo precio vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(tbCodigoMPre.Text.Trim()))
            {
                MessageBox.Show("Campo código vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCargarPorCodigoMPre_Click(object sender, EventArgs e)
        {
            PRESTACION pres = acciones.buscarPrestacionMedica(tbCodigoPrestacionMPre.Text.Trim());
            if (pres != null)
            {
                btnRegistrarMPre.Enabled = false;
                btnGuardarMpre.Enabled = true;
                btnEliminarMPre.Enabled = true;
                tbCodigoMPre.Enabled = false;
                tbNombrePrestacionMPre.Text = pres.NOM_PRESTACION;
                tbPrecioPrestacionMPre.Text = pres.PRECIO_PRESTACION.ToString();
                tbCodigoMPre.Text = pres.CODIGO_PRESTACION;
                cbTipoPrestacionMPre.SelectedIndex = (int)pres.ID_TIPO_PRESTACION - 1;

                lbxEquiposMPre.Items.Clear();
                List<TIPO_EQUIPO> tipoEquipos = acciones.listaTipoEquipos();
                if (tipoEquipos == null)
                    tipoEquipos = new List<TIPO_EQUIPO>();
                foreach (TIPO_EQUIPO x in tipoEquipos)
                {
                    ComboboxItem cbi = new ComboboxItem();
                    cbi.Text = x.NOMBRE_TIPO_EQUIPO;
                    cbi.Value = x.ID_TIPO_EQUIPO;
                    lbxEquiposMPre.Items.Add(cbi);
                }

                equiposReq = new List<EQUIPO_REQ>(pres.EQUIPO_REQ);
                RefrescarEquiposPrestacion();
            }
            else
            {
                MessageBox.Show("No se pudo encontrar la prestación por codigo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Eliminar
        private void btnEliminarMPre_Click(object sender, EventArgs e)
        {
            PRESTACION pres = acciones.buscarPrestacionMedica(tbCodigoMPre.Text.Trim());
            bool x = acciones.EliminarPrestacion(pres);
            if (x)
            {
                InitMantenerPrestacion();
                InitTipoPrestacion();
                acciones = new AccionesTerminal();
                MessageBox.Show("Prestación eliminada con exito", "Prestació ingresada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("No se ha podido eliminar la prestación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
