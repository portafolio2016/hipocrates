using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cheekibreeki.CMH.Seguro.DAL;
using System.Linq;
namespace Cheekibreeki.CMH.Seguro.BL
{
    public class AccionesSeguro
    {
        public ComprobarSeguroResponse comprobarSeguro(AFILIADO afiliado, PRESTACION prestacion)
        {
            SeguroEntities entities = new SeguroEntities();
            ComprobarSeguroResponse comprobarSeguroResponse = new ComprobarSeguroResponse();
            PLAN plan = (from p in entities.PLAN
                         where afiliado.ID_PLAN == p.ID_PLAN
                         select p).first<PLAN>();

            return comprobarSeguroResponse;
        }
    }
}
