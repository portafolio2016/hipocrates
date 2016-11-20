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
    public partial class FrmMantenerEquipo : Form
    {
        private static AccionesTerminal acciones = new AccionesTerminal();
        FrmLogin login = null;
        bool closeApp;

        public void CargarDataGridInventario()
        {
            AccionesTerminal at = new AccionesTerminal();
            List<INVENTARIO> listaInventarioDB = at.listarInventario();
            //List<ATENCION_AGEN> listaAtenciones = acciones.revisarAgendaDiaria(FrmLogin.usuarioLogeado.Personal.RUT, DateTime.Now);
            List<ListaInventarioDG> listaInventarioDG = new List<ListaInventarioDG>();
            //List<AgendaDiaria> agendaDiaria = new List<AgendaDiaria>();

            if (listaInventarioDB.Count > 0)
            {

                foreach (INVENTARIO x in listaInventarioDB)
                {
                    listaInventarioDG.Add(new ListaInventarioDG(x.ID_INVENTARIO_EQUIPO,(int) x.CANT_BODEGA,(int) x.ID_TIPO_EQUIPO,x.TIPO_EQUIPO.NOMBRE_TIPO_EQUIPO));
                }

            }
            dgEquipo_Eq.DataSource = listaInventarioDG;
            
        }

        public void CargarComboboxEquipo()
        {
            AccionesTerminal at = new AccionesTerminal();
            cbNombreEquipo_Eq.DataSource = null;
            cbNombreEquipo_Eq.ValueMember = "ID_TIPO_EQUIPO";
            cbNombreEquipo_Eq.DisplayMember = "NOMBRE_TIPO_EQUIPO";
            cbNombreEquipo_Eq.DataSource = at.ObtenerTipoEquipo();
        }
        

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                              //
        //   CONSTRUCTOR                                                                                                                //
        //                                                                                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FrmMantenerEquipo(FrmLogin fLogin)
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

            CargarDataGridInventario();
            CargarComboboxEquipo();
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
            gbMantenerEquipo.Hide();
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

        private void equipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMantenerEquipo frmMantenerEquipo = new FrmMantenerEquipo(login);
            frmMantenerEquipo.Show();
            frmMantenerEquipo.Activate();
            this.Hide();
        }
        #endregion

        #region Limpiar Datos
        public void limpiarDatos()
        {
            txtCantidad_Eq.Text = string.Empty;
        }
        #endregion

        private void btnNuevoEquipo_Click(object sender, EventArgs e)
        {
            limpiarDatos();
            btnRegistrar_Eq.Enabled = true;
            btnGuardar_Eq.Enabled = false;
        }

        private void btnCargarEquipo_Eq_Click(object sender, EventArgs e)
        {

            try
            {
                txtCantidad_Eq.Text = dgEquipo_Eq.CurrentRow.Cells["cantidad"].Value.ToString();
                cbNombreEquipo_Eq.SelectedIndex = (int)dgEquipo_Eq.CurrentRow.Cells["idEquipo"].Value -1;
                btnRegistrar_Eq.Enabled = false;
                btnGuardar_Eq.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar equipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRegistrar_Eq_Click(object sender, EventArgs e)
        {
            try
            {
                AccionesTerminal at = new AccionesTerminal();
                INVENTARIO in1 = new INVENTARIO();

                in1.CANT_BODEGA = int.Parse(txtCantidad_Eq.Text);
                in1.ID_TIPO_EQUIPO = ((TIPO_EQUIPO)cbNombreEquipo_Eq.SelectedItem).ID_TIPO_EQUIPO;

                at.nuevoEquipoInventario(in1);
                
                MessageBox.Show("¡Inventario creado exitosamente!", "Personal", MessageBoxButtons.OK, MessageBoxIcon.None);
                limpiarDatos();
                CargarDataGridInventario();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnGuardar_Eq_Click(object sender, EventArgs e)
        {
            try
            {
                AccionesTerminal at = new AccionesTerminal();
                INVENTARIO inv = at.buscarInventario((int)dgEquipo_Eq.CurrentRow.Cells["idInventario"].Value);
                inv.CANT_BODEGA = int.Parse(txtCantidad_Eq.Text);
                inv.ID_TIPO_EQUIPO = ((TIPO_EQUIPO)cbNombreEquipo_Eq.SelectedItem).ID_TIPO_EQUIPO;
                at.actualizarInventario(inv);
                MessageBox.Show("¡Inventario actualizado exitosamente!", "Personal", MessageBoxButtons.OK, MessageBoxIcon.None);
                limpiarDatos();
                CargarDataGridInventario();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar equipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






    }
}
