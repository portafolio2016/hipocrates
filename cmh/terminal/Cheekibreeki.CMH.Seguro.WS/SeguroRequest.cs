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
        private int afiliadoRut;
        private string codigoPrestacion;
        private int precioPrestacion;

        [DataMember]
        public int PrecioPrestacion
        {
            get { return precioPrestacion; }
            set { precioPrestacion = value; }
        }
        
        [DataMember]
        public string CodigoPrestacion
        {
            get { return codigoPrestacion; }
            set { codigoPrestacion = value; }
        }
        [DataMember]
        public int AfiliadoRut
        {
            get { return afiliadoRut; }
            set { afiliadoRut = value; }
        }
        


    }
}
