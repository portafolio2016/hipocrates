using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cheekibreeki.CMH.Seguro.DAL;
namespace Cheekibreeki.CMH.Terminal.BL.Testing
{
    private class TestUtil
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

        public static int crearPlan()
        {
            
        }

        public static int crearPrestacion(string nombrePrestacion, string codigo)
        {
            using (var entities = new SeguroEntities())
            {
                PRESTACION prestacion = new PRESTACION();
                prestacion.NOMBRE = nombrePrestacion;
                prestacion.CODIGO = codigo;
                entities.PRESTACION.Add(prestacion);
                return prestacion.ID_PRESTACION;
            }
        }

        public static int crearBeneficio()
        {

        }

        public static int crearAfiliado()
        {

        }
    }
}
