namespace CheekiBreeki.CMH.Terminal.Views
{
    partial class FrmAgendarAtencion
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
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbPersonal = new System.Windows.Forms.ComboBox();
            this.lblPersonal = new System.Windows.Forms.Label();
            this.cmbPrestacion = new System.Windows.Forms.ComboBox();
            this.lblPrestación = new System.Windows.Forms.Label();
            this.cmbFecha = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.cmbHora = new System.Windows.Forms.ComboBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.btnAgendar = new System.Windows.Forms.Button();
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
            this.atencionesMédicasToolStripMenuItem.Click += new System.EventHandler(this.atencionesMédicasToolStripMenuItem_Click);
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
            // txtPaciente
            // 
            this.txtPaciente.Location = new System.Drawing.Point(160, 32);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.Size = new System.Drawing.Size(121, 20);
            this.txtPaciente.TabIndex = 1;
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Location = new System.Drawing.Point(32, 39);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(75, 13);
            this.lblPaciente.TabIndex = 2;
            this.lblPaciente.Text = "RUT Paciente";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(32, 71);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(67, 13);
            this.lblEspecialidad.TabIndex = 3;
            this.lblEspecialidad.Text = "Especialidad";
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Location = new System.Drawing.Point(160, 63);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(121, 21);
            this.cmbEspecialidad.TabIndex = 4;
            this.cmbEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cmbEspecialidad_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAgendar);
            this.groupBox1.Controls.Add(this.cmbHora);
            this.groupBox1.Controls.Add(this.lblHora);
            this.groupBox1.Controls.Add(this.cmbFecha);
            this.groupBox1.Controls.Add(this.lblFecha);
            this.groupBox1.Controls.Add(this.cmbPrestacion);
            this.groupBox1.Controls.Add(this.lblPrestación);
            this.groupBox1.Controls.Add(this.cmbPersonal);
            this.groupBox1.Controls.Add(this.lblPersonal);
            this.groupBox1.Controls.Add(this.txtPaciente);
            this.groupBox1.Controls.Add(this.cmbEspecialidad);
            this.groupBox1.Controls.Add(this.lblPaciente);
            this.groupBox1.Controls.Add(this.lblEspecialidad);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 508);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agendar atención";
            // 
            // cmbPersonal
            // 
            this.cmbPersonal.FormattingEnabled = true;
            this.cmbPersonal.Location = new System.Drawing.Point(160, 96);
            this.cmbPersonal.Name = "cmbPersonal";
            this.cmbPersonal.Size = new System.Drawing.Size(121, 21);
            this.cmbPersonal.TabIndex = 6;
            // 
            // lblPersonal
            // 
            this.lblPersonal.AutoSize = true;
            this.lblPersonal.Location = new System.Drawing.Point(32, 104);
            this.lblPersonal.Name = "lblPersonal";
            this.lblPersonal.Size = new System.Drawing.Size(85, 13);
            this.lblPersonal.TabIndex = 5;
            this.lblPersonal.Text = "Personal médico";
            // 
            // cmbPrestacion
            // 
            this.cmbPrestacion.FormattingEnabled = true;
            this.cmbPrestacion.Location = new System.Drawing.Point(160, 130);
            this.cmbPrestacion.Name = "cmbPrestacion";
            this.cmbPrestacion.Size = new System.Drawing.Size(121, 21);
            this.cmbPrestacion.TabIndex = 8;
            // 
            // lblPrestación
            // 
            this.lblPrestación.AutoSize = true;
            this.lblPrestación.Location = new System.Drawing.Point(32, 138);
            this.lblPrestación.Name = "lblPrestación";
            this.lblPrestación.Size = new System.Drawing.Size(57, 13);
            this.lblPrestación.TabIndex = 7;
            this.lblPrestación.Text = "Prestación";
            // 
            // cmbFecha
            // 
            this.cmbFecha.FormattingEnabled = true;
            this.cmbFecha.Location = new System.Drawing.Point(160, 164);
            this.cmbFecha.Name = "cmbFecha";
            this.cmbFecha.Size = new System.Drawing.Size(121, 21);
            this.cmbFecha.TabIndex = 10;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(32, 172);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 9;
            this.lblFecha.Text = "Fecha";
            // 
            // cmbHora
            // 
            this.cmbHora.FormattingEnabled = true;
            this.cmbHora.Location = new System.Drawing.Point(160, 198);
            this.cmbHora.Name = "cmbHora";
            this.cmbHora.Size = new System.Drawing.Size(121, 21);
            this.cmbHora.TabIndex = 12;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(32, 206);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(67, 13);
            this.lblHora.TabIndex = 11;
            this.lblHora.Text = "Especialidad";
            // 
            // btnAgendar
            // 
            this.btnAgendar.Location = new System.Drawing.Point(79, 252);
            this.btnAgendar.Name = "btnAgendar";
            this.btnAgendar.Size = new System.Drawing.Size(123, 23);
            this.btnAgendar.TabIndex = 13;
            this.btnAgendar.Text = "Agendar";
            this.btnAgendar.UseVisualStyleBackColor = true;
            this.btnAgendar.Click += new System.EventHandler(this.btnAgendar_Click);
            // 
            // frmAgendarAtencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmAgendarAtencion";
            this.Text = "Centro Médico Hipócrates";
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
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAgendar;
        private System.Windows.Forms.ComboBox cmbHora;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.ComboBox cmbFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ComboBox cmbPrestacion;
        private System.Windows.Forms.Label lblPrestación;
        private System.Windows.Forms.ComboBox cmbPersonal;
        private System.Windows.Forms.Label lblPersonal;
    }
}

