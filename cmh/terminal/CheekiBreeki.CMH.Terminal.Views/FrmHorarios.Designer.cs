namespace CheekiBreeki.CMH.Terminal.Views
{
    partial class FrmHorarios
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.gpAsignados = new System.Windows.Forms.GroupBox();
            this.lstAsignados = new System.Windows.Forms.ListBox();
            this.gpDisponibles = new System.Windows.Forms.GroupBox();
            this.lstDisponibles = new System.Windows.Forms.ListBox();
            this.txtDv = new System.Windows.Forms.TextBox();
            this.txtRut = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.brnBuscarHorarios = new System.Windows.Forms.Button();
            this.lblRut = new System.Windows.Forms.Label();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.groupBox6.SuspendLayout();
            this.gpAsignados.SuspendLayout();
            this.gpDisponibles.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnGuardarCambios);
            this.groupBox6.Controls.Add(this.btnQuitar);
            this.groupBox6.Controls.Add(this.btnAsignar);
            this.groupBox6.Controls.Add(this.gpAsignados);
            this.groupBox6.Controls.Add(this.gpDisponibles);
            this.groupBox6.Controls.Add(this.txtDv);
            this.groupBox6.Controls.Add(this.txtRut);
            this.groupBox6.Controls.Add(this.lblError);
            this.groupBox6.Controls.Add(this.brnBuscarHorarios);
            this.groupBox6.Controls.Add(this.lblRut);
            this.groupBox6.Location = new System.Drawing.Point(7, 53);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(771, 454);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Anular atención";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(333, 245);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 23);
            this.btnQuitar.TabIndex = 23;
            this.btnQuitar.Text = "<<";
            this.btnQuitar.UseVisualStyleBackColor = true;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(333, 216);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(75, 23);
            this.btnAsignar.TabIndex = 22;
            this.btnAsignar.Text = ">>";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // gpAsignados
            // 
            this.gpAsignados.Controls.Add(this.lstAsignados);
            this.gpAsignados.Location = new System.Drawing.Point(441, 99);
            this.gpAsignados.Name = "gpAsignados";
            this.gpAsignados.Size = new System.Drawing.Size(228, 331);
            this.gpAsignados.TabIndex = 21;
            this.gpAsignados.TabStop = false;
            this.gpAsignados.Text = "Horarios Asignados";
            // 
            // lstAsignados
            // 
            this.lstAsignados.FormattingEnabled = true;
            this.lstAsignados.Location = new System.Drawing.Point(20, 19);
            this.lstAsignados.Name = "lstAsignados";
            this.lstAsignados.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstAsignados.Size = new System.Drawing.Size(190, 303);
            this.lstAsignados.TabIndex = 1;
            // 
            // gpDisponibles
            // 
            this.gpDisponibles.Controls.Add(this.lstDisponibles);
            this.gpDisponibles.Location = new System.Drawing.Point(70, 99);
            this.gpDisponibles.Name = "gpDisponibles";
            this.gpDisponibles.Size = new System.Drawing.Size(228, 331);
            this.gpDisponibles.TabIndex = 20;
            this.gpDisponibles.TabStop = false;
            this.gpDisponibles.Text = "Horarios disponibles";
            // 
            // lstDisponibles
            // 
            this.lstDisponibles.FormattingEnabled = true;
            this.lstDisponibles.Location = new System.Drawing.Point(20, 19);
            this.lstDisponibles.Name = "lstDisponibles";
            this.lstDisponibles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstDisponibles.Size = new System.Drawing.Size(190, 303);
            this.lstDisponibles.TabIndex = 0;
            this.lstDisponibles.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // txtDv
            // 
            this.txtDv.Location = new System.Drawing.Point(349, 24);
            this.txtDv.MaxLength = 1;
            this.txtDv.Name = "txtDv";
            this.txtDv.Size = new System.Drawing.Size(15, 20);
            this.txtDv.TabIndex = 19;
            this.txtDv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDv_KeyPress);
            // 
            // txtRut
            // 
            this.txtRut.Location = new System.Drawing.Point(243, 24);
            this.txtRut.MaxLength = 8;
            this.txtRut.Name = "txtRut";
            this.txtRut.Size = new System.Drawing.Size(99, 20);
            this.txtRut.TabIndex = 18;
            this.txtRut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRut_KeyPress);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(259, 58);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(39, 13);
            this.lblError.TabIndex = 17;
            this.lblError.Text = "lblError";
            this.lblError.Visible = false;
            // 
            // brnBuscarHorarios
            // 
            this.brnBuscarHorarios.Location = new System.Drawing.Point(401, 21);
            this.brnBuscarHorarios.Name = "brnBuscarHorarios";
            this.brnBuscarHorarios.Size = new System.Drawing.Size(167, 23);
            this.brnBuscarHorarios.TabIndex = 14;
            this.brnBuscarHorarios.Text = "Buscar horarios";
            this.brnBuscarHorarios.UseVisualStyleBackColor = true;
            this.brnBuscarHorarios.Click += new System.EventHandler(this.brnBuscarHorarios_Click);
            // 
            // lblRut
            // 
            this.lblRut.AutoSize = true;
            this.lblRut.Location = new System.Drawing.Point(136, 31);
            this.lblRut.Name = "lblRut";
            this.lblRut.Size = new System.Drawing.Size(74, 13);
            this.lblRut.TabIndex = 11;
            this.lblRut.Text = "RUT Personal";
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Location = new System.Drawing.Point(304, 407);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(131, 23);
            this.btnGuardarCambios.TabIndex = 24;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // FrmHorarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox6);
            this.Name = "FrmHorarios";
            this.Text = "FrmHorarios";
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.gpAsignados.ResumeLayout(false);
            this.gpDisponibles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtDv;
        private System.Windows.Forms.TextBox txtRut;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button brnBuscarHorarios;
        private System.Windows.Forms.Label lblRut;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.GroupBox gpAsignados;
        private System.Windows.Forms.GroupBox gpDisponibles;
        private System.Windows.Forms.ListBox lstDisponibles;
        private System.Windows.Forms.ListBox lstAsignados;
        private System.Windows.Forms.Button btnGuardarCambios;
    }
}