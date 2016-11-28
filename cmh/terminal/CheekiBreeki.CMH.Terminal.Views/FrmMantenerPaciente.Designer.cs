namespace CheekiBreeki.CMH.Terminal.Views
{
    partial class FrmMantenerPaciente
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
            this.pacienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbMantenedorPaciente = new System.Windows.Forms.GroupBox();
            this.txtVerificadorCargado_Pac = new System.Windows.Forms.TextBox();
            this.dtpFechaNac_Pac = new System.Windows.Forms.DateTimePicker();
            this.cbSexo_Pac = new System.Windows.Forms.ComboBox();
            this.txtRutCargado_Pac = new System.Windows.Forms.TextBox();
            this.txtContrasena_Pac = new System.Windows.Forms.TextBox();
            this.txtEmail_Pac = new System.Windows.Forms.TextBox();
            this.txtApellidos_Pac = new System.Windows.Forms.TextBox();
            this.txtNombres_Pac = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnRegistrar_Pac = new System.Windows.Forms.Button();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.lblRutCargado = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.lblNombres = new System.Windows.Forms.Label();
            this.btnNuevoPaciente = new System.Windows.Forms.Button();
            this.btnCargarPaciente = new System.Windows.Forms.Button();
            this.txtVerificador_Pac = new System.Windows.Forms.TextBox();
            this.lblGuion = new System.Windows.Forms.Label();
            this.txtRutPaciente_Pac = new System.Windows.Forms.TextBox();
            this.lblRutPaciente = new System.Windows.Forms.Label();
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
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gbMantenedorPaciente.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.gbMantenedorPaciente);
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
            this.personalToolStripMenuItem,
            this.pacienteToolStripMenuItem,
            this.equipoToolStripMenuItem});
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
            // pacienteToolStripMenuItem
            // 
            this.pacienteToolStripMenuItem.Name = "pacienteToolStripMenuItem";
            this.pacienteToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.pacienteToolStripMenuItem.Text = "Paciente";
            this.pacienteToolStripMenuItem.Click += new System.EventHandler(this.pacienteToolStripMenuItem_Click);
            // 
            // equipoToolStripMenuItem
            // 
            this.equipoToolStripMenuItem.Name = "equipoToolStripMenuItem";
            this.equipoToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.equipoToolStripMenuItem.Text = "Equipo";
            this.equipoToolStripMenuItem.Click += new System.EventHandler(this.equipoToolStripMenuItem_Click);
            // 
            // gbMantenedorPaciente
            // 
            this.gbMantenedorPaciente.Controls.Add(this.txtVerificadorCargado_Pac);
            this.gbMantenedorPaciente.Controls.Add(this.dtpFechaNac_Pac);
            this.gbMantenedorPaciente.Controls.Add(this.cbSexo_Pac);
            this.gbMantenedorPaciente.Controls.Add(this.txtRutCargado_Pac);
            this.gbMantenedorPaciente.Controls.Add(this.txtContrasena_Pac);
            this.gbMantenedorPaciente.Controls.Add(this.txtEmail_Pac);
            this.gbMantenedorPaciente.Controls.Add(this.txtApellidos_Pac);
            this.gbMantenedorPaciente.Controls.Add(this.txtNombres_Pac);
            this.gbMantenedorPaciente.Controls.Add(this.btnEliminar);
            this.gbMantenedorPaciente.Controls.Add(this.btnGuardar);
            this.gbMantenedorPaciente.Controls.Add(this.btnRegistrar_Pac);
            this.gbMantenedorPaciente.Controls.Add(this.lblFechaNac);
            this.gbMantenedorPaciente.Controls.Add(this.lblSexo);
            this.gbMantenedorPaciente.Controls.Add(this.lblRutCargado);
            this.gbMantenedorPaciente.Controls.Add(this.lblContrasena);
            this.gbMantenedorPaciente.Controls.Add(this.lblEmail);
            this.gbMantenedorPaciente.Controls.Add(this.lblApellidos);
            this.gbMantenedorPaciente.Controls.Add(this.lblNombres);
            this.gbMantenedorPaciente.Controls.Add(this.btnNuevoPaciente);
            this.gbMantenedorPaciente.Controls.Add(this.btnCargarPaciente);
            this.gbMantenedorPaciente.Controls.Add(this.txtVerificador_Pac);
            this.gbMantenedorPaciente.Controls.Add(this.lblGuion);
            this.gbMantenedorPaciente.Controls.Add(this.txtRutPaciente_Pac);
            this.gbMantenedorPaciente.Controls.Add(this.lblRutPaciente);
            this.gbMantenedorPaciente.Location = new System.Drawing.Point(6, 43);
            this.gbMantenedorPaciente.Name = "gbMantenedorPaciente";
            this.gbMantenedorPaciente.Size = new System.Drawing.Size(768, 462);
            this.gbMantenedorPaciente.TabIndex = 10;
            this.gbMantenedorPaciente.TabStop = false;
            this.gbMantenedorPaciente.Text = "Mantener Paciente";
            // 
            // txtVerificadorCargado_Pac
            // 
            this.txtVerificadorCargado_Pac.Location = new System.Drawing.Point(520, 203);
            this.txtVerificadorCargado_Pac.MaxLength = 1;
            this.txtVerificadorCargado_Pac.Name = "txtVerificadorCargado_Pac";
            this.txtVerificadorCargado_Pac.Size = new System.Drawing.Size(62, 20);
            this.txtVerificadorCargado_Pac.TabIndex = 31;
            this.txtVerificadorCargado_Pac.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDv_KeyPress);
            // 
            // dtpFechaNac_Pac
            // 
            this.dtpFechaNac_Pac.Location = new System.Drawing.Point(348, 252);
            this.dtpFechaNac_Pac.Name = "dtpFechaNac_Pac";
            this.dtpFechaNac_Pac.Size = new System.Drawing.Size(234, 20);
            this.dtpFechaNac_Pac.TabIndex = 30;
            // 
            // cbSexo_Pac
            // 
            this.cbSexo_Pac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSexo_Pac.FormattingEnabled = true;
            this.cbSexo_Pac.Location = new System.Drawing.Point(348, 228);
            this.cbSexo_Pac.Name = "cbSexo_Pac";
            this.cbSexo_Pac.Size = new System.Drawing.Size(234, 21);
            this.cbSexo_Pac.TabIndex = 29;
            // 
            // txtRutCargado_Pac
            // 
            this.txtRutCargado_Pac.Location = new System.Drawing.Point(348, 203);
            this.txtRutCargado_Pac.MaxLength = 8;
            this.txtRutCargado_Pac.Name = "txtRutCargado_Pac";
            this.txtRutCargado_Pac.Size = new System.Drawing.Size(155, 20);
            this.txtRutCargado_Pac.TabIndex = 27;
            this.txtRutCargado_Pac.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCampo_KeyPress);
            // 
            // txtContrasena_Pac
            // 
            this.txtContrasena_Pac.Location = new System.Drawing.Point(348, 176);
            this.txtContrasena_Pac.MaxLength = 1080;
            this.txtContrasena_Pac.Name = "txtContrasena_Pac";
            this.txtContrasena_Pac.PasswordChar = '*';
            this.txtContrasena_Pac.Size = new System.Drawing.Size(234, 20);
            this.txtContrasena_Pac.TabIndex = 26;
            // 
            // txtEmail_Pac
            // 
            this.txtEmail_Pac.Location = new System.Drawing.Point(348, 149);
            this.txtEmail_Pac.MaxLength = 512;
            this.txtEmail_Pac.Name = "txtEmail_Pac";
            this.txtEmail_Pac.Size = new System.Drawing.Size(234, 20);
            this.txtEmail_Pac.TabIndex = 25;
            // 
            // txtApellidos_Pac
            // 
            this.txtApellidos_Pac.Location = new System.Drawing.Point(348, 122);
            this.txtApellidos_Pac.MaxLength = 64;
            this.txtApellidos_Pac.Name = "txtApellidos_Pac";
            this.txtApellidos_Pac.Size = new System.Drawing.Size(234, 20);
            this.txtApellidos_Pac.TabIndex = 24;
            // 
            // txtNombres_Pac
            // 
            this.txtNombres_Pac.Location = new System.Drawing.Point(348, 95);
            this.txtNombres_Pac.MaxLength = 64;
            this.txtNombres_Pac.Name = "txtNombres_Pac";
            this.txtNombres_Pac.Size = new System.Drawing.Size(234, 20);
            this.txtNombres_Pac.TabIndex = 23;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(459, 306);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 22;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Location = new System.Drawing.Point(314, 306);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(98, 23);
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnRegistrar_Pac
            // 
            this.btnRegistrar_Pac.Enabled = false;
            this.btnRegistrar_Pac.Location = new System.Drawing.Point(193, 306);
            this.btnRegistrar_Pac.Name = "btnRegistrar_Pac";
            this.btnRegistrar_Pac.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar_Pac.TabIndex = 20;
            this.btnRegistrar_Pac.Text = "Registrar";
            this.btnRegistrar_Pac.UseVisualStyleBackColor = true;
            this.btnRegistrar_Pac.Click += new System.EventHandler(this.btnRegistrar_Pac_Click);
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Location = new System.Drawing.Point(143, 258);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(108, 13);
            this.lblFechaNac.TabIndex = 12;
            this.lblFechaNac.Text = "Fecha de Nacimiento";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(143, 228);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(31, 13);
            this.lblSexo.TabIndex = 11;
            this.lblSexo.Text = "Sexo";
            // 
            // lblRutCargado
            // 
            this.lblRutCargado.AutoSize = true;
            this.lblRutCargado.Location = new System.Drawing.Point(143, 201);
            this.lblRutCargado.Name = "lblRutCargado";
            this.lblRutCargado.Size = new System.Drawing.Size(24, 13);
            this.lblRutCargado.TabIndex = 10;
            this.lblRutCargado.Text = "Rut";
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location = new System.Drawing.Point(143, 175);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(61, 13);
            this.lblContrasena.TabIndex = 9;
            this.lblContrasena.Text = "Contraseña";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(143, 149);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "Email";
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Location = new System.Drawing.Point(143, 121);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(49, 13);
            this.lblApellidos.TabIndex = 7;
            this.lblApellidos.Text = "Apellidos";
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Location = new System.Drawing.Point(143, 95);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(49, 13);
            this.lblNombres.TabIndex = 6;
            this.lblNombres.Text = "Nombres";
            // 
            // btnNuevoPaciente
            // 
            this.btnNuevoPaciente.Location = new System.Drawing.Point(517, 46);
            this.btnNuevoPaciente.Name = "btnNuevoPaciente";
            this.btnNuevoPaciente.Size = new System.Drawing.Size(99, 23);
            this.btnNuevoPaciente.TabIndex = 5;
            this.btnNuevoPaciente.Text = "Nuevo Paciente";
            this.btnNuevoPaciente.UseVisualStyleBackColor = true;
            this.btnNuevoPaciente.Click += new System.EventHandler(this.btnNuevoPaciente_Click);
            // 
            // btnCargarPaciente
            // 
            this.btnCargarPaciente.Location = new System.Drawing.Point(417, 46);
            this.btnCargarPaciente.Name = "btnCargarPaciente";
            this.btnCargarPaciente.Size = new System.Drawing.Size(94, 23);
            this.btnCargarPaciente.TabIndex = 4;
            this.btnCargarPaciente.Text = "Cargar Paciente";
            this.btnCargarPaciente.UseVisualStyleBackColor = true;
            this.btnCargarPaciente.Click += new System.EventHandler(this.btnCargarPaciente_Click);
            // 
            // txtVerificador_Pac
            // 
            this.txtVerificador_Pac.Location = new System.Drawing.Point(376, 48);
            this.txtVerificador_Pac.MaxLength = 1;
            this.txtVerificador_Pac.Name = "txtVerificador_Pac";
            this.txtVerificador_Pac.Size = new System.Drawing.Size(24, 20);
            this.txtVerificador_Pac.TabIndex = 3;
            this.txtVerificador_Pac.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDv_KeyPress);
            // 
            // lblGuion
            // 
            this.lblGuion.AutoSize = true;
            this.lblGuion.Location = new System.Drawing.Point(360, 51);
            this.lblGuion.Name = "lblGuion";
            this.lblGuion.Size = new System.Drawing.Size(10, 13);
            this.lblGuion.TabIndex = 2;
            this.lblGuion.Text = "-";
            // 
            // txtRutPaciente_Pac
            // 
            this.txtRutPaciente_Pac.Location = new System.Drawing.Point(245, 48);
            this.txtRutPaciente_Pac.MaxLength = 8;
            this.txtRutPaciente_Pac.Name = "txtRutPaciente_Pac";
            this.txtRutPaciente_Pac.Size = new System.Drawing.Size(108, 20);
            this.txtRutPaciente_Pac.TabIndex = 1;
            this.txtRutPaciente_Pac.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCampo_KeyPress);
            // 
            // lblRutPaciente
            // 
            this.lblRutPaciente.AutoSize = true;
            this.lblRutPaciente.Location = new System.Drawing.Point(132, 51);
            this.lblRutPaciente.Name = "lblRutPaciente";
            this.lblRutPaciente.Size = new System.Drawing.Size(84, 13);
            this.lblRutPaciente.TabIndex = 0;
            this.lblRutPaciente.Text = "Rut de Paciente";
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
            // FrmMantenerPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMantenerPaciente";
            this.Text = "Centro médico Hipócrates";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmJefeOp_FormClosed);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbMantenedorPaciente.ResumeLayout(false);
            this.gbMantenedorPaciente.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbMantenedorPaciente;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbContrasenaActual;
        private System.Windows.Forms.Button btnCambiarContrasena;
        private System.Windows.Forms.TextBox tbContrasenaNueva;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem pacienteToolStripMenuItem;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnRegistrar_Pac;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label lblRutCargado;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Button btnNuevoPaciente;
        private System.Windows.Forms.Button btnCargarPaciente;
        private System.Windows.Forms.TextBox txtVerificador_Pac;
        private System.Windows.Forms.Label lblGuion;
        private System.Windows.Forms.TextBox txtRutPaciente_Pac;
        private System.Windows.Forms.Label lblRutPaciente;
        private System.Windows.Forms.TextBox txtNombres_Pac;
        private System.Windows.Forms.TextBox txtRutCargado_Pac;
        private System.Windows.Forms.TextBox txtContrasena_Pac;
        private System.Windows.Forms.TextBox txtEmail_Pac;
        private System.Windows.Forms.TextBox txtApellidos_Pac;
        private System.Windows.Forms.DateTimePicker dtpFechaNac_Pac;
        private System.Windows.Forms.ComboBox cbSexo_Pac;
        private System.Windows.Forms.TextBox txtVerificadorCargado_Pac;
        private System.Windows.Forms.ToolStripMenuItem equipoToolStripMenuItem;
    }
}