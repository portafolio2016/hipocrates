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
        public ComprobarSeguroResponse comprobarSeguro(int rutAfiliado, String codigoPrestacion, int precioPrestacion)
        {
            SeguroEntities entities = new SeguroEntities();
            //Obtener afiliado
            AFILIADO afiliado = (from a in entities.AFILIADO
                                 where a.RUT == rutAfiliado
                                 select a).First<AFILIADO>();
            PLAN plan = (from p in entities.PLAN
                         where afiliado.ID_PLAN == p.ID_PLAN
                         select p).First<PLAN>();
            ComprobarSeguroResponse comprobarSeguroResponse = new ComprobarSeguroResponse();
            if (plan == null)
            {
                comprobarSeguroResponse.TieneSeguro = true;
                comprobarSeguroResponse.Descuento = 0;
                return comprobarSeguroResponse;
            }
            comprobarSeguroResponse.TieneSeguro = true;
            //obtener beneficio del plan para prestacion
            List<BENEFICIO> beneficios = (from b in entities.BENEFICIO
                                          where plan.ID_PLAN == b.ID_PLAN
                                          select b).ToList<BENEFICIO>();
            //obtener prestacion
            PRESTACION prestacion = (from p in entities.PRESTACION
                                         where p.CODIGO == codigoPrestacion
                                         select p).First<PRESTACION>();
            //obtener beneficio
            BENEFICIO beneficioParaPrestacion = (from b in beneficios
                                                 where b.ID_PRESTACION == prestacion.ID_PRESTACION
                                                 select b).First<BENEFICIO>();
            //llenar comprobarSeguroResponse
            
            comprobarSeguroResponse.Descuento = Decimal.ToInt32(precioPrestacion * (beneficioParaPrestacion.PORCENTAJE / 100));

            return comprobarSeguroResponse;
        }
    }
}
