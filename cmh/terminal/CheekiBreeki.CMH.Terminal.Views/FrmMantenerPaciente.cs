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
    public partial class FrmMantenerPaciente : Form
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
        public FrmMantenerPaciente(FrmLogin fLogin)
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

            #region ComboBox Sexo
            ComboboxItem item = new ComboboxItem();
            item.Text = "Masculino";
            item.Value = 0;
            cbSexo_Pac.Items.Add(item);

            ComboboxItem item1 = new ComboboxItem();
            item1.Text = "Femenino";
            item1.Value = 1;
            cbSexo_Pac.Items.Add(item1);
            cbSexo_Pac.SelectedIndex = 0;
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
            gbMantenedorPaciente.Hide();
            x.Show();
        }

        #region Barra menú
        private void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMantenerPersonal frmMantenerPersonal = new FrmMantenerPersonal(login);
            frmMantenerPersonal.Show();
            frmMantenerPersonal.Activate();
            this.Hide();
        }

        private void pacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMantenerPaciente frmMantenerPaciente = new FrmMantenerPaciente(login);
            frmMantenerPaciente.Show();
            frmMantenerPaciente.Activate();
            this.Hide();
        }
        #endregion

        #region Limpiar datos
        public void limpiarDatos()
        {
            txtNombres_Pac.Text = string.Empty;
            txtApellidos_Pac.Text = string.Empty;
            txtEmail_Pac.Text = string.Empty;
            txtContrasena_Pac.Text = string.Empty;
            txtRutCargado_Pac.Text = string.Empty;
            txtVerificadorCargado_Pac.Text = string.Empty;
            dtpFechaNac_Pac.Value = (DateTime) DateTime.Today;

            txtRutPaciente_Pac.Text = string.Empty;
            txtVerificador_Pac.Text = string.Empty;

        }
        #endregion 

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

        int rutBuscar = 0;
        string verificarBuscar = string.Empty;

        private void btnCargarPaciente_Click(object sender, EventArgs e)
        {
            try
            {
                AccionesTerminal at = new AccionesTerminal();
                int rut = int.Parse(txtRutPaciente_Pac.Text);
                rutBuscar = int.Parse(txtRutPaciente_Pac.Text);
                string verificar = txtVerificador_Pac.Text;
                verificarBuscar = txtVerificador_Pac.Text;

                PACIENTE p1 = at.buscarPaciente(rut, verificar);
                txtNombres_Pac.Text = p1.NOMBRES_PACIENTE;
                txtApellidos_Pac.Text = p1.APELLIDOS_PACIENTE;
                txtEmail_Pac.Text = p1.EMAIL_PACIENTE;
                txtRutCargado_Pac.Text = p1.RUT.ToString();
                txtVerificadorCargado_Pac.Text = p1.DIGITO_VERIFICADOR;

                if (p1.SEXO.ToUpper() == "M")
                {
                    cbSexo_Pac.SelectedIndex = 0;
                }
                else if (p1.SEXO.ToUpper() == "F")
                {
                    cbSexo_Pac.SelectedIndex = 1;
                }

                dtpFechaNac_Pac.Text = p1.FEC_NAC.ToString();

                btnRegistrar_Pac.Enabled = false;
                btnGuardar.Enabled = true;
                btnEliminar.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar paciente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoPaciente_Click(object sender, EventArgs e)
        {
            limpiarDatos();
            btnRegistrar_Pac.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnRegistrar_Pac_Click(object sender, EventArgs e)
        {
            try
            {
                AccionesTerminal at = new AccionesTerminal();
                PACIENTE pac = new PACIENTE();

                //capturando datos
                pac.NOMBRES_PACIENTE = txtNombres_Pac.Text;
                pac.APELLIDOS_PACIENTE = txtApellidos_Pac.Text;
                pac.EMAIL_PACIENTE = txtEmail_Pac.Text;
                pac.HASHED_PASS = Util.hashMD5(txtContrasena_Pac.Text);
                pac.RUT = int.Parse(txtRutCargado_Pac.Text);
                pac.DIGITO_VERIFICADOR = txtVerificadorCargado_Pac.Text;
                pac.FEC_NAC = DateTime.Parse(dtpFechaNac_Pac.Text);
                pac.ACTIVO = true;

                if (((ComboboxItem)cbSexo_Pac.SelectedItem).Value == 0)
                {
                    pac.SEXO = "M";
                }
                else if (((ComboboxItem)cbSexo_Pac.SelectedItem).Value == 1)
                {
                    pac.SEXO = "F";
                }

                if (!Util.isEmailValido(pac.EMAIL_PACIENTE))
                {
                    throw new Exception();
                }

                if (!Util.rutValido(pac.RUT, pac.DIGITO_VERIFICADOR))
                {
                    throw new Exception();
                }

                at.nuevoPaciente(pac);

                MessageBox.Show("¡Paciente creado exitosamente!", "Personal", MessageBoxButtons.OK, MessageBoxIcon.None);
                limpiarDatos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear paciente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                AccionesTerminal at = new AccionesTerminal();
                PACIENTE pac = at.buscarPaciente(rutBuscar, verificarBuscar);

                pac.NOMBRES_PACIENTE = txtNombres_Pac.Text;
                pac.APELLIDOS_PACIENTE = txtApellidos_Pac.Text;
                pac.EMAIL_PACIENTE = txtEmail_Pac.Text;
                if (txtContrasena_Pac.Text != "" || txtContrasena_Pac.Text != string.Empty)
                {
                    pac.HASHED_PASS = Util.hashMD5(txtContrasena_Pac.Text);
                }
                pac.RUT = int.Parse(txtRutCargado_Pac.Text);
                pac.DIGITO_VERIFICADOR = txtVerificadorCargado_Pac.Text;
                pac.FEC_NAC = DateTime.Parse(dtpFechaNac_Pac.Text);
                pac.ACTIVO = true;

                if (((ComboboxItem)cbSexo_Pac.SelectedItem).Value == 0)
                {
                    pac.SEXO = "M";
                }
                else if (((ComboboxItem)cbSexo_Pac.SelectedItem).Value == 1)
                {
                    pac.SEXO = "F";
                }

                if (!Util.isEmailValido(pac.EMAIL_PACIENTE))
                {
                    throw new Exception();
                }

                if (!Util.rutValido(pac.RUT, pac.DIGITO_VERIFICADOR))
                {
                    throw new Exception();
                }

                at.actualizarPaciente(pac);
                limpiarDatos();
                MessageBox.Show("¡Personal actualizado exitosamente!", "Personal", MessageBoxButtons.OK, MessageBoxIcon.None);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error actualizar datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                AccionesTerminal at = new AccionesTerminal();
                PACIENTE pac = at.buscarPaciente(rutBuscar, verificarBuscar);
                //Desactivar
                if (pac.ACTIVO == true)//Se desactiva
                {
                    limpiarDatos();
                    at.desactivarPaciente(pac);
                    MessageBox.Show("¡Personal desactivado exitosamente!", "Personal", MessageBoxButtons.OK, MessageBoxIcon.None);

                }
                else // Se Muestra un mensaje
                {
                    MessageBox.Show("¡Personal está desactivado!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Desactivar personal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
