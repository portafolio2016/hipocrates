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

            #region ComboBox
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
            cbCargo_MP.Items.Add(item);
            cbCargo_MP.SelectedIndex = 0;
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
            gbMantenedorPersonal.Hide();

            //
            //AGREGAR LOS OTROS GB QUE FALTEN
            //
            x.Show();
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   Mantenedor Personal                                                                                                        //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
                string verificar = txtVerificador_MP.Text;

                PERSONAL p1 = at.buscarPersonal(rut, verificar);

                txtNombres_MP.Text = p1.NOMBRES;
                txtApellidos_MP.Text = p1.APELLIDOS;
                txtEmail_MP.Text = p1.EMAIL;
                txtRutPersonalCargado_MP.Text = p1.RUT.ToString();
                txtVerificadorCargado_MP.Text = p1.VERIFICADOR;
                txtRemuneracion_MP.Text = p1.REMUNERACION.ToString();
                txtDescuento_MP.Text = p1.PORCENT_DESCUENTO.ToString();

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
            limpiarCampos_MP();
            btnRegistrar_MP.Enabled = true;
            btnGuardar_MP.Enabled = false;
            btnEliminar_MP.Enabled = false;
        }


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
        }

        private void capturarCampos_MP()
        {
            string nombres = txtNombres_MP.Text;
            string apellidos = txtApellidos_MP.Text;
            string email = txtEmail_MP.Text;
            string contrasena = txtContrasena_MP.Text;
            int rut = int.Parse(txtRutPersonalCargado_MP.Text);
            string verificador = txtVerificadorCargado_MP.Text;
            int remuneracion = int.Parse(txtRemuneracion_MP.Text);
            int descuento = int.Parse(txtDescuento_MP.Text);
        }

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

                p1.ID_PERSONAL = at.nuevoPersonalId(p1);

                if (p1.ID_PERSONAL == 0)
                {
                    throw new Exception();
                }
                

                int privi = ((ComboboxItem)cbCargo_MP.SelectedItem).Value;
                using (var context = new CMHEntities())
                {
                    switch (privi)
                    {
                        case 0: // Médico
                            PERS_MEDICO persMedico = new PERS_MEDICO();
                            persMedico.ID_ESPECIALIDAD = context.ESPECIALIDAD.Where(d => d.NOM_ESPECIALIDAD.ToUpper() == "MEDICO").FirstOrDefault().ID_ESPECIALIDAD;
                            persMedico.ID_PERSONAL = p1.ID_PERSONAL;
                            at.nuevoPersonalMedico(persMedico);
                            at.asignarBloques(persMedico);
                            
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


                at.nuevoPersonal(p1);
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
            }
            else
            {
                txtCuentaBanc_MP.Enabled = false;
            }
                
        }


    }
}
