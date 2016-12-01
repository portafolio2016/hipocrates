namespace CheekiBreeki.CMH.Terminal.Views
{
    partial class FrmTecnologo
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mantenedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarAtenciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPrivilegio = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbCerrarAtencionMedica = new System.Windows.Forms.GroupBox();
            this.lblError_CAM = new System.Windows.Forms.Label();
            this.lstAtenciones_CAM = new System.Windows.Forms.ListBox();
            this.btnBuscarPaciente_CAM = new System.Windows.Forms.Button();
            this.txtDV_CAM = new System.Windows.Forms.TextBox();
            this.txtRutPaciente_CAM = new System.Windows.Forms.TextBox();
            this.lblRutPaciente_CAM = new System.Windows.Forms.Label();
            this.btnCrearResultado_CAM = new System.Windows.Forms.Button();
            this.btnArchivo_CAM = new System.Windows.Forms.Button();
            this.rtArchivo_CAM = new System.Windows.Forms.RichTextBox();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.rtComentario_CAM = new System.Windows.Forms.RichTextBox();
            this.lblComentario_CAM = new System.Windows.Forms.Label();
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
            this.gbAgendaDiaria = new System.Windows.Forms.GroupBox();
            this.dgAgendaDiaria = new System.Windows.Forms.DataGridView();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbCerrarAtencionMedica.SuspendLayout();
            this.gbOpcionesUsuario.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbAgendaDiaria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAgendaDiaria)).BeginInit();
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
            this.groupBox3.TabIndex = 11;
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
            this.btnModificarUser.Click += new System.EventHandler(this.btnModificarUser_Click_1);
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
            this.btnSesion.Click += new System.EventHandler(this.btnSesion_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenedoresToolStripMenuItem,
            this.cerrarAtenciónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 16);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(774, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mantenedoresToolStripMenuItem
            // 
            this.mantenedoresToolStripMenuItem.Name = "mantenedoresToolStripMenuItem";
            this.mantenedoresToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.mantenedoresToolStripMenuItem.Text = "Agenda diaria";
            this.mantenedoresToolStripMenuItem.Click += new System.EventHandler(this.mantenedoresToolStripMenuItem_Click);
            // 
            // cerrarAtenciónToolStripMenuItem
            // 
            this.cerrarAtenciónToolStripMenuItem.Name = "cerrarAtenciónToolStripMenuItem";
            this.cerrarAtenciónToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.cerrarAtenciónToolStripMenuItem.Text = "Cerrar atención";
            this.cerrarAtenciónToolStripMenuItem.Click += new System.EventHandler(this.cerrarAtenciónToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPrivilegio);
            this.groupBox2.Location = new System.Drawing.Point(2, 533);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(780, 27);
            this.groupBox2.TabIndex = 10;
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
            this.groupBox1.Controls.Add(this.gbCerrarAtencionMedica);
            this.groupBox1.Controls.Add(this.gbOpcionesUsuario);
            this.groupBox1.Controls.Add(this.gbAgendaDiaria);
            this.groupBox1.Location = new System.Drawing.Point(2, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 505);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // gbCerrarAtencionMedica
            // 
            this.gbCerrarAtencionMedica.Controls.Add(this.lblError_CAM);
            this.gbCerrarAtencionMedica.Controls.Add(this.lstAtenciones_CAM);
            this.gbCerrarAtencionMedica.Controls.Add(this.btnBuscarPaciente_CAM);
            this.gbCerrarAtencionMedica.Controls.Add(this.txtDV_CAM);
            this.gbCerrarAtencionMedica.Controls.Add(this.txtRutPaciente_CAM);
            this.gbCerrarAtencionMedica.Controls.Add(this.lblRutPaciente_CAM);
            this.gbCerrarAtencionMedica.Controls.Add(this.btnCrearResultado_CAM);
            this.gbCerrarAtencionMedica.Controls.Add(this.btnArchivo_CAM);
            this.gbCerrarAtencionMedica.Controls.Add(this.rtArchivo_CAM);
            this.gbCerrarAtencionMedica.Controls.Add(this.lblArchivo);
            this.gbCerrarAtencionMedica.Controls.Add(this.rtComentario_CAM);
            this.gbCerrarAtencionMedica.Controls.Add(this.lblComentario_CAM);
            this.gbCerrarAtencionMedica.Location = new System.Drawing.Point(6, 43);
            this.gbCerrarAtencionMedica.Name = "gbCerrarAtencionMedica";
            this.gbCerrarAtencionMedica.Size = new System.Drawing.Size(768, 448);
            this.gbCerrarAtencionMedica.TabIndex = 36;
            this.gbCerrarAtencionMedica.TabStop = false;
            this.gbCerrarAtencionMedica.Text = "Cerrar atención medica";
            this.gbCerrarAtencionMedica.Visible = false;
            // 
            // lblError_CAM
            // 
            this.lblError_CAM.AutoSize = true;
            this.lblError_CAM.Location = new System.Drawing.Point(380, 64);
            this.lblError_CAM.Name = "lblError_CAM";
            this.lblError_CAM.Size = new System.Drawing.Size(39, 13);
            this.lblError_CAM.TabIndex = 11;
            this.lblError_CAM.Text = "lblError";
            this.lblError_CAM.Visible = false;
            // 
            // lstAtenciones_CAM
            // 
            this.lstAtenciones_CAM.FormattingEnabled = true;
            this.lstAtenciones_CAM.Location = new System.Drawing.Point(194, 86);
            this.lstAtenciones_CAM.Name = "lstAtenciones_CAM";
            this.lstAtenciones_CAM.Size = new System.Drawing.Size(415, 95);
            this.lstAtenciones_CAM.TabIndex = 10;
            this.lstAtenciones_CAM.SelectedIndexChanged += new System.EventHandler(this.lstAtenciones_CAM_SelectedIndexChanged);
            // 
            // btnBuscarPaciente_CAM
            // 
            this.btnBuscarPaciente_CAM.Location = new System.Drawing.Point(488, 31);
            this.btnBuscarPaciente_CAM.Name = "btnBuscarPaciente_CAM";
            this.btnBuscarPaciente_CAM.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarPaciente_CAM.TabIndex = 9;
            this.btnBuscarPaciente_CAM.Text = "Buscar";
            this.btnBuscarPaciente_CAM.UseVisualStyleBackColor = true;
            this.btnBuscarPaciente_CAM.Click += new System.EventHandler(this.btnBuscarPaciente_CAM_Click);
            // 
            // txtDV_CAM
            // 
            this.txtDV_CAM.Location = new System.Drawing.Point(439, 33);
            this.txtDV_CAM.MaxLength = 1;
            this.txtDV_CAM.Name = "txtDV_CAM";
            this.txtDV_CAM.Size = new System.Drawing.Size(29, 20);
            this.txtDV_CAM.TabIndex = 8;
            this.txtDV_CAM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDv_KeyPress);
            // 
            // txtRutPaciente_CAM
            // 
            this.txtRutPaciente_CAM.Location = new System.Drawing.Point(334, 33);
            this.txtRutPaciente_CAM.MaxLength = 8;
            this.txtRutPaciente_CAM.Name = "txtRutPaciente_CAM";
            this.txtRutPaciente_CAM.Size = new System.Drawing.Size(100, 20);
            this.txtRutPaciente_CAM.TabIndex = 7;
            this.txtRutPaciente_CAM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRut_KeyPress);
            // 
            // lblRutPaciente_CAM
            // 
            this.lblRutPaciente_CAM.AutoSize = true;
            this.lblRutPaciente_CAM.Location = new System.Drawing.Point(244, 36);
            this.lblRutPaciente_CAM.Name = "lblRutPaciente_CAM";
            this.lblRutPaciente_CAM.Size = new System.Drawing.Size(69, 13);
            this.lblRutPaciente_CAM.TabIndex = 6;
            this.lblRutPaciente_CAM.Text = "Rut Paciente";
            // 
            // btnCrearResultado_CAM
            // 
            this.btnCrearResultado_CAM.Location = new System.Drawing.Point(364, 408);
            this.btnCrearResultado_CAM.Name = "btnCrearResultado_CAM";
            this.btnCrearResultado_CAM.Size = new System.Drawing.Size(93, 23);
            this.btnCrearResultado_CAM.TabIndex = 5;
            this.btnCrearResultado_CAM.Text = "Crear resultado";
            this.btnCrearResultado_CAM.UseVisualStyleBackColor = true;
            this.btnCrearResultado_CAM.Click += new System.EventHandler(this.btnCrearResultado_CAM_Click);
            // 
            // btnArchivo_CAM
            // 
            this.btnArchivo_CAM.Location = new System.Drawing.Point(518, 345);
            this.btnArchivo_CAM.Name = "btnArchivo_CAM";
            this.btnArchivo_CAM.Size = new System.Drawing.Size(75, 24);
            this.btnArchivo_CAM.TabIndex = 4;
            this.btnArchivo_CAM.Text = "Subir";
            this.btnArchivo_CAM.UseVisualStyleBackColor = true;
            this.btnArchivo_CAM.Click += new System.EventHandler(this.btnArchivo_CAM_Click);
            // 
            // rtArchivo_CAM
            // 
            this.rtArchivo_CAM.Enabled = false;
            this.rtArchivo_CAM.Location = new System.Drawing.Point(274, 346);
            this.rtArchivo_CAM.Name = "rtArchivo_CAM";
            this.rtArchivo_CAM.Size = new System.Drawing.Size(229, 23);
            this.rtArchivo_CAM.TabIndex = 3;
            this.rtArchivo_CAM.Text = "";
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Location = new System.Drawing.Point(199, 352);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(43, 13);
            this.lblArchivo.TabIndex = 2;
            this.lblArchivo.Text = "Archivo";
            // 
            // rtComentario_CAM
            // 
            this.rtComentario_CAM.Location = new System.Drawing.Point(197, 214);
            this.rtComentario_CAM.Name = "rtComentario_CAM";
            this.rtComentario_CAM.Size = new System.Drawing.Size(412, 98);
            this.rtComentario_CAM.TabIndex = 1;
            this.rtComentario_CAM.Text = "";
            // 
            // lblComentario_CAM
            // 
            this.lblComentario_CAM.AutoSize = true;
            this.lblComentario_CAM.Location = new System.Drawing.Point(115, 213);
            this.lblComentario_CAM.Name = "lblComentario_CAM";
            this.lblComentario_CAM.Size = new System.Drawing.Size(60, 13);
            this.lblComentario_CAM.TabIndex = 0;
            this.lblComentario_CAM.Text = "Comentario";
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
            // gbAgendaDiaria
            // 
            this.gbAgendaDiaria.Controls.Add(this.dgAgendaDiaria);
            this.gbAgendaDiaria.Location = new System.Drawing.Point(6, 43);
            this.gbAgendaDiaria.Name = "gbAgendaDiaria";
            this.gbAgendaDiaria.Size = new System.Drawing.Size(768, 462);
            this.gbAgendaDiaria.TabIndex = 12;
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
            // FrmTecnologo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmTecnologo";
            this.Text = "Centro médico Hipócrates";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmTecnologo_FormClosed);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbCerrarAtencionMedica.ResumeLayout(false);
            this.gbCerrarAtencionMedica.PerformLayout();
            this.gbOpcionesUsuario.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbAgendaDiaria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAgendaDiaria)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnModificarUser;
        private System.Windows.Forms.Label lblUsuarioConectado;
        private System.Windows.Forms.Button btnSesion;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mantenedoresToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPrivilegio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbOpcionesUsuario;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbNuevoMail;
        private System.Windows.Forms.Button btnCambiarEmail;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbContrasenaActual;
        private System.Windows.Forms.Button btnCambiarContrasena;
        private System.Windows.Forms.TextBox tbContrasenaNueva;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbCerrarAtencionMedica;
        private System.Windows.Forms.Label lblError_CAM;
        private System.Windows.Forms.ListBox lstAtenciones_CAM;
        private System.Windows.Forms.Button btnBuscarPaciente_CAM;
        private System.Windows.Forms.TextBox txtDV_CAM;
        private System.Windows.Forms.TextBox txtRutPaciente_CAM;
        private System.Windows.Forms.Label lblRutPaciente_CAM;
        private System.Windows.Forms.Button btnCrearResultado_CAM;
        private System.Windows.Forms.Button btnArchivo_CAM;
        private System.Windows.Forms.RichTextBox rtArchivo_CAM;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.RichTextBox rtComentario_CAM;
        private System.Windows.Forms.Label lblComentario_CAM;
        private System.Windows.Forms.ToolStripMenuItem cerrarAtenciónToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbAgendaDiaria;
        private System.Windows.Forms.DataGridView dgAgendaDiaria;
    }
}