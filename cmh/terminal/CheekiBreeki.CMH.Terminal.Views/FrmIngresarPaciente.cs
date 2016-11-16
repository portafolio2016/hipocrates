﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheekiBreeki.CMH.Terminal.Views
{
    public partial class FrmIngresarPaciente : Form
    {
        FrmLogin login = null;
        bool closeApp;

        public FrmIngresarPaciente(FrmLogin padre)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            login = padre;
            closeApp = true;
        }

        private void FrmIngresarPaciente_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (closeApp)
                Application.Exit();
        }
    }
}
