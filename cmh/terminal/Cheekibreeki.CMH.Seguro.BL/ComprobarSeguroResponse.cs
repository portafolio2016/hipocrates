using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheekibreeki.CMH.Seguro.BL
{
    public class ComprobarSeguroResponse
    {

        private bool tieneSeguro;
        private int descuento;

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
        
        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            ComprobarSeguroResponse c = (ComprobarSeguroResponse)obj;
            return (this.descuento == c.descuento && this.tieneSeguro == c.tieneSeguro);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new NotImplementedException();
            return base.GetHashCode();
        }
    }
}
