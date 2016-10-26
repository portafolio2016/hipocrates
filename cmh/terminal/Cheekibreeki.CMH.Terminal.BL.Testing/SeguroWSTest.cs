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
            SeguroEntities entities = new SeguroEntities();
            //crear tipoEmpresas
            T_EMPRESA tipoEmpresaPublica = crearTipoEmpresa("Publica", entities);
            T_EMPRESA tipoEmpresaPrivada = crearTipoEmpresa("Privada", entities);
            //crear empresa
            EMPRESA fonasa = crearEmpresa("Fonasa", tipoEmpresaPublica, entities);
            EMPRESA banmedica = crearEmpresa("Banmedica", tipoEmpresaPrivada, entities);
            //crear plan
            PLAN planPublico = crearPlan("Plan Fonasa", fonasa, entities);
            PLAN planPrivado = crearPlan("Plan Banmedica", banmedica, entities);
            //crear afiliado
            AFILIADO afiliadoPublico = crearAfiliado(12345678, "1", planPublico, entities);
            AFILIADO afiliadoPrivado = crearAfiliado(98765432, "2", planPrivado, entities);
            //crear beneficio
            BENEFICIO beneficioPrivado = crearBeneficio(25, 10000, entities);
            BENEFICIO beneficioPublico = crearBeneficio(40, 10000, entities);
            //crear prestacion
            PRESTACION prestacion = crearPrestacion("Examen de sangre", "EX001", beneficioPublico, entities);
            AccionesSeguro accionesSeguro = new AccionesSeguro();
            //Caso 1
            //Afiliado tiene un seguro privado, obtiene un 25% de descuento          
            ComprobarSeguroResponse response = accionesSeguro.comprobarSeguro(afiliadoPrivado, prestacion);
            ComprobarSeguroResponse expectedResponse1 = new ComprobarSeguroResponse();
            Assert.IsTrue(response.Equals(expectedResponse1));
            //Caso 2
            //Afiliado tiene un seguro público, obtiene un 40% de descuento
            //Caso 3
            //Afiliado no tiene seguro
            //Caso 4: 
            //Afiliado no existe
            //Caso 5: prestación no existe
            //Caso 6: empresa no existe
        }

        private T_EMPRESA crearTipoEmpresa(String nombre, SeguroEntities entities)
        {
            T_EMPRESA tipoEmpresa = new T_EMPRESA();
            tipoEmpresa.NOMBRE = nombre;
            entities.T_EMPRESA.Add(tipoEmpresa);
            entities.SaveChangesAsync();
            return tipoEmpresa;
        }

        private PRESTACION crearPrestacion(String nombre, String codigo, BENEFICIO beneficio,SeguroEntities entities)
        {
            List<PRESTACION> prestaciones = (from p in entities.PRESTACION 
                                        where p.CODIGO == codigo 
                                        select p).ToList<PRESTACION>();
            if (prestaciones.Count() > 0)
            {
                PRESTACION prestacionOld = prestaciones.First<PRESTACION>();
                entities.PRESTACION.Remove(prestacionOld);
            }
            PRESTACION prestacion = new PRESTACION();
            prestacion.NOMBRE = nombre;
            prestacion.CODIGO = codigo;
            prestacion.BENEFICIO.Add(beneficio);
            entities.PRESTACION.Add(prestacion);
            entities.SaveChangesAsync();
            return prestacion;
        }

        private EMPRESA crearEmpresa(String nombre, T_EMPRESA tipoEmpresa, SeguroEntities entities){
            EMPRESA empresa = new EMPRESA();
            empresa.NOMBRE = nombre;
            empresa.T_EMPRESA = tipoEmpresa;
            entities.EMPRESA.Add(empresa);
            entities.SaveChangesAsync();
            return empresa;
        }

        private PLAN crearPlan(String nombre, EMPRESA empresa, SeguroEntities entities)
        {
            PLAN plan = new PLAN();
            plan.NOMBRE = nombre;
            plan.EMPRESA = empresa;
            entities.PLAN.Add(plan);
            entities.SaveChangesAsync();
            return plan;
        }

        private AFILIADO crearAfiliado(int rut, String digitoVerificador, PLAN plan, SeguroEntities entities)
        {
            AFILIADO afiliado = new AFILIADO();
            afiliado.RUT = rut;
            afiliado.VERIFICADOR = digitoVerificador;
            afiliado.PLAN = plan;
            entities.AFILIADO.Add(afiliado);
            entities.SaveChangesAsync();
            return afiliado;
        }

        private BENEFICIO crearBeneficio(decimal porcentaje, int limite, SeguroEntities entities)
        {
            BENEFICIO beneficio = new BENEFICIO();
            beneficio.PORCENTAJE = porcentaje;
            beneficio.LIMITE_DINERO = limite;
            entities.BENEFICIO.Add(beneficio);
            entities.SaveChangesAsync();
            return beneficio;
        }
    }
}
