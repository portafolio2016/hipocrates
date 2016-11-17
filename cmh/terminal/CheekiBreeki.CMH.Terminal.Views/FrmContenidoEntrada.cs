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
    public partial class FrmContenidoEntrada : Form
    {
        public FrmContenidoEntrada(string contenido)
        {
            InitializeComponent();
            rtContenido.Text = contenido;
        }
    }
}
