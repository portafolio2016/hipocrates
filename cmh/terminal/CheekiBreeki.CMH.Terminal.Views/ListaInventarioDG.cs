using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheekiBreeki.CMH.Terminal.Views
{
    public class ListaInventarioDG
    {
        [DisplayName("ID Inventario")]
        public int idInventario { get; set; }
        [DisplayName("Cantidad")]
        public int cantidad { get; set; }
        [DisplayName("ID Equipo")]
        public int idEquipo { get; set; }
        [DisplayName("Nombre equipo")]
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
