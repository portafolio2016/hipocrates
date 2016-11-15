namespace CheekiBreeki.CMH.Terminal.Views
{
    partial class FrmLogin
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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDatosInvalidos = new System.Windows.Forms.Label();
            this.lblAdvertenciaContrasena = new System.Windows.Forms.Label();
            this.lblAdvertenciaUsuario = new System.Windows.Forms.Label();
            this.lblContrasenaOlvidada = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(127, 32);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(49, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario: ";
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenido.Location = new System.Drawing.Point(163, 140);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(432, 39);
            this.lblBienvenido.TabIndex = 1;
            this.lblBienvenido.Text = "Bienvenido a terminal CMH";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(235, 29);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(123, 20);
            this.txtUsuario.TabIndex = 2;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(234, 65);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(123, 20);
            this.txtContrasena.TabIndex = 4;
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location = new System.Drawing.Point(127, 68);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(64, 13);
            this.lblContrasena.TabIndex = 3;
            this.lblContrasena.Text = "Contraseña:";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(192, 123);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(102, 23);
            this.btnIniciar.TabIndex = 5;
            this.btnIniciar.Text = "Iniciar Sesión";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDatosInvalidos);
            this.groupBox1.Controls.Add(this.lblAdvertenciaContrasena);
            this.groupBox1.Controls.Add(this.lblAdvertenciaUsuario);
            this.groupBox1.Controls.Add(this.lblContrasenaOlvidada);
            this.groupBox1.Controls.Add(this.btnIniciar);
            this.groupBox1.Controls.Add(this.lblUsuario);
            this.groupBox1.Controls.Add(this.txtContrasena);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.lblContrasena);
            this.groupBox1.Location = new System.Drawing.Point(137, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 164);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inicio Sesión";
            // 
            // lblDatosInvalidos
            // 
            this.lblDatosInvalidos.AutoSize = true;
            this.lblDatosInvalidos.Location = new System.Drawing.Point(169, 13);
            this.lblDatosInvalidos.Name = "lblDatosInvalidos";
            this.lblDatosInvalidos.Size = new System.Drawing.Size(151, 13);
            this.lblDatosInvalidos.TabIndex = 9;
            this.lblDatosInvalidos.Text = "Usuario y contraseña invalidas";
            // 
            // lblAdvertenciaContrasena
            // 
            this.lblAdvertenciaContrasena.AutoSize = true;
            this.lblAdvertenciaContrasena.Location = new System.Drawing.Point(364, 68);
            this.lblAdvertenciaContrasena.Name = "lblAdvertenciaContrasena";
            this.lblAdvertenciaContrasena.Size = new System.Drawing.Size(121, 13);
            this.lblAdvertenciaContrasena.TabIndex = 8;
            this.lblAdvertenciaContrasena.Text = "Advertencia Contraseña";
            // 
            // lblAdvertenciaUsuario
            // 
            this.lblAdvertenciaUsuario.AutoSize = true;
            this.lblAdvertenciaUsuario.Location = new System.Drawing.Point(364, 32);
            this.lblAdvertenciaUsuario.Name = "lblAdvertenciaUsuario";
            this.lblAdvertenciaUsuario.Size = new System.Drawing.Size(103, 13);
            this.lblAdvertenciaUsuario.TabIndex = 7;
            this.lblAdvertenciaUsuario.Text = "Advertencia Usuario";
            // 
            // lblContrasenaOlvidada
            // 
            this.lblContrasenaOlvidada.AutoSize = true;
            this.lblContrasenaOlvidada.Location = new System.Drawing.Point(96, 97);
            this.lblContrasenaOlvidada.Name = "lblContrasenaOlvidada";
            this.lblContrasenaOlvidada.Size = new System.Drawing.Size(299, 13);
            this.lblContrasenaOlvidada.TabIndex = 6;
            this.lblContrasenaOlvidada.Text = "¿Olvidó la contraseña? Contáctese con el Jefe de operadores";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmLogin";
            this.Text = "Iniciar sesión";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblContrasenaOlvidada;
        private System.Windows.Forms.Label lblAdvertenciaUsuario;
        private System.Windows.Forms.Label lblAdvertenciaContrasena;
        private System.Windows.Forms.Label lblDatosInvalidos;
    }
}

