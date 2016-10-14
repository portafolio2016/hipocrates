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
        int descuentoPesos = 0;

        [DataMember]
        public int DescuentoPesos
        {
            get { return descuentoPesos; }
            set { descuentoPesos = value; }
        }

        
    }
}
