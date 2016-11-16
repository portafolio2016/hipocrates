﻿using CheekiBreeki.CMH.Terminal.BL;
using CheekiBreeki.CMH.Terminal.DAL;
using System;
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
    public partial class FrmAbrirCaja : Form
    {
        AccionesTerminal at = new AccionesTerminal();
        FrmLogin login = null;
        bool closeApp;

        public FrmAbrirCaja(FrmLogin padre)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            login = padre;
            closeApp = true;
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            bool res = false;
            try
            {
                FUNCIONARIO funcionario = FrmLogin.usuarioLogeado.Personal.FUNCIONARIO.FirstOrDefault();
                int dinero = int.Parse(txtDinero.Text);
                res = at.abrirCaja(funcionario, dinero);
            }
            catch (Exception ex)
            {
                res = false;
            }
            if (res)
            {
                FrmMain frmMain = new FrmMain(login);
                frmMain.Show();
                frmMain.Activate();
                this.Hide();
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Error al abrir caja";
                lblError.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void txtDinero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}