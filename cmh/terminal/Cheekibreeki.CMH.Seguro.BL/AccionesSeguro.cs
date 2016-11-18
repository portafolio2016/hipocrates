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
        public int obtenerDescuentoPrestacion(int rutAfiliado, string codigoPrestacion, int precioPrestacion)
        {
            //obtenerner afiliado
            AFILIADO afiliado = obtenerAfiliado(rutAfiliado);
            if (afiliado == null)
            {
                return 0;
            }
            //obtener plan afiliado
            PLAN plan = obtenerPlanAfiliado(afiliado);
            //obtener beneficios del afiliado
            List<BENEFICIO> beneficios = obtenerBeneficiosPlan(plan.ID_PLAN);
            //obtener prestacion
            PRESTACION prestacion = obtenerPrestacion(codigoPrestacion);
            //obtener beneficio aplicable a la prestación
            BENEFICIO beneficio = obtenerBeneficioPrestacion(prestacion, beneficios);
            //obtener descuento
            int descuento = calcularDescuentoPrestacion(precioPrestacion, beneficio);
            return descuento;
        }

        public int calcularDescuentoPrestacion(int precioPrestacion, BENEFICIO beneficio)
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
                    return null;
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
                List<BENEFICIO> beneficios = (
                                                from b in entities.BENEFICIO
                                                where idPlan == b.ID_PLAN
                                                select b
                                              ).ToList<BENEFICIO>();
                return beneficios;
            }
        }

        public PRESTACION obtenerPrestacion(string codigoPrestacion)
        {
            using (var entities = new SeguroEntities())
            {
                PRESTACION prestacion = new PRESTACION();
                try
                {
                    prestacion = (
                        from p in entities.PRESTACION
                        where codigoPrestacion == p.CODIGO
                        select p
                        ).First<PRESTACION>();
                    return prestacion;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public BENEFICIO obtenerBeneficioPrestacion(PRESTACION prestacion, List<BENEFICIO> beneficios)
        {
            BENEFICIO beneficio = null;
            using (var entities = new SeguroEntities())
            {
                beneficio = entities.BENEFICIO.Where(d => d.ID_PRESTACION == prestacion.ID_PRESTACION).FirstOrDefault();
            }
            return beneficio;
        }

        public string obtenerNombreEmpresa(int afiliadoRut)
        {
            AFILIADO afiliado = obtenerAfiliado(afiliadoRut);
            EMPRESA empresa = new EMPRESA();
            if (afiliado == null)
                empresa.NOMBRE = "No tiene seguro";
            else
            {
                using (var context = new SeguroEntities())
                {
                    afiliado.PLAN = context.PLAN.Find(afiliado.ID_PLAN);
                    empresa = afiliado.PLAN.EMPRESA;
                }
            }
            return (empresa.NOMBRE);
        }
    }
}
