namespace CheekiBreeki.CMH.Terminal.Views
{
    partial class FrmJefeOp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnModificarUser = new System.Windows.Forms.Button();
            this.lblUsuarioConectado = new System.Windows.Forms.Label();
            this.btnSesion = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPrivilegio = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mantenedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbMantenedorPersonal = new System.Windows.Forms.GroupBox();
            this.cbCargo_MP = new System.Windows.Forms.ComboBox();
            this.lblCargo_MP = new System.Windows.Forms.Label();
            this.btnEliminar_MP = new System.Windows.Forms.Button();
            this.btnGuardar_MP = new System.Windows.Forms.Button();
            this.btnRegistrar_MP = new System.Windows.Forms.Button();
            this.txtDescuento_MP = new System.Windows.Forms.TextBox();
            this.txtRemuneracion_MP = new System.Windows.Forms.TextBox();
            this.txtContrasena_MP = new System.Windows.Forms.TextBox();
            this.txtEmail_MP = new System.Windows.Forms.TextBox();
            this.txtApellidos_MP = new System.Windows.Forms.TextBox();
            this.txtNombres_MP = new System.Windows.Forms.TextBox();
            this.lblDescuento_MP = new System.Windows.Forms.Label();
            this.lblRemuneracion = new System.Windows.Forms.Label();
            this.txtVerificadorCargado_MP = new System.Windows.Forms.TextBox();
            this.lblGuionCargado_MP = new System.Windows.Forms.Label();
            this.txtRutPersonalCargado_MP = new System.Windows.Forms.TextBox();
            this.lblRutPersonalCargado_MP = new System.Windows.Forms.Label();
            this.lblContrasena_MP = new System.Windows.Forms.Label();
            this.lblEmail_MP = new System.Windows.Forms.Label();
            this.btnCrearPersonal_MP = new System.Windows.Forms.Button();
            this.lblApellidos_MP = new System.Windows.Forms.Label();
            this.lblNombre_MP = new System.Windows.Forms.Label();
            this.btnCargarDatos_MP = new System.Windows.Forms.Button();
            this.txtVerificador_MP = new System.Windows.Forms.TextBox();
            this.lblGuion_MP = new System.Windows.Forms.Label();
            this.txtRutPersonal_MP = new System.Windows.Forms.TextBox();
            this.lblRutPersonal_MP = new System.Windows.Forms.Label();
            this.gbOpcionesUsuario = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbNuevoMail = new System.Windows.Forms.TextBox();
            this.btnCambiarEmail = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbContrasenaActual = new System.Windows.Forms.TextBox();
            this.btnCambiarContrasena = new System.Windows.Forms.Button();
            this.tbContrasenaNueva = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCuentaBanc_MP = new System.Windows.Forms.Label();
            this.txtCuentaBanc_MP = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gbMantenedorPersonal.SuspendLayout();
            this.gbOpcionesUsuario.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnModificarUser);
            this.groupBox3.Controls.Add(this.lblUsuarioConectado);
            this.groupBox3.Controls.Add(this.btnSesion);
            this.groupBox3.Location = new System.Drawing.Point(2, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(780, 41);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // btnModificarUser
            // 
            this.btnModificarUser.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnModificarUser.Location = new System.Drawing.Point(652, 12);
            this.btnModificarUser.Name = "btnModificarUser";
            this.btnModificarUser.Size = new System.Drawing.Size(122, 23);
            this.btnModificarUser.TabIndex = 3;
            this.btnModificarUser.Text = "Opciones de Cuenta";
            this.btnModificarUser.UseVisualStyleBackColor = true;
            this.btnModificarUser.Click += new System.EventHandler(this.btnModificarUser_Click);
            // 
            // lblUsuarioConectado
            // 
            this.lblUsuarioConectado.AutoSize = true;
            this.lblUsuarioConectado.Location = new System.Drawing.Point(11, 19);
            this.lblUsuarioConectado.Name = "lblUsuarioConectado";
            this.lblUsuarioConectado.Size = new System.Drawing.Size(98, 13);
            this.lblUsuarioConectado.TabIndex = 0;
            this.lblUsuarioConectado.Text = "ConectadoUsuario:";
            // 
            // btnSesion
            // 
            this.btnSesion.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSesion.Location = new System.Drawing.Point(535, 12);
            this.btnSesion.Name = "btnSesion";
            this.btnSesion.Size = new System.Drawing.Size(117, 23);
            this.btnSesion.TabIndex = 2;
            this.btnSesion.Text = "Sesión";
            this.btnSesion.UseVisualStyleBackColor = true;
            this.btnSesion.Click += new System.EventHandler(this.btnSesion_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPrivilegio);
            this.groupBox2.Location = new System.Drawing.Point(2, 533);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(780, 27);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // lblPrivilegio
            // 
            this.lblPrivilegio.AutoSize = true;
            this.lblPrivilegio.Location = new System.Drawing.Point(3, 11);
            this.lblPrivilegio.Name = "lblPrivilegio";
            this.lblPrivilegio.Size = new System.Drawing.Size(52, 13);
            this.lblPrivilegio.TabIndex = 1;
            this.lblPrivilegio.Text = "Privilegio:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.menuStrip1);
            this.groupBox1.Controls.Add(this.gbMantenedorPersonal);
            this.groupBox1.Controls.Add(this.gbOpcionesUsuario);
            this.groupBox1.Location = new System.Drawing.Point(2, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 505);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenedoresToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 16);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(774, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mantenedoresToolStripMenuItem
            // 
            this.mantenedoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personalToolStripMenuItem});
            this.mantenedoresToolStripMenuItem.Name = "mantenedoresToolStripMenuItem";
            this.mantenedoresToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.mantenedoresToolStripMenuItem.Text = "Mantenedores";
            // 
            // personalToolStripMenuItem
            // 
            this.personalToolStripMenuItem.Name = "personalToolStripMenuItem";
            this.personalToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.personalToolStripMenuItem.Text = "Personal";
            this.personalToolStripMenuItem.Click += new System.EventHandler(this.personalToolStripMenuItem_Click);
            // 
            // gbMantenedorPersonal
            // 
            this.gbMantenedorPersonal.Controls.Add(this.txtCuentaBanc_MP);
            this.gbMantenedorPersonal.Controls.Add(this.lblCuentaBanc_MP);
            this.gbMantenedorPersonal.Controls.Add(this.cbCargo_MP);
            this.gbMantenedorPersonal.Controls.Add(this.lblCargo_MP);
            this.gbMantenedorPersonal.Controls.Add(this.btnEliminar_MP);
            this.gbMantenedorPersonal.Controls.Add(this.btnGuardar_MP);
            this.gbMantenedorPersonal.Controls.Add(this.btnRegistrar_MP);
            this.gbMantenedorPersonal.Controls.Add(this.txtDescuento_MP);
            this.gbMantenedorPersonal.Controls.Add(this.txtRemuneracion_MP);
            this.gbMantenedorPersonal.Controls.Add(this.txtContrasena_MP);
            this.gbMantenedorPersonal.Controls.Add(this.txtEmail_MP);
            this.gbMantenedorPersonal.Controls.Add(this.txtApellidos_MP);
            this.gbMantenedorPersonal.Controls.Add(this.txtNombres_MP);
            this.gbMantenedorPersonal.Controls.Add(this.lblDescuento_MP);
            this.gbMantenedorPersonal.Controls.Add(this.lblRemuneracion);
            this.gbMantenedorPersonal.Controls.Add(this.txtVerificadorCargado_MP);
            this.gbMantenedorPersonal.Controls.Add(this.lblGuionCargado_MP);
            this.gbMantenedorPersonal.Controls.Add(this.txtRutPersonalCargado_MP);
            this.gbMantenedorPersonal.Controls.Add(this.lblRutPersonalCargado_MP);
            this.gbMantenedorPersonal.Controls.Add(this.lblContrasena_MP);
            this.gbMantenedorPersonal.Controls.Add(this.lblEmail_MP);
            this.gbMantenedorPersonal.Controls.Add(this.btnCrearPersonal_MP);
            this.gbMantenedorPersonal.Controls.Add(this.lblApellidos_MP);
            this.gbMantenedorPersonal.Controls.Add(this.lblNombre_MP);
            this.gbMantenedorPersonal.Controls.Add(this.btnCargarDatos_MP);
            this.gbMantenedorPersonal.Controls.Add(this.txtVerificador_MP);
            this.gbMantenedorPersonal.Controls.Add(this.lblGuion_MP);
            this.gbMantenedorPersonal.Controls.Add(this.txtRutPersonal_MP);
            this.gbMantenedorPersonal.Controls.Add(this.lblRutPersonal_MP);
            this.gbMantenedorPersonal.Location = new System.Drawing.Point(6, 43);
            this.gbMantenedorPersonal.Name = "gbMantenedorPersonal";
            this.gbMantenedorPersonal.Size = new System.Drawing.Size(768, 462);
            this.gbMantenedorPersonal.TabIndex = 10;
            this.gbMantenedorPersonal.TabStop = false;
            this.gbMantenedorPersonal.Text = "Mantenedor Personal";
            this.gbMantenedorPersonal.Visible = false;
            // 
            // cbCargo_MP
            // 
            this.cbCargo_MP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCargo_MP.FormattingEnabled = true;
            this.cbCargo_MP.Location = new System.Drawing.Point(360, 303);
            this.cbCargo_MP.Name = "cbCargo_MP";
            this.cbCargo_MP.Size = new System.Drawing.Size(151, 21);
            this.cbCargo_MP.TabIndex = 27;
            this.cbCargo_MP.SelectedIndexChanged += new System.EventHandler(this.cbCargo_MP_SelectedIndexChanged);
            // 
            // lblCargo_MP
            // 
            this.lblCargo_MP.AutoSize = true;
            this.lblCargo_MP.Location = new System.Drawing.Point(235, 306);
            this.lblCargo_MP.Name = "lblCargo_MP";
            this.lblCargo_MP.Size = new System.Drawing.Size(35, 13);
            this.lblCargo_MP.TabIndex = 26;
            this.lblCargo_MP.Text = "Cargo";
            // 
            // btnEliminar_MP
            // 
            this.btnEliminar_MP.Enabled = false;
            this.btnEliminar_MP.Location = new System.Drawing.Point(436, 379);
            this.btnEliminar_MP.Name = "btnEliminar_MP";
            this.btnEliminar_MP.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar_MP.TabIndex = 25;
            this.btnEliminar_MP.Text = "Eliminar";
            this.btnEliminar_MP.UseVisualStyleBackColor = true;
            // 
            // btnGuardar_MP
            // 
            this.btnGuardar_MP.Enabled = false;
            this.btnGuardar_MP.Location = new System.Drawing.Point(323, 379);
            this.btnGuardar_MP.Name = "btnGuardar_MP";
            this.btnGuardar_MP.Size = new System.Drawing.Size(107, 23);
            this.btnGuardar_MP.TabIndex = 24;
            this.btnGuardar_MP.Text = "Guardar cambios";
            this.btnGuardar_MP.UseVisualStyleBackColor = true;
            // 
            // btnRegistrar_MP
            // 
            this.btnRegistrar_MP.Enabled = false;
            this.btnRegistrar_MP.Location = new System.Drawing.Point(242, 379);
            this.btnRegistrar_MP.Name = "btnRegistrar_MP";
            this.btnRegistrar_MP.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar_MP.TabIndex = 23;
            this.btnRegistrar_MP.Text = "Registrar";
            this.btnRegistrar_MP.UseVisualStyleBackColor = true;
            this.btnRegistrar_MP.Click += new System.EventHandler(this.btnRegistrar_MP_Click);
            // 
            // txtDescuento_MP
            // 
            this.txtDescuento_MP.Location = new System.Drawing.Point(360, 272);
            this.txtDescuento_MP.MaxLength = 2;
            this.txtDescuento_MP.Name = "txtDescuento_MP";
            this.txtDescuento_MP.Size = new System.Drawing.Size(151, 20);
            this.txtDescuento_MP.TabIndex = 22;
            this.txtDescuento_MP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCampo_KeyPress);
            // 
            // txtRemuneracion_MP
            // 
            this.txtRemuneracion_MP.Location = new System.Drawing.Point(360, 240);
            this.txtRemuneracion_MP.Name = "txtRemuneracion_MP";
            this.txtRemuneracion_MP.Size = new System.Drawing.Size(151, 20);
            this.txtRemuneracion_MP.TabIndex = 21;
            // 
            // txtContrasena_MP
            // 
            this.txtContrasena_MP.Location = new System.Drawing.Point(360, 177);
            this.txtContrasena_MP.Name = "txtContrasena_MP";
            this.txtContrasena_MP.Size = new System.Drawing.Size(151, 20);
            this.txtContrasena_MP.TabIndex = 20;
            // 
            // txtEmail_MP
            // 
            this.txtEmail_MP.Location = new System.Drawing.Point(360, 145);
            this.txtEmail_MP.Name = "txtEmail_MP";
            this.txtEmail_MP.Size = new System.Drawing.Size(151, 20);
            this.txtEmail_MP.TabIndex = 19;
            // 
            // txtApellidos_MP
            // 
            this.txtApellidos_MP.Location = new System.Drawing.Point(360, 116);
            this.txtApellidos_MP.Name = "txtApellidos_MP";
            this.txtApellidos_MP.Size = new System.Drawing.Size(151, 20);
            this.txtApellidos_MP.TabIndex = 18;
            // 
            // txtNombres_MP
            // 
            this.txtNombres_MP.Location = new System.Drawing.Point(360, 86);
            this.txtNombres_MP.Name = "txtNombres_MP";
            this.txtNombres_MP.Size = new System.Drawing.Size(151, 20);
            this.txtNombres_MP.TabIndex = 17;
            // 
            // lblDescuento_MP
            // 
            this.lblDescuento_MP.AutoSize = true;
            this.lblDescuento_MP.Location = new System.Drawing.Point(234, 275);
            this.lblDescuento_MP.Name = "lblDescuento_MP";
            this.lblDescuento_MP.Size = new System.Drawing.Size(59, 13);
            this.lblDescuento_MP.TabIndex = 16;
            this.lblDescuento_MP.Text = "Descuento";
            // 
            // lblRemuneracion
            // 
            this.lblRemuneracion.AutoSize = true;
            this.lblRemuneracion.Location = new System.Drawing.Point(235, 243);
            this.lblRemuneracion.Name = "lblRemuneracion";
            this.lblRemuneracion.Size = new System.Drawing.Size(76, 13);
            this.lblRemuneracion.TabIndex = 15;
            this.lblRemuneracion.Text = "Remuneración";
            // 
            // txtVerificadorCargado_MP
            // 
            this.txtVerificadorCargado_MP.Location = new System.Drawing.Point(489, 208);
            this.txtVerificadorCargado_MP.Name = "txtVerificadorCargado_MP";
            this.txtVerificadorCargado_MP.Size = new System.Drawing.Size(22, 20);
            this.txtVerificadorCargado_MP.TabIndex = 14;
            // 
            // lblGuionCargado_MP
            // 
            this.lblGuionCargado_MP.AutoSize = true;
            this.lblGuionCargado_MP.Location = new System.Drawing.Point(467, 211);
            this.lblGuionCargado_MP.Name = "lblGuionCargado_MP";
            this.lblGuionCargado_MP.Size = new System.Drawing.Size(10, 13);
            this.lblGuionCargado_MP.TabIndex = 13;
            this.lblGuionCargado_MP.Text = "-";
            // 
            // txtRutPersonalCargado_MP
            // 
            this.txtRutPersonalCargado_MP.Location = new System.Drawing.Point(360, 208);
            this.txtRutPersonalCargado_MP.Name = "txtRutPersonalCargado_MP";
            this.txtRutPersonalCargado_MP.Size = new System.Drawing.Size(100, 20);
            this.txtRutPersonalCargado_MP.TabIndex = 12;
            // 
            // lblRutPersonalCargado_MP
            // 
            this.lblRutPersonalCargado_MP.AutoSize = true;
            this.lblRutPersonalCargado_MP.Location = new System.Drawing.Point(235, 211);
            this.lblRutPersonalCargado_MP.Name = "lblRutPersonalCargado_MP";
            this.lblRutPersonalCargado_MP.Size = new System.Drawing.Size(83, 13);
            this.lblRutPersonalCargado_MP.TabIndex = 11;
            this.lblRutPersonalCargado_MP.Text = "Rut de Personal";
            // 
            // lblContrasena_MP
            // 
            this.lblContrasena_MP.AutoSize = true;
            this.lblContrasena_MP.Location = new System.Drawing.Point(234, 180);
            this.lblContrasena_MP.Name = "lblContrasena_MP";
            this.lblContrasena_MP.Size = new System.Drawing.Size(61, 13);
            this.lblContrasena_MP.TabIndex = 10;
            this.lblContrasena_MP.Text = "Contraseña";
            // 
            // lblEmail_MP
            // 
            this.lblEmail_MP.AutoSize = true;
            this.lblEmail_MP.Location = new System.Drawing.Point(234, 152);
            this.lblEmail_MP.Name = "lblEmail_MP";
            this.lblEmail_MP.Size = new System.Drawing.Size(32, 13);
            this.lblEmail_MP.TabIndex = 9;
            this.lblEmail_MP.Text = "Email";
            // 
            // btnCrearPersonal_MP
            // 
            this.btnCrearPersonal_MP.Location = new System.Drawing.Point(507, 38);
            this.btnCrearPersonal_MP.Name = "btnCrearPersonal_MP";
            this.btnCrearPersonal_MP.Size = new System.Drawing.Size(93, 23);
            this.btnCrearPersonal_MP.TabIndex = 8;
            this.btnCrearPersonal_MP.Text = "Nuevo Personal";
            this.btnCrearPersonal_MP.UseVisualStyleBackColor = true;
            this.btnCrearPersonal_MP.Click += new System.EventHandler(this.btnCrearPersonal_MP_Click);
            // 
            // lblApellidos_MP
            // 
            this.lblApellidos_MP.AutoSize = true;
            this.lblApellidos_MP.Location = new System.Drawing.Point(234, 119);
            this.lblApellidos_MP.Name = "lblApellidos_MP";
            this.lblApellidos_MP.Size = new System.Drawing.Size(49, 13);
            this.lblApellidos_MP.TabIndex = 7;
            this.lblApellidos_MP.Text = "Apellidos";
            // 
            // lblNombre_MP
            // 
            this.lblNombre_MP.AutoSize = true;
            this.lblNombre_MP.Location = new System.Drawing.Point(235, 89);
            this.lblNombre_MP.Name = "lblNombre_MP";
            this.lblNombre_MP.Size = new System.Drawing.Size(49, 13);
            this.lblNombre_MP.TabIndex = 6;
            this.lblNombre_MP.Text = "Nombres";
            // 
            // btnCargarDatos_MP
            // 
            this.btnCargarDatos_MP.Location = new System.Drawing.Point(411, 38);
            this.btnCargarDatos_MP.Name = "btnCargarDatos_MP";
            this.btnCargarDatos_MP.Size = new System.Drawing.Size(90, 23);
            this.btnCargarDatos_MP.TabIndex = 4;
            this.btnCargarDatos_MP.Text = "Cargar Datos";
            this.btnCargarDatos_MP.UseVisualStyleBackColor = true;
            this.btnCargarDatos_MP.Click += new System.EventHandler(this.btnCargarDatos_MP_Click);
            // 
            // txtVerificador_MP
            // 
            this.txtVerificador_MP.Location = new System.Drawing.Point(364, 40);
            this.txtVerificador_MP.MaxLength = 1;
            this.txtVerificador_MP.Name = "txtVerificador_MP";
            this.txtVerificador_MP.Size = new System.Drawing.Size(22, 20);
            this.txtVerificador_MP.TabIndex = 3;
            this.txtVerificador_MP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDv_KeyPress);
            // 
            // lblGuion_MP
            // 
            this.lblGuion_MP.AutoSize = true;
            this.lblGuion_MP.Location = new System.Drawing.Point(348, 43);
            this.lblGuion_MP.Name = "lblGuion_MP";
            this.lblGuion_MP.Size = new System.Drawing.Size(10, 13);
            this.lblGuion_MP.TabIndex = 2;
            this.lblGuion_MP.Text = "-";
            // 
            // txtRutPersonal_MP
            // 
            this.txtRutPersonal_MP.Location = new System.Drawing.Point(242, 40);
            this.txtRutPersonal_MP.MaxLength = 8;
            this.txtRutPersonal_MP.Name = "txtRutPersonal_MP";
            this.txtRutPersonal_MP.Size = new System.Drawing.Size(100, 20);
            this.txtRutPersonal_MP.TabIndex = 1;
            this.txtRutPersonal_MP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCampo_KeyPress);
            // 
            // lblRutPersonal_MP
            // 
            this.lblRutPersonal_MP.AutoSize = true;
            this.lblRutPersonal_MP.Location = new System.Drawing.Point(153, 43);
            this.lblRutPersonal_MP.Name = "lblRutPersonal_MP";
            this.lblRutPersonal_MP.Size = new System.Drawing.Size(83, 13);
            this.lblRutPersonal_MP.TabIndex = 0;
            this.lblRutPersonal_MP.Text = "Rut de Personal";
            // 
            // gbOpcionesUsuario
            // 
            this.gbOpcionesUsuario.Controls.Add(this.groupBox5);
            this.gbOpcionesUsuario.Controls.Add(this.groupBox4);
            this.gbOpcionesUsuario.Location = new System.Drawing.Point(6, 43);
            this.gbOpcionesUsuario.Name = "gbOpcionesUsuario";
            this.gbOpcionesUsuario.Size = new System.Drawing.Size(768, 462);
            this.gbOpcionesUsuario.TabIndex = 3;
            this.gbOpcionesUsuario.TabStop = false;
            this.gbOpcionesUsuario.Text = "Opciones de cuenta";
            this.gbOpcionesUsuario.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.tbNuevoMail);
            this.groupBox5.Controls.Add(this.btnCambiarEmail);
            this.groupBox5.Location = new System.Drawing.Point(32, 276);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(695, 158);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Email";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(71, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Nuevo email:";
            // 
            // tbNuevoMail
            // 
            this.tbNuevoMail.Location = new System.Drawing.Point(205, 59);
            this.tbNuevoMail.MaxLength = 80;
            this.tbNuevoMail.Name = "tbNuevoMail";
            this.tbNuevoMail.Size = new System.Drawing.Size(409, 20);
            this.tbNuevoMail.TabIndex = 7;
            // 
            // btnCambiarEmail
            // 
            this.btnCambiarEmail.Location = new System.Drawing.Point(255, 112);
            this.btnCambiarEmail.Name = "btnCambiarEmail";
            this.btnCambiarEmail.Size = new System.Drawing.Size(144, 23);
            this.btnCambiarEmail.TabIndex = 3;
            this.btnCambiarEmail.Text = "Cambiar email";
            this.btnCambiarEmail.UseVisualStyleBackColor = true;
            this.btnCambiarEmail.Click += new System.EventHandler(this.btnCambiarEmail_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.tbContrasenaActual);
            this.groupBox4.Controls.Add(this.btnCambiarContrasena);
            this.groupBox4.Controls.Add(this.tbContrasenaNueva);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(32, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(695, 247);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Contraseña";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Contraseña actual:";
            // 
            // tbContrasenaActual
            // 
            this.tbContrasenaActual.Location = new System.Drawing.Point(206, 62);
            this.tbContrasenaActual.MaxLength = 40;
            this.tbContrasenaActual.Name = "tbContrasenaActual";
            this.tbContrasenaActual.PasswordChar = '*';
            this.tbContrasenaActual.Size = new System.Drawing.Size(408, 20);
            this.tbContrasenaActual.TabIndex = 5;
            // 
            // btnCambiarContrasena
            // 
            this.btnCambiarContrasena.Location = new System.Drawing.Point(255, 205);
            this.btnCambiarContrasena.Name = "btnCambiarContrasena";
            this.btnCambiarContrasena.Size = new System.Drawing.Size(144, 23);
            this.btnCambiarContrasena.TabIndex = 4;
            this.btnCambiarContrasena.Text = "Cambiar contraseña";
            this.btnCambiarContrasena.UseVisualStyleBackColor = true;
            this.btnCambiarContrasena.Click += new System.EventHandler(this.btnCambiarContrasena_Click);
            // 
            // tbContrasenaNueva
            // 
            this.tbContrasenaNueva.Location = new System.Drawing.Point(206, 136);
            this.tbContrasenaNueva.MaxLength = 40;
            this.tbContrasenaNueva.Name = "tbContrasenaNueva";
            this.tbContrasenaNueva.PasswordChar = '*';
            this.tbContrasenaNueva.Size = new System.Drawing.Size(408, 20);
            this.tbContrasenaNueva.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(71, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Contraseña nueva:";
            // 
            // lblCuentaBanc_MP
            // 
            this.lblCuentaBanc_MP.AutoSize = true;
            this.lblCuentaBanc_MP.Location = new System.Drawing.Point(231, 338);
            this.lblCuentaBanc_MP.Name = "lblCuentaBanc_MP";
            this.lblCuentaBanc_MP.Size = new System.Drawing.Size(86, 13);
            this.lblCuentaBanc_MP.TabIndex = 28;
            this.lblCuentaBanc_MP.Text = "Cuenta Bancaria";
            // 
            // txtCuentaBanc_MP
            // 
            this.txtCuentaBanc_MP.Location = new System.Drawing.Point(360, 335);
            this.txtCuentaBanc_MP.Name = "txtCuentaBanc_MP";
            this.txtCuentaBanc_MP.Size = new System.Drawing.Size(151, 20);
            this.txtCuentaBanc_MP.TabIndex = 29;
            // 
            // FrmJefeOp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmJefeOp";
            this.Text = "Centro medico Hipócrates";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmJefeOp_FormClosed);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbMantenedorPersonal.ResumeLayout(false);
            this.gbMantenedorPersonal.PerformLayout();
            this.gbOpcionesUsuario.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnModificarUser;
        private System.Windows.Forms.Label lblUsuarioConectado;
        private System.Windows.Forms.Button btnSesion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPrivilegio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox gbOpcionesUsuario;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbNuevoMail;
        private System.Windows.Forms.Button btnCambiarEmail;
        private System.Windows.Forms.ToolStripMenuItem mantenedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personalToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbMantenedorPersonal;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbContrasenaActual;
        private System.Windows.Forms.Button btnCambiarContrasena;
        private System.Windows.Forms.TextBox tbContrasenaNueva;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCargarDatos_MP;
        private System.Windows.Forms.TextBox txtVerificador_MP;
        private System.Windows.Forms.Label lblGuion_MP;
        private System.Windows.Forms.TextBox txtRutPersonal_MP;
        private System.Windows.Forms.Label lblRutPersonal_MP;
        private System.Windows.Forms.Label lblApellidos_MP;
        private System.Windows.Forms.Label lblNombre_MP;
        private System.Windows.Forms.Button btnCrearPersonal_MP;
        private System.Windows.Forms.Label lblRemuneracion;
        private System.Windows.Forms.TextBox txtVerificadorCargado_MP;
        private System.Windows.Forms.Label lblGuionCargado_MP;
        private System.Windows.Forms.TextBox txtRutPersonalCargado_MP;
        private System.Windows.Forms.Label lblRutPersonalCargado_MP;
        private System.Windows.Forms.Label lblContrasena_MP;
        private System.Windows.Forms.Label lblEmail_MP;
        private System.Windows.Forms.TextBox txtDescuento_MP;
        private System.Windows.Forms.TextBox txtRemuneracion_MP;
        private System.Windows.Forms.TextBox txtContrasena_MP;
        private System.Windows.Forms.TextBox txtEmail_MP;
        private System.Windows.Forms.TextBox txtApellidos_MP;
        private System.Windows.Forms.TextBox txtNombres_MP;
        private System.Windows.Forms.Label lblDescuento_MP;
        private System.Windows.Forms.Button btnEliminar_MP;
        private System.Windows.Forms.Button btnGuardar_MP;
        private System.Windows.Forms.Button btnRegistrar_MP;
        private System.Windows.Forms.ComboBox cbCargo_MP;
        private System.Windows.Forms.Label lblCargo_MP;
        private System.Windows.Forms.TextBox txtCuentaBanc_MP;
        private System.Windows.Forms.Label lblCuentaBanc_MP;
    }
}