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
            this.lblUsuarioConectado = new System.Windows.Forms.Label();
            this.lblPrivilegio = new System.Windows.Forms.Label();
            this.btnSesion = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblAseguradora = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblRutInfo = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDv = new System.Windows.Forms.TextBox();
            this.txtRut = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lstAtenciones = new System.Windows.Forms.ListBox();
            this.brnBuscarAtenciones = new System.Windows.Forms.Button();
            this.lblRut = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.agendarHoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agendarHoraToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.anularHoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearPacienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarPacienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarCjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnModificarUser = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gbOpcionesUsuario.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
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
            // lblPrivilegio
            // 
            this.lblPrivilegio.AutoSize = true;
            this.lblPrivilegio.Location = new System.Drawing.Point(3, 11);
            this.lblPrivilegio.Name = "lblPrivilegio";
            this.lblPrivilegio.Size = new System.Drawing.Size(52, 13);
            this.lblPrivilegio.TabIndex = 1;
            this.lblPrivilegio.Text = "Privilegio:";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.menuStrip1);
            this.groupBox1.Controls.Add(this.gbOpcionesUsuario);
            this.groupBox1.Location = new System.Drawing.Point(1, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 505);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.txtDv);
            this.groupBox6.Controls.Add(this.txtRut);
            this.groupBox6.Controls.Add(this.lblError);
            this.groupBox6.Controls.Add(this.btnIngresar);
            this.groupBox6.Controls.Add(this.lstAtenciones);
            this.groupBox6.Controls.Add(this.brnBuscarAtenciones);
            this.groupBox6.Controls.Add(this.lblRut);
            this.groupBox6.Location = new System.Drawing.Point(3, 43);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(777, 456);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Ingresar paciente";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblAseguradora);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.lblTotal);
            this.groupBox7.Controls.Add(this.lblDescuento);
            this.groupBox7.Controls.Add(this.lblSubtotal);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Location = new System.Drawing.Point(379, 231);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(233, 176);
            this.groupBox7.TabIndex = 21;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Pago";
            // 
            // lblAseguradora
            // 
            this.lblAseguradora.AutoSize = true;
            this.lblAseguradora.Location = new System.Drawing.Point(131, 136);
            this.lblAseguradora.Name = "lblAseguradora";
            this.lblAseguradora.Size = new System.Drawing.Size(77, 13);
            this.lblAseguradora.TabIndex = 28;
            this.lblAseguradora.Text = "lblAseguradora";
            this.lblAseguradora.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Aseguradora:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(131, 102);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(41, 13);
            this.lblTotal.TabIndex = 26;
            this.lblTotal.Text = "lblTotal";
            this.lblTotal.Visible = false;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new System.Drawing.Point(131, 70);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(69, 13);
            this.lblDescuento.TabIndex = 25;
            this.lblDescuento.Text = "lblDescuento";
            this.lblDescuento.Visible = false;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(131, 37);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(56, 13);
            this.lblSubtotal.TabIndex = 10;
            this.lblSubtotal.Text = "lblSubtotal";
            this.lblSubtotal.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Total: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Desc. por bono:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Subtotal: ";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lblRutInfo);
            this.groupBox8.Controls.Add(this.lblSexo);
            this.groupBox8.Controls.Add(this.lblEdad);
            this.groupBox8.Controls.Add(this.lblNombre);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Location = new System.Drawing.Point(116, 231);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(248, 176);
            this.groupBox8.TabIndex = 20;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Información paciente";
            // 
            // lblRutInfo
            // 
            this.lblRutInfo.AutoSize = true;
            this.lblRutInfo.Location = new System.Drawing.Point(127, 136);
            this.lblRutInfo.Name = "lblRutInfo";
            this.lblRutInfo.Size = new System.Drawing.Size(52, 13);
            this.lblRutInfo.TabIndex = 8;
            this.lblRutInfo.Text = "lblRutInfo";
            this.lblRutInfo.Visible = false;
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(127, 102);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(41, 13);
            this.lblSexo.TabIndex = 7;
            this.lblSexo.Text = "lblSexo";
            this.lblSexo.Visible = false;
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(127, 70);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(42, 13);
            this.lblEdad.TabIndex = 6;
            this.lblEdad.Text = "lblEdad";
            this.lblEdad.Visible = false;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(127, 37);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(54, 13);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "lblNombre";
            this.lblNombre.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "RUT: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Sexo:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Fecha de nacimiento:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Nombre:";
            // 
            // txtDv
            // 
            this.txtDv.Location = new System.Drawing.Point(349, 22);
            this.txtDv.MaxLength = 1;
            this.txtDv.Name = "txtDv";
            this.txtDv.Size = new System.Drawing.Size(15, 20);
            this.txtDv.TabIndex = 19;
            this.txtDv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDv_KeyPress);
            // 
            // txtRut
            // 
            this.txtRut.Location = new System.Drawing.Point(243, 22);
            this.txtRut.MaxLength = 8;
            this.txtRut.Name = "txtRut";
            this.txtRut.Size = new System.Drawing.Size(99, 20);
            this.txtRut.TabIndex = 18;
            this.txtRut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRut_KeyPress);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(259, 56);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(39, 13);
            this.lblError.TabIndex = 17;
            this.lblError.Text = "lblError";
            this.lblError.Visible = false;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(314, 413);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(131, 34);
            this.btnIngresar.TabIndex = 16;
            this.btnIngresar.Text = "Ingresar paciente";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lstAtenciones
            // 
            this.lstAtenciones.FormattingEnabled = true;
            this.lstAtenciones.Location = new System.Drawing.Point(116, 82);
            this.lstAtenciones.Name = "lstAtenciones";
            this.lstAtenciones.Size = new System.Drawing.Size(496, 134);
            this.lstAtenciones.TabIndex = 15;
            this.lstAtenciones.SelectedIndexChanged += new System.EventHandler(this.lstAtenciones_SelectedIndexChanged);
            // 
            // brnBuscarAtenciones
            // 
            this.brnBuscarAtenciones.Location = new System.Drawing.Point(401, 19);
            this.brnBuscarAtenciones.Name = "brnBuscarAtenciones";
            this.brnBuscarAtenciones.Size = new System.Drawing.Size(167, 23);
            this.brnBuscarAtenciones.TabIndex = 14;
            this.brnBuscarAtenciones.Text = "Buscar atenciones agendadas";
            this.brnBuscarAtenciones.UseVisualStyleBackColor = true;
            this.brnBuscarAtenciones.Click += new System.EventHandler(this.brnBuscarAtenciones_Click);
            // 
            // lblRut
            // 
            this.lblRut.AutoSize = true;
            this.lblRut.Location = new System.Drawing.Point(136, 29);
            this.lblRut.Name = "lblRut";
            this.lblRut.Size = new System.Drawing.Size(75, 13);
            this.lblRut.TabIndex = 11;
            this.lblRut.Text = "RUT Paciente";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agendarHoraToolStripMenuItem,
            this.crearPacienteToolStripMenuItem,
            this.ingresarPacienteToolStripMenuItem,
            this.cajaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 16);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(774, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // agendarHoraToolStripMenuItem
            // 
            this.agendarHoraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agendarHoraToolStripMenuItem1,
            this.anularHoraToolStripMenuItem});
            this.agendarHoraToolStripMenuItem.Name = "agendarHoraToolStripMenuItem";
            this.agendarHoraToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.agendarHoraToolStripMenuItem.Text = "Agendamiento";
            // 
            // agendarHoraToolStripMenuItem1
            // 
            this.agendarHoraToolStripMenuItem1.Name = "agendarHoraToolStripMenuItem1";
            this.agendarHoraToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.agendarHoraToolStripMenuItem1.Text = "Agendar hora";
            this.agendarHoraToolStripMenuItem1.Click += new System.EventHandler(this.agendarHoraToolStripMenuItem1_Click);
            // 
            // anularHoraToolStripMenuItem
            // 
            this.anularHoraToolStripMenuItem.Name = "anularHoraToolStripMenuItem";
            this.anularHoraToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.anularHoraToolStripMenuItem.Text = "Anular hora";
            this.anularHoraToolStripMenuItem.Click += new System.EventHandler(this.anularHoraToolStripMenuItem_Click);
            // 
            // crearPacienteToolStripMenuItem
            // 
            this.crearPacienteToolStripMenuItem.Name = "crearPacienteToolStripMenuItem";
            this.crearPacienteToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.crearPacienteToolStripMenuItem.Text = "Crear paciente";
            this.crearPacienteToolStripMenuItem.Click += new System.EventHandler(this.crearPacienteToolStripMenuItem_Click);
            // 
            // ingresarPacienteToolStripMenuItem
            // 
            this.ingresarPacienteToolStripMenuItem.Name = "ingresarPacienteToolStripMenuItem";
            this.ingresarPacienteToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.ingresarPacienteToolStripMenuItem.Text = "Ingresar paciente";
            this.ingresarPacienteToolStripMenuItem.Click += new System.EventHandler(this.ingresarPacienteToolStripMenuItem_Click);
            // 
            // cajaToolStripMenuItem
            // 
            this.cajaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirCajaToolStripMenuItem,
            this.cerrarCjaToolStripMenuItem});
            this.cajaToolStripMenuItem.Name = "cajaToolStripMenuItem";
            this.cajaToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.cajaToolStripMenuItem.Text = "Caja";
            // 
            // abrirCajaToolStripMenuItem
            // 
            this.abrirCajaToolStripMenuItem.Name = "abrirCajaToolStripMenuItem";
            this.abrirCajaToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.abrirCajaToolStripMenuItem.Text = "Abrir caja";
            this.abrirCajaToolStripMenuItem.Click += new System.EventHandler(this.abrirCajaToolStripMenuItem_Click);
            // 
            // cerrarCjaToolStripMenuItem
            // 
            this.cerrarCjaToolStripMenuItem.Name = "cerrarCjaToolStripMenuItem";
            this.cerrarCjaToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.cerrarCjaToolStripMenuItem.Text = "Cerrar caja";
            this.cerrarCjaToolStripMenuItem.Click += new System.EventHandler(this.cerrarCjaToolStripMenuItem_Click);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPrivilegio);
            this.groupBox2.Location = new System.Drawing.Point(1, 532);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(780, 27);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnModificarUser);
            this.groupBox3.Controls.Add(this.lblUsuarioConectado);
            this.groupBox3.Controls.Add(this.btnSesion);
            this.groupBox3.Location = new System.Drawing.Point(1, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(780, 41);
            this.groupBox3.TabIndex = 5;
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
            // FrmIngresarPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmIngresarPaciente";
            this.Text = "Inicio";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmIngresarPaciente_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbOpcionesUsuario.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUsuarioConectado;
        private System.Windows.Forms.Label lblPrivilegio;
        private System.Windows.Forms.Button btnSesion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnModificarUser;
        private System.Windows.Forms.GroupBox gbOpcionesUsuario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbNuevoMail;
        private System.Windows.Forms.Button btnCambiarEmail;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbContrasenaActual;
        private System.Windows.Forms.Button btnCambiarContrasena;
        private System.Windows.Forms.TextBox tbContrasenaNueva;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem agendarHoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirCajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarCjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearPacienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agendarHoraToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem anularHoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresarPacienteToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lblAseguradora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label lblRutInfo;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDv;
        private System.Windows.Forms.TextBox txtRut;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.ListBox lstAtenciones;
        private System.Windows.Forms.Button brnBuscarAtenciones;
        private System.Windows.Forms.Label lblRut;
    }
}