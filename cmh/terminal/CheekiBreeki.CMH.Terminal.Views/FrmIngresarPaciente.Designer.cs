namespace CheekiBreeki.CMH.Terminal.Views
{
    partial class FrmIngresarPaciente
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRut = new System.Windows.Forms.Label();
            this.brnBuscarAtenciones = new System.Windows.Forms.Button();
            this.lstAtenciones = new System.Windows.Forms.ListBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.txtDv = new System.Windows.Forms.TextBox();
            this.txtRut = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDv);
            this.groupBox1.Controls.Add(this.txtRut);
            this.groupBox1.Controls.Add(this.lblError);
            this.groupBox1.Controls.Add(this.btnIngresar);
            this.groupBox1.Controls.Add(this.lstAtenciones);
            this.groupBox1.Controls.Add(this.brnBuscarAtenciones);
            this.groupBox1.Controls.Add(this.lblRut);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 521);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingresar paciente";
            // 
            // lblRut
            // 
            this.lblRut.AutoSize = true;
            this.lblRut.Location = new System.Drawing.Point(137, 57);
            this.lblRut.Name = "lblRut";
            this.lblRut.Size = new System.Drawing.Size(75, 13);
            this.lblRut.TabIndex = 11;
            this.lblRut.Text = "RUT Paciente";
            // 
            // brnBuscarAtenciones
            // 
            this.brnBuscarAtenciones.Location = new System.Drawing.Point(402, 47);
            this.brnBuscarAtenciones.Name = "brnBuscarAtenciones";
            this.brnBuscarAtenciones.Size = new System.Drawing.Size(167, 23);
            this.brnBuscarAtenciones.TabIndex = 14;
            this.brnBuscarAtenciones.Text = "Buscar atenciones agendadas";
            this.brnBuscarAtenciones.UseVisualStyleBackColor = true;
            this.brnBuscarAtenciones.Click += new System.EventHandler(this.brnBuscarAtenciones_Click);
            // 
            // lstAtenciones
            // 
            this.lstAtenciones.FormattingEnabled = true;
            this.lstAtenciones.Location = new System.Drawing.Point(117, 110);
            this.lstAtenciones.Name = "lstAtenciones";
            this.lstAtenciones.Size = new System.Drawing.Size(496, 225);
            this.lstAtenciones.TabIndex = 15;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(298, 371);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(131, 23);
            this.btnIngresar.TabIndex = 16;
            this.btnIngresar.Text = "Ingresar paciente";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(260, 84);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(39, 13);
            this.lblError.TabIndex = 17;
            this.lblError.Text = "lblError";
            this.lblError.Visible = false;
            // 
            // txtDv
            // 
            this.txtDv.Location = new System.Drawing.Point(350, 50);
            this.txtDv.MaxLength = 1;
            this.txtDv.Name = "txtDv";
            this.txtDv.Size = new System.Drawing.Size(15, 20);
            this.txtDv.TabIndex = 19;
            this.txtDv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDv_KeyPress);
            // 
            // txtRut
            // 
            this.txtRut.Location = new System.Drawing.Point(244, 50);
            this.txtRut.MaxLength = 8;
            this.txtRut.Name = "txtRut";
            this.txtRut.Size = new System.Drawing.Size(99, 20);
            this.txtRut.TabIndex = 18;
            this.txtRut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRut_KeyPress);
            // 
            // FrmIngresarPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmIngresarPaciente";
            this.Text = "Ingresar paciente";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmIngresarPaciente_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button brnBuscarAtenciones;
        private System.Windows.Forms.Label lblRut;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.ListBox lstAtenciones;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtDv;
        private System.Windows.Forms.TextBox txtRut;
    }
}