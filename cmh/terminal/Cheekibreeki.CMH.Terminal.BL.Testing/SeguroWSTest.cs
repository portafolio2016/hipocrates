using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cheekibreeki.CMH.Seguro.BL;
using Cheekibreeki.CMH.Seguro.DAL;
using System.Collections.Generic;
using System.Linq;
namespace Cheekibreeki.CMH.Terminal.BL.Testing
{
    [TestClass]
    public class SeguroWSTest
    {
        [TestMethod]
        public void TestComprobarSeguro()
        {
            //Pre test
            //crear prestacion
            //Caso 1
            //Afiliado tiene un seguro privado, obtiene un 25% de descuento
            //crear afiliado
            //crear plan
            //crear beneficio
            
            
            
            //Caso 2
            //Afiliado tiene un seguro público, obtiene un 40% de descuento
            //Caso 3
            //Afiliado no tiene seguro
            //Caso 4: 
            //Afiliado no existe
            //Caso 5: prestación no existe
            //Caso 6: empresa no existe
        }

        private List<T_EMPRESA> crearTiposEmpresas()
        {
            SeguroEntities entities = new SeguroEntities();
            //crear tipo empresa
            T_EMPRESA tipoEmpresaPrivada = new T_EMPRESA();
            tipoEmpresaPrivada.NOMBRE = "Privada";
            T_EMPRESA tipoEmpresaPublica = new T_EMPRESA();
            tipoEmpresaPublica.NOMBRE = "Publica";
            entities.T_EMPRESA.Add(tipoEmpresaPublica);
            entities.T_EMPRESA.Add(tipoEmpresaPrivada);
            entities.SaveChangesAsync();
            List<T_EMPRESA> tiposEmpresas = (from t in entities.T_EMPRESA select t).ToList<T_EMPRESA>();
            return tiposEmpresas;
        }

        private List<EMPRESA> crearEmpresas()
        {
            crearTiposEmpresas();
            SeguroEntities entites = new SeguroEntities();
            //Crear empresa
            EMPRESA empresaPublica = new EMPRESA();
            empresaPublica.NOMBRE = "Fonasa";
            EMPRESA empresaPrivada = new EMPRESA();
            empresaPrivada.NOMBRE = "Banmedica";
            //Agregar tipo empresa a empresa
            T_EMPRESA tipoEmpresaPublica = (from t in entites.T_EMPRESA
                                     where t.NOMBRE == "Publica"
                                     select t).First<T_EMPRESA>();
            T_EMPRESA tipoEmpresaPrivada = (from t in entites.T_EMPRESA
                                     where t.NOMBRE == "Privada"
                                     select t).First<T_EMPRESA>();
            empresaPublica.T_EMPRESA = tipoEmpresaPublica;
            empresaPrivada.T_EMPRESA = tipoEmpresaPrivada;
            //persistir
            entites.EMPRESA.Add(empresaPublica);
            entites.EMPRESA.Add(empresaPrivada);
            //select
            List<EMPRESA> empresas = (from e in entites.EMPRESA
                                      select e).ToList<EMPRESA>();
            //return
            return empresas;
        }

        private List<PRESTACION> crearPrestaciones()
        {
            SeguroEntities entities = new SeguroEntities();
            PRESTACION prestacion = new PRESTACION();
            prestacion.NOMBRE = "Examen de sangre";
            prestacion.CODIGO = "EX01";
            entities.PRESTACION.Add(prestacion);
            entities.SaveChangesAsync();
            return (from p in entities.PRESTACION select p).ToList<PRESTACION>();
        }

        //private List<BENEFICIO> crearBeneficios()
        //{
        //    //SeguroEntities entities = new SeguroEntities();
        //    //BENEFICIO beneficio = new BENEFICIO();
        //    //beneficio.PORCENTAJE = 40;
        //    //beneficio.LIMITE_DINERO = 100000;
        //    //entities.BENEFICIO.Add(beneficio);
        //    //entities.SaveChangesAsync();
        //    //return (from b in entities.BENEFICIO select b).ToList<BENEFICIO>();
        //}
    }
}
