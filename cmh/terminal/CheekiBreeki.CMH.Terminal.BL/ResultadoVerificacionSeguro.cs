using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheekiBreeki.CMH.Terminal.BL
{
    public class ResultadoVerificacionSeguro
    {
        private bool tieneSeguro;
        private int descuento;
        private string aseguradora;

        public int Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }
        
        public bool TieneSeguro
        {
            get { return tieneSeguro; }
            set { tieneSeguro = value; }
        }

        public string Aseguradora
        {
            get { return aseguradora; }
            set { aseguradora = value; }
        }
        
    }
}
