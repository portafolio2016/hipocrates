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
        public int idEquipo { get; set; }
        public string nombreEquipo { get; set; }


        public ListaInventarioDG(int idInventario, int cantidad,int idEquipo, string nombreEquipo)
        {
            this.idInventario = idInventario;
            this.cantidad = cantidad;
            this.idEquipo = idEquipo;
            this.nombreEquipo = nombreEquipo;
        }
    }
}
