namespace CheekiBreeki.CMH.Terminal.Views
{
    partial class frmAgendarAtencion
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
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
            this.txtPaciente.Location = new System.Drawing.Point(172, 61);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.Size = new System.Drawing.Size(121, 20);
            this.txtPaciente.TabIndex = 1;
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Location = new System.Drawing.Point(44, 68);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(75, 13);
            this.lblPaciente.TabIndex = 2;
            this.lblPaciente.Text = "RUT Paciente";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(47, 100);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(67, 13);
            this.lblEspecialidad.TabIndex = 3;
            this.lblEspecialidad.Text = "Especialidad";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(172, 92);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // frmAgendarAtencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblEspecialidad);
            this.Controls.Add(this.lblPaciente);
            this.Controls.Add(this.txtPaciente);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmAgendarAtencion";
            this.Text = "Centro Médico Hipócrates";
            this.Load += new System.EventHandler(this.frmAgendarAtencion_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

