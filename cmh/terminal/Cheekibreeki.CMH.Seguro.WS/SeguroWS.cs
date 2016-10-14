using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Cheekibreeki.CMH.Seguro.WS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class SeguroWS : ISeguroWS
    {
        public string TestMethod(int value)
        {
            return string.Format("You entered: {0}", value);
        }



        public SeguroResponse obtenerBeneficio(SeguroRequest seguroRequest)
        {
            SeguroResponse response = null;
            //TODO:implementar
            return response;
        }
    }
}
