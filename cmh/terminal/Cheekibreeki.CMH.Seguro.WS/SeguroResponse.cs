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
        private bool afiliadoTieneSeguro;
        int descuentoPesos = 0;
        string nombreAseguradora;

        public SeguroResponse()
        {
            this.descuentoPesos = 0;
            this.afiliadoTieneSeguro = false;
        }
        
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

        [DataMember]
        public string NombreAseguradora
        {
            get { return nombreAseguradora; }
            set { nombreAseguradora = value; }
        }
    }
}
