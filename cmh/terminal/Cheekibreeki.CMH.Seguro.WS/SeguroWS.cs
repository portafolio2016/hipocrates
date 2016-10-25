using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Cheekibreeki.CMH.Seguro.WS
{
    public class SeguroWS : ISeguroWS
    {
        public SeguroResponse obtenerBeneficio(SeguroRequest seguroRequest)
        {
            SeguroResponse response = null;
            //TODO:implementar
            return response;
        }

        public string GetData(int value)
        {
            throw new NotImplementedException();
        }
    }
}
