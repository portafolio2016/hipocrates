namespace CheekiBreeki.CMH.Terminal.Views
{
    partial class FemEnfermero
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
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarOrdenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPrivilegio = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbAbrirOrdenAnalisis = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAbrirOrden = new System.Windows.Forms.Button();
            this.dgAtencionesAOA = new System.Windows.Forms.DataGridView();
            this.NombrePaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaExamen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.gbCerrarOrdenAnalisis = new System.Windows.Forms.GroupBox();
            this.btCerrarOrdenAnalisis = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgCerrarOrdenAnalisis = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaAperturaOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbAbrirOrdenAnalisis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAtencionesAOA)).BeginInit();
            this.gbOpcionesUsuario.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbCerrarOrdenAnalisis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCerrarOrdenAnalisis)).BeginInit();
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
            this.abrirToolStripMenuItem,
            this.cerrarOrdenToolStripMenuItem});
            this.mantenedoresToolStripMenuItem.Name = "mantenedoresToolStripMenuItem";
            this.mantenedoresToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.mantenedoresToolStripMenuItem.Text = "Orden de análisis";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abrirToolStripMenuItem.Text = "Abrir orden";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // cerrarOrdenToolStripMenuItem
            // 
            this.cerrarOrdenToolStripMenuItem.Name = "cerrarOrdenToolStripMenuItem";
            this.cerrarOrdenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cerrarOrdenToolStripMenuItem.Text = "Cerrar orden";
            this.cerrarOrdenToolStripMenuItem.Click += new System.EventHandler(this.cerrarOrdenToolStripMenuItem_Click);
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
            this.groupBox1.Controls.Add(this.gbCerrarOrdenAnalisis);
            this.groupBox1.Controls.Add(this.gbOpcionesUsuario);
            this.groupBox1.Controls.Add(this.gbAbrirOrdenAnalisis);
            this.groupBox1.Location = new System.Drawing.Point(2, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 505);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // gbAbrirOrdenAnalisis
            // 
            this.gbAbrirOrdenAnalisis.Controls.Add(this.label1);
            this.gbAbrirOrdenAnalisis.Controls.Add(this.btnAbrirOrden);
            this.gbAbrirOrdenAnalisis.Controls.Add(this.dgAtencionesAOA);
            this.gbAbrirOrdenAnalisis.Location = new System.Drawing.Point(6, 43);
            this.gbAbrirOrdenAnalisis.Name = "gbAbrirOrdenAnalisis";
            this.gbAbrirOrdenAnalisis.Size = new System.Drawing.Size(768, 462);
            this.gbAbrirOrdenAnalisis.TabIndex = 10;
            this.gbAbrirOrdenAnalisis.TabStop = false;
            this.gbAbrirOrdenAnalisis.Text = "Abrir orden de análisis";
            this.gbAbrirOrdenAnalisis.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(663, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "*De las atenciones que se muestran a continuación se puede abrir una orden de aná" +
    "lisis para que el resultado de la atención sea análisado";
            // 
            // btnAbrirOrden
            // 
            this.btnAbrirOrden.Location = new System.Drawing.Point(296, 425);
            this.btnAbrirOrden.Name = "btnAbrirOrden";
            this.btnAbrirOrden.Size = new System.Drawing.Size(190, 23);
            this.btnAbrirOrden.TabIndex = 1;
            this.btnAbrirOrden.Text = "Abrir orden de análisis";
            this.btnAbrirOrden.UseVisualStyleBackColor = true;
            this.btnAbrirOrden.Click += new System.EventHandler(this.btnAbrirOrden_Click);
            // 
            // dgAtencionesAOA
            // 
            this.dgAtencionesAOA.AllowUserToAddRows = false;
            this.dgAtencionesAOA.AllowUserToDeleteRows = false;
            this.dgAtencionesAOA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAtencionesAOA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombrePaciente,
            this.FechaExamen,
            this.Comentario});
            this.dgAtencionesAOA.Location = new System.Drawing.Point(8, 57);
            this.dgAtencionesAOA.Name = "dgAtencionesAOA";
            this.dgAtencionesAOA.ReadOnly = true;
            this.dgAtencionesAOA.Size = new System.Drawing.Size(754, 354);
            this.dgAtencionesAOA.TabIndex = 0;
            this.dgAtencionesAOA.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAtencionesAOA_CellClick);
            // 
            // NombrePaciente
            // 
            this.NombrePaciente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NombrePaciente.HeaderText = "Nombre paciente";
            this.NombrePaciente.Name = "NombrePaciente";
            this.NombrePaciente.ReadOnly = true;
            this.NombrePaciente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NombrePaciente.Width = 85;
            // 
            // FechaExamen
            // 
            this.FechaExamen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaExamen.HeaderText = "Fecha examen";
            this.FechaExamen.Name = "FechaExamen";
            this.FechaExamen.ReadOnly = true;
            this.FechaExamen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FechaExamen.Width = 75;
            // 
            // Comentario
            // 
            this.Comentario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Comentario.HeaderText = "Comentario";
            this.Comentario.Name = "Comentario";
            this.Comentario.ReadOnly = true;
            this.Comentario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Comentario.Width = 66;
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
            // gbCerrarOrdenAnalisis
            // 
            this.gbCerrarOrdenAnalisis.Controls.Add(this.label2);
            this.gbCerrarOrdenAnalisis.Controls.Add(this.btCerrarOrdenAnalisis);
            this.gbCerrarOrdenAnalisis.Controls.Add(this.dgCerrarOrdenAnalisis);
            this.gbCerrarOrdenAnalisis.Location = new System.Drawing.Point(6, 43);
            this.gbCerrarOrdenAnalisis.Name = "gbCerrarOrdenAnalisis";
            this.gbCerrarOrdenAnalisis.Size = new System.Drawing.Size(768, 462);
            this.gbCerrarOrdenAnalisis.TabIndex = 11;
            this.gbCerrarOrdenAnalisis.TabStop = false;
            this.gbCerrarOrdenAnalisis.Text = "Cerrar orden de análisis";
            this.gbCerrarOrdenAnalisis.Visible = false;
            // 
            // btCerrarOrdenAnalisis
            // 
            this.btCerrarOrdenAnalisis.Location = new System.Drawing.Point(296, 425);
            this.btCerrarOrdenAnalisis.Name = "btCerrarOrdenAnalisis";
            this.btCerrarOrdenAnalisis.Size = new System.Drawing.Size(190, 23);
            this.btCerrarOrdenAnalisis.TabIndex = 1;
            this.btCerrarOrdenAnalisis.Text = "Cerrar orden de análisis";
            this.btCerrarOrdenAnalisis.UseVisualStyleBackColor = true;
            this.btCerrarOrdenAnalisis.Click += new System.EventHandler(this.btCerrarOrdenAnalisis_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(394, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "*De las ordenes de análisis que se muestran a continuación elija cual quiere cerr" +
    "ar";
            // 
            // dgCerrarOrdenAnalisis
            // 
            this.dgCerrarOrdenAnalisis.AllowUserToAddRows = false;
            this.dgCerrarOrdenAnalisis.AllowUserToDeleteRows = false;
            this.dgCerrarOrdenAnalisis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCerrarOrdenAnalisis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.FechaAperturaOrden,
            this.dataGridViewTextBoxColumn3});
            this.dgCerrarOrdenAnalisis.Location = new System.Drawing.Point(8, 57);
            this.dgCerrarOrdenAnalisis.Name = "dgCerrarOrdenAnalisis";
            this.dgCerrarOrdenAnalisis.ReadOnly = true;
            this.dgCerrarOrdenAnalisis.Size = new System.Drawing.Size(754, 354);
            this.dgCerrarOrdenAnalisis.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Nombre paciente";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 85;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Fecha examen";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // FechaAperturaOrden
            // 
            this.FechaAperturaOrden.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaAperturaOrden.HeaderText = "Fecha apertura orden análisis";
            this.FechaAperturaOrden.Name = "FechaAperturaOrden";
            this.FechaAperturaOrden.ReadOnly = true;
            this.FechaAperturaOrden.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FechaAperturaOrden.Width = 106;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "Comentario";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 66;
            // 
            // FemEnfermero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FemEnfermero";
            this.Text = "Enfermero";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FemEnfermero_FormClosed);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbAbrirOrdenAnalisis.ResumeLayout(false);
            this.gbAbrirOrdenAnalisis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAtencionesAOA)).EndInit();
            this.gbOpcionesUsuario.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbCerrarOrdenAnalisis.ResumeLayout(false);
            this.gbCerrarOrdenAnalisis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCerrarOrdenAnalisis)).EndInit();
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
        private System.Windows.Forms.GroupBox gbAbrirOrdenAnalisis;
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
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarOrdenToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAbrirOrden;
        private System.Windows.Forms.DataGridView dgAtencionesAOA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombrePaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaExamen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentario;
        private System.Windows.Forms.GroupBox gbCerrarOrdenAnalisis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btCerrarOrdenAnalisis;
        private System.Windows.Forms.DataGridView dgCerrarOrdenAnalisis;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaAperturaOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}