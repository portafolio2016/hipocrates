namespace CheekiBreeki.CMH.Terminal.Views
{
    partial class FrmOrdenAnalisis
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.agendaDiariaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fichasMédicasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasMédicasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atencionesMédicasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agendarAtenciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anularAtenciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtRut = new System.Windows.Forms.TextBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblError = new System.Windows.Forms.Label();
            this.txtDv = new System.Windows.Forms.TextBox();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.btnAgendar = new System.Windows.Forms.Button();
            this.cmbHora = new System.Windows.Forms.ComboBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.cmbPrestacion = new System.Windows.Forms.ComboBox();
            this.lblPrestación = new System.Windows.Forms.Label();
            this.cmbPersonal = new System.Windows.Forms.ComboBox();
            this.lblPersonal = new System.Windows.Forms.Label();
            this.lblObservación = new System.Windows.Forms.Label();
            this.rtObservacion = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agendaDiariaToolStripMenuItem,
            this.fichasMédicasToolStripMenuItem,
            this.consultasMédicasToolStripMenuItem,
            this.atencionesMédicasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // agendaDiariaToolStripMenuItem
            // 
            this.agendaDiariaToolStripMenuItem.Name = "agendaDiariaToolStripMenuItem";
            this.agendaDiariaToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.agendaDiariaToolStripMenuItem.Text = "Agenda diaria";
            // 
            // fichasMédicasToolStripMenuItem
            // 
            this.fichasMédicasToolStripMenuItem.Name = "fichasMédicasToolStripMenuItem";
            this.fichasMédicasToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.fichasMédicasToolStripMenuItem.Text = "Fichas médicas";
            // 
            // consultasMédicasToolStripMenuItem
            // 
            this.consultasMédicasToolStripMenuItem.Name = "consultasMédicasToolStripMenuItem";
            this.consultasMédicasToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.consultasMédicasToolStripMenuItem.Text = "Consultas médicas";
            // 
            // atencionesMédicasToolStripMenuItem
            // 
            this.atencionesMédicasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agendarAtenciónToolStripMenuItem,
            this.anularAtenciónToolStripMenuItem});
            this.atencionesMédicasToolStripMenuItem.Name = "atencionesMédicasToolStripMenuItem";
            this.atencionesMédicasToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.atencionesMédicasToolStripMenuItem.Text = "Atenciones";
            // 
            // agendarAtenciónToolStripMenuItem
            // 
            this.agendarAtenciónToolStripMenuItem.Name = "agendarAtenciónToolStripMenuItem";
            this.agendarAtenciónToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.agendarAtenciónToolStripMenuItem.Text = "Agendar atención";
            // 
            // anularAtenciónToolStripMenuItem
            // 
            this.anularAtenciónToolStripMenuItem.Name = "anularAtenciónToolStripMenuItem";
            this.anularAtenciónToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.anularAtenciónToolStripMenuItem.Text = "Anular atención";
            // 
            // txtRut
            // 
            this.txtRut.Location = new System.Drawing.Point(160, 32);
            this.txtRut.MaxLength = 8;
            this.txtRut.Name = "txtRut";
            this.txtRut.Size = new System.Drawing.Size(99, 20);
            this.txtRut.TabIndex = 1;
            this.txtRut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRut_KeyPress);
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Location = new System.Drawing.Point(25, 35);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(75, 13);
            this.lblPaciente.TabIndex = 2;
            this.lblPaciente.Text = "RUT Paciente";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(25, 66);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(67, 13);
            this.lblEspecialidad.TabIndex = 3;
            this.lblEspecialidad.Text = "Especialidad";
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Location = new System.Drawing.Point(160, 63);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(121, 21);
            this.cmbEspecialidad.TabIndex = 4;
            this.cmbEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cmbEspecialidad_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtObservacion);
            this.groupBox1.Controls.Add(this.lblObservación);
            this.groupBox1.Controls.Add(this.lblError);
            this.groupBox1.Controls.Add(this.txtDv);
            this.groupBox1.Controls.Add(this.dtFecha);
            this.groupBox1.Controls.Add(this.btnAgendar);
            this.groupBox1.Controls.Add(this.cmbHora);
            this.groupBox1.Controls.Add(this.lblHora);
            this.groupBox1.Controls.Add(this.lblFecha);
            this.groupBox1.Controls.Add(this.cmbPrestacion);
            this.groupBox1.Controls.Add(this.lblPrestación);
            this.groupBox1.Controls.Add(this.cmbPersonal);
            this.groupBox1.Controls.Add(this.lblPersonal);
            this.groupBox1.Controls.Add(this.txtRut);
            this.groupBox1.Controls.Add(this.cmbEspecialidad);
            this.groupBox1.Controls.Add(this.lblPaciente);
            this.groupBox1.Controls.Add(this.lblEspecialidad);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 508);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Orden de analisis";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(169, 390);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(39, 13);
            this.lblError.TabIndex = 16;
            this.lblError.Text = "lblError";
            this.lblError.Visible = false;
            // 
            // txtDv
            // 
            this.txtDv.Location = new System.Drawing.Point(266, 32);
            this.txtDv.MaxLength = 1;
            this.txtDv.Name = "txtDv";
            this.txtDv.Size = new System.Drawing.Size(15, 20);
            this.txtDv.TabIndex = 15;
            this.txtDv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDv_KeyPress);
            // 
            // dtFecha
            // 
            this.dtFecha.Location = new System.Drawing.Point(160, 163);
            this.dtFecha.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
            this.dtFecha.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(121, 20);
            this.dtFecha.TabIndex = 14;
            this.dtFecha.ValueChanged += new System.EventHandler(this.dtFecha_ValueChanged);
            // 
            // btnAgendar
            // 
            this.btnAgendar.Location = new System.Drawing.Point(277, 419);
            this.btnAgendar.Name = "btnAgendar";
            this.btnAgendar.Size = new System.Drawing.Size(123, 23);
            this.btnAgendar.TabIndex = 13;
            this.btnAgendar.Text = "Agendar";
            this.btnAgendar.UseVisualStyleBackColor = true;
            this.btnAgendar.Click += new System.EventHandler(this.btnAgendar_Click);
            // 
            // cmbHora
            // 
            this.cmbHora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHora.FormattingEnabled = true;
            this.cmbHora.Location = new System.Drawing.Point(160, 196);
            this.cmbHora.Name = "cmbHora";
            this.cmbHora.Size = new System.Drawing.Size(121, 21);
            this.cmbHora.TabIndex = 12;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(25, 204);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(30, 13);
            this.lblHora.TabIndex = 11;
            this.lblHora.Text = "Hora";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(25, 169);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 9;
            this.lblFecha.Text = "Fecha";
            // 
            // cmbPrestacion
            // 
            this.cmbPrestacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrestacion.FormattingEnabled = true;
            this.cmbPrestacion.Location = new System.Drawing.Point(160, 128);
            this.cmbPrestacion.Name = "cmbPrestacion";
            this.cmbPrestacion.Size = new System.Drawing.Size(121, 21);
            this.cmbPrestacion.TabIndex = 8;
            // 
            // lblPrestación
            // 
            this.lblPrestación.AutoSize = true;
            this.lblPrestación.Location = new System.Drawing.Point(25, 131);
            this.lblPrestación.Name = "lblPrestación";
            this.lblPrestación.Size = new System.Drawing.Size(57, 13);
            this.lblPrestación.TabIndex = 7;
            this.lblPrestación.Text = "Prestación";
            // 
            // cmbPersonal
            // 
            this.cmbPersonal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonal.FormattingEnabled = true;
            this.cmbPersonal.Location = new System.Drawing.Point(160, 96);
            this.cmbPersonal.Name = "cmbPersonal";
            this.cmbPersonal.Size = new System.Drawing.Size(121, 21);
            this.cmbPersonal.TabIndex = 6;
            this.cmbPersonal.SelectedIndexChanged += new System.EventHandler(this.cmbPersonal_SelectedIndexChanged);
            // 
            // lblPersonal
            // 
            this.lblPersonal.AutoSize = true;
            this.lblPersonal.Location = new System.Drawing.Point(25, 99);
            this.lblPersonal.Name = "lblPersonal";
            this.lblPersonal.Size = new System.Drawing.Size(85, 13);
            this.lblPersonal.TabIndex = 5;
            this.lblPersonal.Text = "Personal médico";
            // 
            // lblObservación
            // 
            this.lblObservación.AutoSize = true;
            this.lblObservación.Location = new System.Drawing.Point(27, 258);
            this.lblObservación.Name = "lblObservación";
            this.lblObservación.Size = new System.Drawing.Size(67, 13);
            this.lblObservación.TabIndex = 17;
            this.lblObservación.Text = "Observación";
            // 
            // rtObservacion
            // 
            this.rtObservacion.Location = new System.Drawing.Point(160, 241);
            this.rtObservacion.MaxLength = 256;
            this.rtObservacion.Name = "rtObservacion";
            this.rtObservacion.Size = new System.Drawing.Size(460, 122);
            this.rtObservacion.TabIndex = 18;
            this.rtObservacion.Text = "";
            // 
            // FrmOrdenAnalisis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmOrdenAnalisis";
            this.Text = "Centro Médico Hipócrates";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAgendarAtencion_FormClosed);
            this.Load += new System.EventHandler(this.frmAgendarAtencion_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem agendaDiariaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fichasMédicasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasMédicasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atencionesMédicasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agendarAtenciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anularAtenciónToolStripMenuItem;
        private System.Windows.Forms.TextBox txtRut;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAgendar;
        private System.Windows.Forms.ComboBox cmbHora;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ComboBox cmbPrestacion;
        private System.Windows.Forms.Label lblPrestación;
        private System.Windows.Forms.ComboBox cmbPersonal;
        private System.Windows.Forms.Label lblPersonal;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.TextBox txtDv;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.RichTextBox rtObservacion;
        private System.Windows.Forms.Label lblObservación;
    }
}

