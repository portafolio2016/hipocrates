using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cheekibreeki.CMH.Seguro.WS
{
    [DataContract]
    public class SeguroResponse
    {
        public SeguroResponse()
        {
            this.descuentoPesos = 0;
            this.afiliadoTieneSeguro = false;
        }
        int descuentoPesos = 0;

        private bool afiliadoTieneSeguro;
        [DataMember]
        public bool AfiliadoTieneSeguro
        {
            get { return afiliadoTieneSeguro; }
            set { afiliadoTieneSeguro = value; }
        }
        
        [DataMember]
        public int DescuentoPesos
        {
            get { return descuentoPesos; }
            set { descuentoPesos = value; }
        }

        
    }
}
