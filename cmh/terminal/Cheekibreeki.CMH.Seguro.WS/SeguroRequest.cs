using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Cheekibreeki.CMH.Seguro.WS
{
    [DataContract]
    public class SeguroRequest
    {
        private string afiliadoRut;
        private string codigoPrestacion;
        [DataMember]
        public string CodigoPrestacion
        {
            get { return codigoPrestacion; }
            set { codigoPrestacion = value; }
        }
        [DataMember]
        public string AfiliadoRut
        {
            get { return afiliadoRut; }
            set { afiliadoRut = value; }
        }
        


    }
}
