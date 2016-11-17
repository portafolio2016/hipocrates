namespace CheekiBreeki.CMH.Terminal.Views
{
    partial class FrmCerrarCaja
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
            this.lblError = new System.Windows.Forms.Label();
            this.btnAbrirCaja = new System.Windows.Forms.Button();
            this.txtDinero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCheques = new System.Windows.Forms.TextBox();
            this.lblCheques = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(303, 158);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(39, 13);
            this.lblError.TabIndex = 17;
            this.lblError.Text = "lblError";
            this.lblError.Visible = false;
            // 
            // btnAbrirCaja
            // 
            this.btnAbrirCaja.Location = new System.Drawing.Point(306, 190);
            this.btnAbrirCaja.Name = "btnAbrirCaja";
            this.btnAbrirCaja.Size = new System.Drawing.Size(129, 23);
            this.btnAbrirCaja.TabIndex = 2;
            this.btnAbrirCaja.Text = "Cerrar caja";
            this.btnAbrirCaja.UseVisualStyleBackColor = true;
            this.btnAbrirCaja.Click += new System.EventHandler(this.btnCerrarCaja_Click);
            // 
            // txtDinero
            // 
            this.txtDinero.Location = new System.Drawing.Point(380, 74);
            this.txtDinero.Name = "txtDinero";
            this.txtDinero.Size = new System.Drawing.Size(129, 20);
            this.txtDinero.TabIndex = 1;
            this.txtDinero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDinero_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dinero de cierre";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCheques);
            this.groupBox1.Controls.Add(this.lblCheques);
            this.groupBox1.Controls.Add(this.lblError);
            this.groupBox1.Controls.Add(this.btnAbrirCaja);
            this.groupBox1.Controls.Add(this.txtDinero);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 524);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cerrar caja";
            // 
            // txtCheques
            // 
            this.txtCheques.Location = new System.Drawing.Point(380, 113);
            this.txtCheques.Name = "txtCheques";
            this.txtCheques.Size = new System.Drawing.Size(129, 20);
            this.txtCheques.TabIndex = 19;
            this.txtCheques.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDinero_KeyPress);
            // 
            // lblCheques
            // 
            this.lblCheques.AutoSize = true;
            this.lblCheques.Location = new System.Drawing.Point(220, 120);
            this.lblCheques.Name = "lblCheques";
            this.lblCheques.Size = new System.Drawing.Size(108, 13);
            this.lblCheques.TabIndex = 18;
            this.lblCheques.Text = "Cantidad de cheques";
            // 
            // FrmCerrarCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCerrarCaja";
            this.Text = "FrmCerrarCaja";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCerrarCaja_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnAbrirCaja;
        private System.Windows.Forms.TextBox txtDinero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCheques;
        private System.Windows.Forms.Label lblCheques;
    }
}