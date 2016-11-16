namespace CheekiBreeki.CMH.Terminal.Views
{
    partial class FrmMedico
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
            this.lblUsuarioConectado = new System.Windows.Forms.Label();
            this.lblPrivilegio = new System.Windows.Forms.Label();
            this.btnSesion = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.agendaDiariaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fichasMédicasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verFichaMédicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasMédicasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirConsultaMédicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarConsultaMédicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atencionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbVerFichaMedica = new System.Windows.Forms.GroupBox();
            this.dgEntradaVFM = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.tbVerificadorVFM = new System.Windows.Forms.TextBox();
            this.tbRUNVFM = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnBuscarVFM = new System.Windows.Forms.Button();
            this.gbAgendaDiaria = new System.Windows.Forms.GroupBox();
            this.dgAgendaDiaria = new System.Windows.Forms.DataGridView();
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
            this.gbAbrirConsultaMedica = new System.Windows.Forms.GroupBox();
            this.cbHoraACM = new System.Windows.Forms.ComboBox();
            this.cbFechaACM = new System.Windows.Forms.ComboBox();
            this.cbPrestacionACM = new System.Windows.Forms.ComboBox();
            this.cbPersonalMedicoACM = new System.Windows.Forms.ComboBox();
            this.cbEspecialidadACM = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgendarAtencionACM = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbCerrarConsultaMedica = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnModificarUser = new System.Windows.Forms.Button();
            this.NombreEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContenidoEntrada = new System.Windows.Forms.DataGridViewButtonColumn();
            this.FechaEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbDatosPacienteVFM = new System.Windows.Forms.GroupBox();
            this.lbNombreVFM = new System.Windows.Forms.Label();
            this.lbEmailVFM = new System.Windows.Forms.Label();
            this.lbRun = new System.Windows.Forms.Label();
            this.lbSexoVFM = new System.Windows.Forms.Label();
            this.lbFechaNacVFM = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gbVerFichaMedica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEntradaVFM)).BeginInit();
            this.gbAgendaDiaria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAgendaDiaria)).BeginInit();
            this.gbOpcionesUsuario.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbAbrirConsultaMedica.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbDatosPacienteVFM.SuspendLayout();
            this.SuspendLayout();
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
            // lblPrivilegio
            // 
            this.lblPrivilegio.AutoSize = true;
            this.lblPrivilegio.Location = new System.Drawing.Point(3, 11);
            this.lblPrivilegio.Name = "lblPrivilegio";
            this.lblPrivilegio.Size = new System.Drawing.Size(52, 13);
            this.lblPrivilegio.TabIndex = 1;
            this.lblPrivilegio.Text = "Privilegio:";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.menuStrip1);
            this.groupBox1.Controls.Add(this.gbVerFichaMedica);
            this.groupBox1.Controls.Add(this.gbAgendaDiaria);
            this.groupBox1.Controls.Add(this.gbOpcionesUsuario);
            this.groupBox1.Controls.Add(this.gbAbrirConsultaMedica);
            this.groupBox1.Controls.Add(this.gbCerrarConsultaMedica);
            this.groupBox1.Location = new System.Drawing.Point(1, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 505);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agendaDiariaToolStripMenuItem1,
            this.fichasMédicasToolStripMenuItem,
            this.consultasMédicasToolStripMenuItem,
            this.atencionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 16);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(774, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // agendaDiariaToolStripMenuItem1
            // 
            this.agendaDiariaToolStripMenuItem1.Name = "agendaDiariaToolStripMenuItem1";
            this.agendaDiariaToolStripMenuItem1.Size = new System.Drawing.Size(92, 20);
            this.agendaDiariaToolStripMenuItem1.Text = "Agenda diaria";
            this.agendaDiariaToolStripMenuItem1.Click += new System.EventHandler(this.agendaDiariaToolStripMenuItem1_Click);
            // 
            // fichasMédicasToolStripMenuItem
            // 
            this.fichasMédicasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verFichaMédicaToolStripMenuItem});
            this.fichasMédicasToolStripMenuItem.Name = "fichasMédicasToolStripMenuItem";
            this.fichasMédicasToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.fichasMédicasToolStripMenuItem.Text = "Fichas médicas";
            // 
            // verFichaMédicaToolStripMenuItem
            // 
            this.verFichaMédicaToolStripMenuItem.Name = "verFichaMédicaToolStripMenuItem";
            this.verFichaMédicaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.verFichaMédicaToolStripMenuItem.Text = "Ver ficha médica";
            this.verFichaMédicaToolStripMenuItem.Click += new System.EventHandler(this.verFichaMédicaToolStripMenuItem_Click);
            // 
            // consultasMédicasToolStripMenuItem
            // 
            this.consultasMédicasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirConsultaMédicaToolStripMenuItem,
            this.cerrarConsultaMédicaToolStripMenuItem});
            this.consultasMédicasToolStripMenuItem.Name = "consultasMédicasToolStripMenuItem";
            this.consultasMédicasToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.consultasMédicasToolStripMenuItem.Text = "Consultas médicas";
            // 
            // abrirConsultaMédicaToolStripMenuItem
            // 
            this.abrirConsultaMédicaToolStripMenuItem.Name = "abrirConsultaMédicaToolStripMenuItem";
            this.abrirConsultaMédicaToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.abrirConsultaMédicaToolStripMenuItem.Text = "Abrir consulta médica";
            // 
            // cerrarConsultaMédicaToolStripMenuItem
            // 
            this.cerrarConsultaMédicaToolStripMenuItem.Name = "cerrarConsultaMédicaToolStripMenuItem";
            this.cerrarConsultaMédicaToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.cerrarConsultaMédicaToolStripMenuItem.Text = "Cerrar consulta médica";
            // 
            // atencionesToolStripMenuItem
            // 
            this.atencionesToolStripMenuItem.Name = "atencionesToolStripMenuItem";
            this.atencionesToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.atencionesToolStripMenuItem.Text = "Atenciones";
            // 
            // gbVerFichaMedica
            // 
            this.gbVerFichaMedica.Controls.Add(this.gbDatosPacienteVFM);
            this.gbVerFichaMedica.Controls.Add(this.dgEntradaVFM);
            this.gbVerFichaMedica.Controls.Add(this.label11);
            this.gbVerFichaMedica.Controls.Add(this.tbVerificadorVFM);
            this.gbVerFichaMedica.Controls.Add(this.tbRUNVFM);
            this.gbVerFichaMedica.Controls.Add(this.label10);
            this.gbVerFichaMedica.Controls.Add(this.btnBuscarVFM);
            this.gbVerFichaMedica.Location = new System.Drawing.Point(6, 43);
            this.gbVerFichaMedica.Name = "gbVerFichaMedica";
            this.gbVerFichaMedica.Size = new System.Drawing.Size(768, 462);
            this.gbVerFichaMedica.TabIndex = 5;
            this.gbVerFichaMedica.TabStop = false;
            this.gbVerFichaMedica.Text = "Ver ficha médica";
            this.gbVerFichaMedica.Visible = false;
            // 
            // dgEntradaVFM
            // 
            this.dgEntradaVFM.AllowUserToAddRows = false;
            this.dgEntradaVFM.AllowUserToDeleteRows = false;
            this.dgEntradaVFM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgEntradaVFM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEntradaVFM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreEntrada,
            this.ContenidoEntrada,
            this.FechaEntrada});
            this.dgEntradaVFM.Location = new System.Drawing.Point(169, 276);
            this.dgEntradaVFM.Name = "dgEntradaVFM";
            this.dgEntradaVFM.ReadOnly = true;
            this.dgEntradaVFM.Size = new System.Drawing.Size(400, 150);
            this.dgEntradaVFM.TabIndex = 6;
            this.dgEntradaVFM.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEntradaVFM_CellClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(421, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(10, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "-";
            // 
            // tbVerificadorVFM
            // 
            this.tbVerificadorVFM.Location = new System.Drawing.Point(434, 70);
            this.tbVerificadorVFM.Name = "tbVerificadorVFM";
            this.tbVerificadorVFM.Size = new System.Drawing.Size(23, 20);
            this.tbVerificadorVFM.TabIndex = 4;
            // 
            // tbRUNVFM
            // 
            this.tbRUNVFM.Location = new System.Drawing.Point(274, 70);
            this.tbRUNVFM.Name = "tbRUNVFM";
            this.tbRUNVFM.Size = new System.Drawing.Size(143, 20);
            this.tbRUNVFM.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(128, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Buscar paciente por RUN";
            // 
            // btnBuscarVFM
            // 
            this.btnBuscarVFM.Location = new System.Drawing.Point(490, 68);
            this.btnBuscarVFM.Name = "btnBuscarVFM";
            this.btnBuscarVFM.Size = new System.Drawing.Size(113, 23);
            this.btnBuscarVFM.TabIndex = 1;
            this.btnBuscarVFM.Text = "Buscar";
            this.btnBuscarVFM.UseVisualStyleBackColor = true;
            this.btnBuscarVFM.Click += new System.EventHandler(this.btnBuscarVFM_Click);
            // 
            // gbAgendaDiaria
            // 
            this.gbAgendaDiaria.Controls.Add(this.dgAgendaDiaria);
            this.gbAgendaDiaria.Location = new System.Drawing.Point(6, 43);
            this.gbAgendaDiaria.Name = "gbAgendaDiaria";
            this.gbAgendaDiaria.Size = new System.Drawing.Size(768, 462);
            this.gbAgendaDiaria.TabIndex = 4;
            this.gbAgendaDiaria.TabStop = false;
            this.gbAgendaDiaria.Text = "Agenda diaria";
            this.gbAgendaDiaria.Visible = false;
            // 
            // dgAgendaDiaria
            // 
            this.dgAgendaDiaria.AllowUserToAddRows = false;
            this.dgAgendaDiaria.AllowUserToDeleteRows = false;
            this.dgAgendaDiaria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgAgendaDiaria.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.dgAgendaDiaria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAgendaDiaria.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgAgendaDiaria.Location = new System.Drawing.Point(8, 32);
            this.dgAgendaDiaria.Name = "dgAgendaDiaria";
            this.dgAgendaDiaria.ReadOnly = true;
            this.dgAgendaDiaria.Size = new System.Drawing.Size(754, 424);
            this.dgAgendaDiaria.TabIndex = 1;
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
            // gbAbrirConsultaMedica
            // 
            this.gbAbrirConsultaMedica.Controls.Add(this.cbHoraACM);
            this.gbAbrirConsultaMedica.Controls.Add(this.cbFechaACM);
            this.gbAbrirConsultaMedica.Controls.Add(this.cbPrestacionACM);
            this.gbAbrirConsultaMedica.Controls.Add(this.cbPersonalMedicoACM);
            this.gbAbrirConsultaMedica.Controls.Add(this.cbEspecialidadACM);
            this.gbAbrirConsultaMedica.Controls.Add(this.label6);
            this.gbAbrirConsultaMedica.Controls.Add(this.label5);
            this.gbAbrirConsultaMedica.Controls.Add(this.label4);
            this.gbAbrirConsultaMedica.Controls.Add(this.label3);
            this.gbAbrirConsultaMedica.Controls.Add(this.label2);
            this.gbAbrirConsultaMedica.Controls.Add(this.btnAgendarAtencionACM);
            this.gbAbrirConsultaMedica.Controls.Add(this.textBox2);
            this.gbAbrirConsultaMedica.Controls.Add(this.textBox1);
            this.gbAbrirConsultaMedica.Controls.Add(this.label1);
            this.gbAbrirConsultaMedica.Location = new System.Drawing.Point(6, 43);
            this.gbAbrirConsultaMedica.Name = "gbAbrirConsultaMedica";
            this.gbAbrirConsultaMedica.Size = new System.Drawing.Size(768, 456);
            this.gbAbrirConsultaMedica.TabIndex = 1;
            this.gbAbrirConsultaMedica.TabStop = false;
            this.gbAbrirConsultaMedica.Text = "Abrir consulta medica";
            this.gbAbrirConsultaMedica.Visible = false;
            // 
            // cbHoraACM
            // 
            this.cbHoraACM.FormattingEnabled = true;
            this.cbHoraACM.Location = new System.Drawing.Point(287, 280);
            this.cbHoraACM.Name = "cbHoraACM";
            this.cbHoraACM.Size = new System.Drawing.Size(170, 21);
            this.cbHoraACM.TabIndex = 13;
            // 
            // cbFechaACM
            // 
            this.cbFechaACM.FormattingEnabled = true;
            this.cbFechaACM.Location = new System.Drawing.Point(287, 240);
            this.cbFechaACM.Name = "cbFechaACM";
            this.cbFechaACM.Size = new System.Drawing.Size(253, 21);
            this.cbFechaACM.TabIndex = 12;
            // 
            // cbPrestacionACM
            // 
            this.cbPrestacionACM.FormattingEnabled = true;
            this.cbPrestacionACM.Location = new System.Drawing.Point(287, 200);
            this.cbPrestacionACM.Name = "cbPrestacionACM";
            this.cbPrestacionACM.Size = new System.Drawing.Size(316, 21);
            this.cbPrestacionACM.TabIndex = 11;
            // 
            // cbPersonalMedicoACM
            // 
            this.cbPersonalMedicoACM.FormattingEnabled = true;
            this.cbPersonalMedicoACM.Location = new System.Drawing.Point(287, 161);
            this.cbPersonalMedicoACM.Name = "cbPersonalMedicoACM";
            this.cbPersonalMedicoACM.Size = new System.Drawing.Size(316, 21);
            this.cbPersonalMedicoACM.TabIndex = 10;
            // 
            // cbEspecialidadACM
            // 
            this.cbEspecialidadACM.FormattingEnabled = true;
            this.cbEspecialidadACM.Location = new System.Drawing.Point(287, 125);
            this.cbEspecialidadACM.Name = "cbEspecialidadACM";
            this.cbEspecialidadACM.Size = new System.Drawing.Size(316, 21);
            this.cbEspecialidadACM.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Hora:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Fecha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Prestación:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Personal médico:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Especialidad:";
            // 
            // btnAgendarAtencionACM
            // 
            this.btnAgendarAtencionACM.Location = new System.Drawing.Point(310, 388);
            this.btnAgendarAtencionACM.Name = "btnAgendarAtencionACM";
            this.btnAgendarAtencionACM.Size = new System.Drawing.Size(162, 23);
            this.btnAgendarAtencionACM.TabIndex = 3;
            this.btnAgendarAtencionACM.Text = "Agendar atención";
            this.btnAgendarAtencionACM.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(437, 87);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(20, 20);
            this.textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(287, 87);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rut de paciente:";
            // 
            // gbCerrarConsultaMedica
            // 
            this.gbCerrarConsultaMedica.Location = new System.Drawing.Point(6, 43);
            this.gbCerrarConsultaMedica.Name = "gbCerrarConsultaMedica";
            this.gbCerrarConsultaMedica.Size = new System.Drawing.Size(768, 462);
            this.gbCerrarConsultaMedica.TabIndex = 2;
            this.gbCerrarConsultaMedica.TabStop = false;
            this.gbCerrarConsultaMedica.Text = "Cerrar consulta medica";
            this.gbCerrarConsultaMedica.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPrivilegio);
            this.groupBox2.Location = new System.Drawing.Point(1, 532);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(780, 27);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnModificarUser);
            this.groupBox3.Controls.Add(this.lblUsuarioConectado);
            this.groupBox3.Controls.Add(this.btnSesion);
            this.groupBox3.Location = new System.Drawing.Point(1, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(780, 41);
            this.groupBox3.TabIndex = 5;
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
            // NombreEntrada
            // 
            this.NombreEntrada.HeaderText = "Nombre entrada";
            this.NombreEntrada.Name = "NombreEntrada";
            this.NombreEntrada.ReadOnly = true;
            this.NombreEntrada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NombreEntrada.Width = 80;
            // 
            // ContenidoEntrada
            // 
            this.ContenidoEntrada.HeaderText = "ContenidoEntrada";
            this.ContenidoEntrada.Name = "ContenidoEntrada";
            this.ContenidoEntrada.ReadOnly = true;
            this.ContenidoEntrada.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ContenidoEntrada.Text = "Ver";
            this.ContenidoEntrada.Width = 98;
            // 
            // FechaEntrada
            // 
            this.FechaEntrada.HeaderText = "Fecha de entrada";
            this.FechaEntrada.Name = "FechaEntrada";
            this.FechaEntrada.ReadOnly = true;
            this.FechaEntrada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FechaEntrada.Width = 87;
            // 
            // gbDatosPacienteVFM
            // 
            this.gbDatosPacienteVFM.Controls.Add(this.lbFechaNacVFM);
            this.gbDatosPacienteVFM.Controls.Add(this.lbSexoVFM);
            this.gbDatosPacienteVFM.Controls.Add(this.lbRun);
            this.gbDatosPacienteVFM.Controls.Add(this.lbEmailVFM);
            this.gbDatosPacienteVFM.Controls.Add(this.lbNombreVFM);
            this.gbDatosPacienteVFM.Location = new System.Drawing.Point(67, 113);
            this.gbDatosPacienteVFM.Name = "gbDatosPacienteVFM";
            this.gbDatosPacienteVFM.Size = new System.Drawing.Size(621, 134);
            this.gbDatosPacienteVFM.TabIndex = 7;
            this.gbDatosPacienteVFM.TabStop = false;
            this.gbDatosPacienteVFM.Text = "Datos paciente";
            // 
            // lbNombreVFM
            // 
            this.lbNombreVFM.AutoSize = true;
            this.lbNombreVFM.Location = new System.Drawing.Point(21, 29);
            this.lbNombreVFM.Name = "lbNombreVFM";
            this.lbNombreVFM.Size = new System.Drawing.Size(50, 13);
            this.lbNombreVFM.TabIndex = 0;
            this.lbNombreVFM.Text = "Nombre: ";
            // 
            // lbEmailVFM
            // 
            this.lbEmailVFM.AutoSize = true;
            this.lbEmailVFM.Location = new System.Drawing.Point(21, 61);
            this.lbEmailVFM.Name = "lbEmailVFM";
            this.lbEmailVFM.Size = new System.Drawing.Size(35, 13);
            this.lbEmailVFM.TabIndex = 1;
            this.lbEmailVFM.Text = "Email:";
            // 
            // lbRun
            // 
            this.lbRun.AutoSize = true;
            this.lbRun.Location = new System.Drawing.Point(21, 95);
            this.lbRun.Name = "lbRun";
            this.lbRun.Size = new System.Drawing.Size(30, 13);
            this.lbRun.TabIndex = 2;
            this.lbRun.Text = "Run:";
            // 
            // lbSexoVFM
            // 
            this.lbSexoVFM.AutoSize = true;
            this.lbSexoVFM.Location = new System.Drawing.Point(227, 95);
            this.lbSexoVFM.Name = "lbSexoVFM";
            this.lbSexoVFM.Size = new System.Drawing.Size(34, 13);
            this.lbSexoVFM.TabIndex = 3;
            this.lbSexoVFM.Text = "Sexo:";
            // 
            // lbFechaNacVFM
            // 
            this.lbFechaNacVFM.AutoSize = true;
            this.lbFechaNacVFM.Location = new System.Drawing.Point(354, 95);
            this.lbFechaNacVFM.Name = "lbFechaNacVFM";
            this.lbFechaNacVFM.Size = new System.Drawing.Size(94, 13);
            this.lbFechaNacVFM.TabIndex = 4;
            this.lbFechaNacVFM.Text = "Fecha nacimiento:";
            // 
            // FrmMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMedico";
            this.Text = "Inicio";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMedico_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbVerFichaMedica.ResumeLayout(false);
            this.gbVerFichaMedica.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEntradaVFM)).EndInit();
            this.gbAgendaDiaria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAgendaDiaria)).EndInit();
            this.gbOpcionesUsuario.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbAbrirConsultaMedica.ResumeLayout(false);
            this.gbAbrirConsultaMedica.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbDatosPacienteVFM.ResumeLayout(false);
            this.gbDatosPacienteVFM.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUsuarioConectado;
        private System.Windows.Forms.Label lblPrivilegio;
        private System.Windows.Forms.Button btnSesion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem agendaDiariaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fichasMédicasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasMédicasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirConsultaMédicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarConsultaMédicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atencionesToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbAbrirConsultaMedica;
        private System.Windows.Forms.GroupBox gbCerrarConsultaMedica;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgendarAtencionACM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbHoraACM;
        private System.Windows.Forms.ComboBox cbFechaACM;
        private System.Windows.Forms.ComboBox cbPrestacionACM;
        private System.Windows.Forms.ComboBox cbPersonalMedicoACM;
        private System.Windows.Forms.ComboBox cbEspecialidadACM;
        private System.Windows.Forms.Button btnModificarUser;
        private System.Windows.Forms.GroupBox gbOpcionesUsuario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbNuevoMail;
        private System.Windows.Forms.Button btnCambiarEmail;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbContrasenaActual;
        private System.Windows.Forms.Button btnCambiarContrasena;
        private System.Windows.Forms.TextBox tbContrasenaNueva;
        private System.Windows.Forms.GroupBox gbAgendaDiaria;
        private System.Windows.Forms.DataGridView dgAgendaDiaria;
        private System.Windows.Forms.GroupBox gbVerFichaMedica;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbVerificadorVFM;
        private System.Windows.Forms.TextBox tbRUNVFM;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnBuscarVFM;
        private System.Windows.Forms.DataGridView dgEntradaVFM;
        private System.Windows.Forms.ToolStripMenuItem verFichaMédicaToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreEntrada;
        private System.Windows.Forms.DataGridViewButtonColumn ContenidoEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEntrada;
        private System.Windows.Forms.GroupBox gbDatosPacienteVFM;
        private System.Windows.Forms.Label lbFechaNacVFM;
        private System.Windows.Forms.Label lbSexoVFM;
        private System.Windows.Forms.Label lbRun;
        private System.Windows.Forms.Label lbEmailVFM;
        private System.Windows.Forms.Label lbNombreVFM;
    }
}