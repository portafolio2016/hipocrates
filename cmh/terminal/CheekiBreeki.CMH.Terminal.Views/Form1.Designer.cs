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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgendarAtencion));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.agendaDiariaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fichasMédicasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasMédicasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirConsultaMédicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarConsultaMédicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atenciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agendarAtenciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anularAtenciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAgendar = new System.Windows.Forms.Button();
            this.cmbHora = new System.Windows.Forms.ComboBox();
            this.cmbFecha = new System.Windows.Forms.ComboBox();
            this.cmbPrestacion = new System.Windows.Forms.ComboBox();
            this.cmbPersonal = new System.Windows.Forms.ComboBox();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblPrestacion = new System.Windows.Forms.Label();
            this.lblPersonal = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.eSPECIALIDADBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new CheekiBreeki.CMH.Terminal.Views.DataSet1();
            this.eSPECIALIDADBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.eSPECIALIDADTableAdapter = new CheekiBreeki.CMH.Terminal.Views.DataSet1TableAdapters.ESPECIALIDADTableAdapter();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eSPECIALIDADBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSPECIALIDADBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agendaDiariaToolStripMenuItem,
            this.fichasMédicasToolStripMenuItem,
            this.consultasMédicasToolStripMenuItem,
            this.atenciónToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // agendaDiariaToolStripMenuItem
            // 
            this.agendaDiariaToolStripMenuItem.Name = "agendaDiariaToolStripMenuItem";
            resources.ApplyResources(this.agendaDiariaToolStripMenuItem, "agendaDiariaToolStripMenuItem");
            // 
            // fichasMédicasToolStripMenuItem
            // 
            this.fichasMédicasToolStripMenuItem.Name = "fichasMédicasToolStripMenuItem";
            resources.ApplyResources(this.fichasMédicasToolStripMenuItem, "fichasMédicasToolStripMenuItem");
            // 
            // consultasMédicasToolStripMenuItem
            // 
            this.consultasMédicasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirConsultaMédicaToolStripMenuItem,
            this.cerrarConsultaMédicaToolStripMenuItem});
            this.consultasMédicasToolStripMenuItem.Name = "consultasMédicasToolStripMenuItem";
            resources.ApplyResources(this.consultasMédicasToolStripMenuItem, "consultasMédicasToolStripMenuItem");
            // 
            // abrirConsultaMédicaToolStripMenuItem
            // 
            this.abrirConsultaMédicaToolStripMenuItem.Name = "abrirConsultaMédicaToolStripMenuItem";
            resources.ApplyResources(this.abrirConsultaMédicaToolStripMenuItem, "abrirConsultaMédicaToolStripMenuItem");
            // 
            // cerrarConsultaMédicaToolStripMenuItem
            // 
            this.cerrarConsultaMédicaToolStripMenuItem.Name = "cerrarConsultaMédicaToolStripMenuItem";
            resources.ApplyResources(this.cerrarConsultaMédicaToolStripMenuItem, "cerrarConsultaMédicaToolStripMenuItem");
            // 
            // atenciónToolStripMenuItem
            // 
            this.atenciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agendarAtenciónToolStripMenuItem,
            this.anularAtenciónToolStripMenuItem});
            this.atenciónToolStripMenuItem.Name = "atenciónToolStripMenuItem";
            resources.ApplyResources(this.atenciónToolStripMenuItem, "atenciónToolStripMenuItem");
            this.atenciónToolStripMenuItem.Click += new System.EventHandler(this.atenciónToolStripMenuItem_Click);
            // 
            // agendarAtenciónToolStripMenuItem
            // 
            this.agendarAtenciónToolStripMenuItem.Name = "agendarAtenciónToolStripMenuItem";
            resources.ApplyResources(this.agendarAtenciónToolStripMenuItem, "agendarAtenciónToolStripMenuItem");
            // 
            // anularAtenciónToolStripMenuItem
            // 
            this.anularAtenciónToolStripMenuItem.Name = "anularAtenciónToolStripMenuItem";
            resources.ApplyResources(this.anularAtenciónToolStripMenuItem, "anularAtenciónToolStripMenuItem");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAgendar);
            this.groupBox1.Controls.Add(this.cmbHora);
            this.groupBox1.Controls.Add(this.cmbFecha);
            this.groupBox1.Controls.Add(this.cmbPrestacion);
            this.groupBox1.Controls.Add(this.cmbPersonal);
            this.groupBox1.Controls.Add(this.cmbEspecialidad);
            this.groupBox1.Controls.Add(this.lblHora);
            this.groupBox1.Controls.Add(this.lblFecha);
            this.groupBox1.Controls.Add(this.lblPrestacion);
            this.groupBox1.Controls.Add(this.lblPersonal);
            this.groupBox1.Controls.Add(this.lblEspecialidad);
            this.groupBox1.Controls.Add(this.lblPaciente);
            this.groupBox1.Controls.Add(this.txtPaciente);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnAgendar
            // 
            resources.ApplyResources(this.btnAgendar, "btnAgendar");
            this.btnAgendar.Name = "btnAgendar";
            this.btnAgendar.UseVisualStyleBackColor = true;
            // 
            // cmbHora
            // 
            this.cmbHora.FormattingEnabled = true;
            resources.ApplyResources(this.cmbHora, "cmbHora");
            this.cmbHora.Name = "cmbHora";
            // 
            // cmbFecha
            // 
            this.cmbFecha.FormattingEnabled = true;
            resources.ApplyResources(this.cmbFecha, "cmbFecha");
            this.cmbFecha.Name = "cmbFecha";
            // 
            // cmbPrestacion
            // 
            this.cmbPrestacion.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPrestacion, "cmbPrestacion");
            this.cmbPrestacion.Name = "cmbPrestacion";
            // 
            // cmbPersonal
            // 
            this.cmbPersonal.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPersonal, "cmbPersonal");
            this.cmbPersonal.Name = "cmbPersonal";
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.FormattingEnabled = true;
            resources.ApplyResources(this.cmbEspecialidad, "cmbEspecialidad");
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            // 
            // lblHora
            // 
            resources.ApplyResources(this.lblHora, "lblHora");
            this.lblHora.Name = "lblHora";
            this.lblHora.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // lblFecha
            // 
            resources.ApplyResources(this.lblFecha, "lblFecha");
            this.lblFecha.Name = "lblFecha";
            // 
            // lblPrestacion
            // 
            resources.ApplyResources(this.lblPrestacion, "lblPrestacion");
            this.lblPrestacion.Name = "lblPrestacion";
            // 
            // lblPersonal
            // 
            resources.ApplyResources(this.lblPersonal, "lblPersonal");
            this.lblPersonal.Name = "lblPersonal";
            // 
            // lblEspecialidad
            // 
            resources.ApplyResources(this.lblEspecialidad, "lblEspecialidad");
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lblPaciente
            // 
            resources.ApplyResources(this.lblPaciente, "lblPaciente");
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtPaciente
            // 
            resources.ApplyResources(this.txtPaciente, "txtPaciente");
            this.txtPaciente.Name = "txtPaciente";
            // 
            // eSPECIALIDADBindingSource
            // 
            this.eSPECIALIDADBindingSource.DataSource = typeof(CheekiBreeki.CMH.Terminal.DAL.ESPECIALIDAD);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eSPECIALIDADBindingSource1
            // 
            this.eSPECIALIDADBindingSource1.DataMember = "ESPECIALIDAD";
            this.eSPECIALIDADBindingSource1.DataSource = this.dataSet1;
            // 
            // eSPECIALIDADTableAdapter
            // 
            this.eSPECIALIDADTableAdapter.ClearBeforeFill = true;
            // 
            // frmAgendarAtencion
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmAgendarAtencion";
            this.Load += new System.EventHandler(this.frmAgendarAtencion_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eSPECIALIDADBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSPECIALIDADBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem agendaDiariaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fichasMédicasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasMédicasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atenciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirConsultaMédicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarConsultaMédicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agendarAtenciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anularAtenciónToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblPrestacion;
        private System.Windows.Forms.Label lblPersonal;
        private System.Windows.Forms.Button btnAgendar;
        private System.Windows.Forms.ComboBox cmbHora;
        private System.Windows.Forms.ComboBox cmbFecha;
        private System.Windows.Forms.ComboBox cmbPrestacion;
        private System.Windows.Forms.ComboBox cmbPersonal;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.BindingSource eSPECIALIDADBindingSource;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource eSPECIALIDADBindingSource1;
        private DataSet1TableAdapters.ESPECIALIDADTableAdapter eSPECIALIDADTableAdapter;
    }
}

