namespace CheekiBreeki.CMH.Terminal.Views
{
    partial class FrmMantenerEquipo
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
            this.gbMantenerEquipo = new System.Windows.Forms.GroupBox();
            this.btnCargarEquipo_Eq = new System.Windows.Forms.Button();
            this.btnNuevoEquipo_Eq = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtNombreEquipo = new System.Windows.Forms.TextBox();
            this.btnGuardar_Eq = new System.Windows.Forms.Button();
            this.btnRegistrar_Eq = new System.Windows.Forms.Button();
            this.txtCantidad_Eq = new System.Windows.Forms.TextBox();
            this.lblNombreTipo = new System.Windows.Forms.Label();
            this.lblCantidad_Eq = new System.Windows.Forms.Label();
            this.dgEquipo_Eq = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mantenedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pacienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.gbMantenerEquipo.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEquipo_Eq)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.gbMantenerEquipo);
            this.groupBox1.Controls.Add(this.menuStrip1);
            this.groupBox1.Controls.Add(this.gbOpcionesUsuario);
            this.groupBox1.Location = new System.Drawing.Point(2, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 505);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // gbMantenerEquipo
            // 
            this.gbMantenerEquipo.Controls.Add(this.btnCargarEquipo_Eq);
            this.gbMantenerEquipo.Controls.Add(this.btnNuevoEquipo_Eq);
            this.gbMantenerEquipo.Controls.Add(this.groupBox6);
            this.gbMantenerEquipo.Controls.Add(this.dgEquipo_Eq);
            this.gbMantenerEquipo.Location = new System.Drawing.Point(6, 43);
            this.gbMantenerEquipo.Name = "gbMantenerEquipo";
            this.gbMantenerEquipo.Size = new System.Drawing.Size(768, 462);
            this.gbMantenerEquipo.TabIndex = 4;
            this.gbMantenerEquipo.TabStop = false;
            this.gbMantenerEquipo.Text = "Mantener Equipo";
            // 
            // btnCargarEquipo_Eq
            // 
            this.btnCargarEquipo_Eq.Location = new System.Drawing.Point(391, 266);
            this.btnCargarEquipo_Eq.Name = "btnCargarEquipo_Eq";
            this.btnCargarEquipo_Eq.Size = new System.Drawing.Size(100, 23);
            this.btnCargarEquipo_Eq.TabIndex = 7;
            this.btnCargarEquipo_Eq.Text = "Cargar Equipo";
            this.btnCargarEquipo_Eq.UseVisualStyleBackColor = true;
            this.btnCargarEquipo_Eq.Click += new System.EventHandler(this.btnCargarEquipo_Eq_Click);
            // 
            // btnNuevoEquipo_Eq
            // 
            this.btnNuevoEquipo_Eq.Location = new System.Drawing.Point(212, 266);
            this.btnNuevoEquipo_Eq.Name = "btnNuevoEquipo_Eq";
            this.btnNuevoEquipo_Eq.Size = new System.Drawing.Size(90, 23);
            this.btnNuevoEquipo_Eq.TabIndex = 6;
            this.btnNuevoEquipo_Eq.Text = "Nuevo Equipo";
            this.btnNuevoEquipo_Eq.UseVisualStyleBackColor = true;
            this.btnNuevoEquipo_Eq.Click += new System.EventHandler(this.btnNuevoEquipo_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtNombreEquipo);
            this.groupBox6.Controls.Add(this.btnGuardar_Eq);
            this.groupBox6.Controls.Add(this.btnRegistrar_Eq);
            this.groupBox6.Controls.Add(this.txtCantidad_Eq);
            this.groupBox6.Controls.Add(this.lblNombreTipo);
            this.groupBox6.Controls.Add(this.lblCantidad_Eq);
            this.groupBox6.Location = new System.Drawing.Point(16, 295);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(732, 153);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Equipo";
            // 
            // txtNombreEquipo
            // 
            this.txtNombreEquipo.Location = new System.Drawing.Point(352, 67);
            this.txtNombreEquipo.Name = "txtNombreEquipo";
            this.txtNombreEquipo.Size = new System.Drawing.Size(196, 20);
            this.txtNombreEquipo.TabIndex = 6;
            // 
            // btnGuardar_Eq
            // 
            this.btnGuardar_Eq.Enabled = false;
            this.btnGuardar_Eq.Location = new System.Drawing.Point(375, 127);
            this.btnGuardar_Eq.Name = "btnGuardar_Eq";
            this.btnGuardar_Eq.Size = new System.Drawing.Size(100, 23);
            this.btnGuardar_Eq.TabIndex = 5;
            this.btnGuardar_Eq.Text = "Guardar Cambios";
            this.btnGuardar_Eq.UseVisualStyleBackColor = true;
            this.btnGuardar_Eq.Click += new System.EventHandler(this.btnGuardar_Eq_Click);
            // 
            // btnRegistrar_Eq
            // 
            this.btnRegistrar_Eq.Enabled = false;
            this.btnRegistrar_Eq.Location = new System.Drawing.Point(211, 127);
            this.btnRegistrar_Eq.Name = "btnRegistrar_Eq";
            this.btnRegistrar_Eq.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar_Eq.TabIndex = 4;
            this.btnRegistrar_Eq.Text = "Registrar";
            this.btnRegistrar_Eq.UseVisualStyleBackColor = true;
            this.btnRegistrar_Eq.Click += new System.EventHandler(this.btnRegistrar_Eq_Click);
            // 
            // txtCantidad_Eq
            // 
            this.txtCantidad_Eq.Location = new System.Drawing.Point(352, 34);
            this.txtCantidad_Eq.Name = "txtCantidad_Eq";
            this.txtCantidad_Eq.Size = new System.Drawing.Size(196, 20);
            this.txtCantidad_Eq.TabIndex = 2;
            // 
            // lblNombreTipo
            // 
            this.lblNombreTipo.AutoSize = true;
            this.lblNombreTipo.Location = new System.Drawing.Point(150, 74);
            this.lblNombreTipo.Name = "lblNombreTipo";
            this.lblNombreTipo.Size = new System.Drawing.Size(79, 13);
            this.lblNombreTipo.TabIndex = 1;
            this.lblNombreTipo.Text = "Nombre equipo";
            // 
            // lblCantidad_Eq
            // 
            this.lblCantidad_Eq.AutoSize = true;
            this.lblCantidad_Eq.Location = new System.Drawing.Point(150, 37);
            this.lblCantidad_Eq.Name = "lblCantidad_Eq";
            this.lblCantidad_Eq.Size = new System.Drawing.Size(49, 13);
            this.lblCantidad_Eq.TabIndex = 0;
            this.lblCantidad_Eq.Text = "Cantidad";
            // 
            // dgEquipo_Eq
            // 
            this.dgEquipo_Eq.AllowUserToAddRows = false;
            this.dgEquipo_Eq.AllowUserToDeleteRows = false;
            this.dgEquipo_Eq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEquipo_Eq.Location = new System.Drawing.Point(16, 29);
            this.dgEquipo_Eq.Name = "dgEquipo_Eq";
            this.dgEquipo_Eq.ReadOnly = true;
            this.dgEquipo_Eq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEquipo_Eq.Size = new System.Drawing.Size(732, 226);
            this.dgEquipo_Eq.TabIndex = 4;
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
            // FrmMantenerEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMantenerEquipo";
            this.Text = "Centro médico Hipócrates";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmJefeOp_FormClosed);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbMantenerEquipo.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEquipo_Eq)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbContrasenaActual;
        private System.Windows.Forms.Button btnCambiarContrasena;
        private System.Windows.Forms.TextBox tbContrasenaNueva;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem pacienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equipoToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbMantenerEquipo;
        private System.Windows.Forms.DataGridView dgEquipo_Eq;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblNombreTipo;
        private System.Windows.Forms.Label lblCantidad_Eq;
        private System.Windows.Forms.Button btnCargarEquipo_Eq;
        private System.Windows.Forms.Button btnNuevoEquipo_Eq;
        private System.Windows.Forms.Button btnGuardar_Eq;
        private System.Windows.Forms.Button btnRegistrar_Eq;
        private System.Windows.Forms.TextBox txtCantidad_Eq;
        private System.Windows.Forms.TextBox txtNombreEquipo;
    }
}