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
            int fraccion = (int)(precioPrestacion * beneficio.PORCENTAJE / 100);
            if (fraccion > beneficio.LIMITE_DINERO)
            {
                return beneficio.LIMITE_DINERO.Value;
            }
            else
            {
                return fraccion;
            }
        }

        public AFILIADO obtenerAfiliado(int rut)
        {
            using (var entities = new SeguroEntities())
            {
                List<AFILIADO> afiliados = (from a in entities.AFILIADO
                                      where a.RUT.Value == rut
                                      select a).ToList<AFILIADO>();
                if (afiliados.Count() == 0)
                {
                    throw new Exception("Afiliado no existe");
                }
                else
                {
                    return afiliados.First<AFILIADO>();
                }
            }
            
        }

        public PLAN obtenerPlanAfiliado(AFILIADO afiliado)
        {
            using (var entities = new SeguroEntities())
            {
                PLAN plan = (from p in entities.PLAN
                                 where afiliado.ID_PLAN == p.ID_PLAN
                                 select p).First<PLAN>();
                return plan;
            }
        }

        public List<BENEFICIO> obtenerBeneficiosPlan(int idPlan)
        {
            using (var entities = new SeguroEntities())
            {
                PLAN plan = (from p in entities.PLAN
                                 where p.ID_PLAN == idPlan
                                 select p).First<PLAN>();
                return new List<BENEFICIO>();
            }
        }

        public BENEFICIO obtenerBeneficioPrestacion(PRESTACION prestacion)
        {
            using(var entities = new SeguroEntities()){
                BENEFICIO beneficio = (from b in entities.BENEFICIO
                                           where b.ID_PRESTACION == prestacion.ID_PRESTACION
                                           select b).First<BENEFICIO>();
                return beneficio;
            }
            
        }
    }
}
