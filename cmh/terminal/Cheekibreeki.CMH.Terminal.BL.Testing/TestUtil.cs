using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cheekibreeki.CMH.Seguro.DAL;
namespace Cheekibreeki.CMH.Terminal.BL.Testing
{
    public class TestUtil
    {
        public static int crearTipoEmpresa(string nombre)
        {
            using(var entities = new SeguroEntities())
            {
                T_EMPRESA tipoEmpresa = new T_EMPRESA();
                tipoEmpresa.NOMBRE = nombre;
                entities.T_EMPRESA.Add(tipoEmpresa);
                entities.SaveChangesAsync();
                return tipoEmpresa.ID_T_EMPRESA;
            }
        }

        public static int crearEmpresa(string nombre, int idTipoEmpresa)
        {
            using (var entities = new SeguroEntities())
            {
                EMPRESA empresa = new EMPRESA();
                empresa.NOMBRE = nombre;
                empresa.ID_T_EMPRESA = idTipoEmpresa;
                entities.EMPRESA.Add(empresa);
                entities.SaveChangesAsync();
                return  empresa.ID_EMPRESA;
            }
        }

        public static int crearPlan(string nombrePlan, int idEmpresa)
        {
            using (var entities = new SeguroEntities())
            {
                PLAN plan = new PLAN();
                plan.NOMBRE = nombrePlan;
                plan.ID_EMPRESA = idEmpresa;
                entities.PLAN.Add(plan);
                entities.SaveChangesAsync();
                return plan.ID_PLAN;
            }
        }

        public static int crearPrestacion(string nombrePrestacion, string codigo)
        {
            using (var entities = new SeguroEntities())
            {
                PRESTACION prestacion = new PRESTACION();
                prestacion.NOMBRE = nombrePrestacion;
                prestacion.CODIGO = codigo + System.DateTime.Now.ToString();
                entities.PRESTACION.Add(prestacion);
                entities.SaveChangesAsync();
                return prestacion.ID_PRESTACION;
                //return (from p in entities.PRESTACION
                //         select p).First<PRESTACION>().ID_PRESTACION;
            }
        }

        public static int crearBeneficio(decimal porcentaje, int limite, int idPlan, int idPrestacion)
        {
            using (var entities = new SeguroEntities())
            {
                BENEFICIO beneficio = new BENEFICIO();
                beneficio.ID_PLAN = idPlan;
                beneficio.ID_PRESTACION = idPrestacion;
                beneficio.PORCENTAJE = porcentaje;
                beneficio.LIMITE_DINERO = limite;
                entities.BENEFICIO.Add(beneficio);
                entities.SaveChangesAsync();
                return beneficio.ID_BENEFICIO;
            }
        }

        public static int crearAfiliado(int rut, string verificador)
        {
            using (var entities = new SeguroEntities())
            {
                AFILIADO afiliado = new AFILIADO();
                afiliado.RUT = rut;
                afiliado.VERIFICADOR = verificador;
                entities.AFILIADO.Add(afiliado);
                entities.SaveChangesAsync();
                return afiliado.ID_AFILIADO;
            }
        }

        public static int crearAfiliado(int rut, string verificador, int idPlan)
        {
            using (var entities = new SeguroEntities())
            {
                AFILIADO afiliado = new AFILIADO();
                afiliado.RUT = rut;
                afiliado.VERIFICADOR = verificador;
                afiliado.ID_PLAN = idPlan;
                entities.AFILIADO.Add(afiliado);
                entities.SaveChangesAsync();
                return afiliado.ID_AFILIADO;
            }
        }
    }
}
