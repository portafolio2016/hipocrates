using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheekiBreeki.CMH.Terminal.Views
{
    public class ListaInventarioDG
    {
        public int idInventario { get; set; }
        public int cantidad { get; set; }
        public string nombreEquipo { get; set; }


        public ListaInventarioDG(int idInventario, int cantidad, string nombreEquipo)
        {
            this.idInventario = idInventario;
            this.cantidad = cantidad;
            this.nombreEquipo = nombreEquipo;
        }
    }
}
