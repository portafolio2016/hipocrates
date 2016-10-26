using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cheekibreeki.CMH.Seguro.DAL;
namespace Cheekibreeki.CMH.Seguro.BL
{
    public class AccionesSeguro
    {
        public int obtenerDescuentoPrestacion(int precioPrestacion, BENEFICIO beneficio)
        {
            return 0;
            
        }

        public AFILIADO obtenerAfiliado(String rut)
        {
            return new AFILIADO();
        }

        public PLAN obtenerPlanAfiliado(AFILIADO afiliado)
        {
            return new PLAN();
        }

        public List<BENEFICIO> obtenerBeneficiosPlan(PLAN plan)
        {
            return new List<BENEFICIO>();
        }

        public BENEFICIO obtenerBeneficioPrestacion(PRESTACION prestacion)
        {
            return new BENEFICIO();
        }
    }
}
