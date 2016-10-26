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
        public void obtenerDescuentoTest()
        {
            AccionesSeguro accionesSeguro = new AccionesSeguro();
            //caso 1
            int precioPrestacion = 100;
            BENEFICIO beneficio = new BENEFICIO();
            beneficio.PORCENTAJE = 25;
            beneficio.LIMITE_DINERO = 90;
            int resultadoEsperado1 = 25;
            int resultado1 = accionesSeguro.obtenerDescuentoPrestacion(precioPrestacion, beneficio);
            Assert.IsTrue(resultado1 == resultadoEsperado1, "Resultado: " + resultado1 + " Resultado esperado: " + resultadoEsperado1);
            //caso 2
            precioPrestacion = 1000;
            int resultadoEsperado2 = 90;
            int resultado2 = accionesSeguro.obtenerDescuentoPrestacion(precioPrestacion, beneficio);
            Assert.IsTrue(resultado2 == resultadoEsperado2, "Res:" + resultado2 + " Esperado: " + resultadoEsperado2);
        }

        [TestMethod]
        public void obtenerAfiliadoTest()
        {
            using (var entities = new SeguroEntities())
            {
                //prep
                AFILIADO afiliado = new AFILIADO();
                afiliado.RUT = 12345;
                afiliado.VERIFICADOR = "K";
                entities.AFILIADO.Add(afiliado);
                entities.SaveChangesAsync();
                AccionesSeguro accionesSeguro = new AccionesSeguro();
                //Caso1: obtener afiliado correctamente
                AFILIADO result1 = accionesSeguro.obtenerAfiliado(afiliado.RUT.Value);
                Assert.AreNotEqual(result1, null);
                //Caso2: afiliado no existe
                try
                {
                    AFILIADO result2 = accionesSeguro.obtenerAfiliado(0);
                    Assert.Fail("No debería tocar esta línea");
                }
                catch (Exception)
                {
                }

            }
        }

        [TestMethod]
        public void obtenerPlanAfiliadoTest()
        {
            using (var entities = new SeguroEntities())
            {
                #region prep
                T_EMPRESA tipoEmpresa = new T_EMPRESA();
                tipoEmpresa.NOMBRE = "Empresa publica";
                entities.T_EMPRESA.Add(tipoEmpresa);
                entities.SaveChangesAsync();
                EMPRESA empresa = new EMPRESA();
                empresa.NOMBRE = "Fonasa";
                empresa.ID_T_EMPRESA = tipoEmpresa.ID_T_EMPRESA;
                entities.EMPRESA.Add(empresa);
                entities.SaveChangesAsync();
                PLAN plan = new PLAN();
                plan.NOMBRE = "Plan bacan";
                plan.ID_EMPRESA = empresa.ID_EMPRESA;
                entities.PLAN.Add(plan);
                entities.SaveChangesAsync();
                AFILIADO afiliado = new AFILIADO();
                afiliado.RUT = 999;
                afiliado.VERIFICADOR = "k";
                afiliado.ID_PLAN = plan.ID_PLAN;
                AFILIADO sinPlan = new AFILIADO();
                sinPlan.RUT = 123;
                entities.AFILIADO.Add(sinPlan);
                entities.AFILIADO.Add(afiliado);
                entities.SaveChangesAsync();
                #endregion
                //Caso 1: obtiene plan correctamente
                AccionesSeguro accionesSeguro = new AccionesSeguro();
                PLAN resultado1 = accionesSeguro.obtenerPlanAfiliado(afiliado);
                Assert.IsTrue(resultado1.NOMBRE == plan.NOMBRE);
                //Caso 2: afiliado no tiene plan
                try
                {
                    PLAN resultado2 = accionesSeguro.obtenerPlanAfiliado(sinPlan);
                    Assert.Fail("No debería tocar esta parte");
                }
                catch (Exception)
                { 
                }
            }
            
            
        }

        [TestMethod]
        public void obtenerBeneficiosPlanTest()
        {
            using (var entities = new SeguroEntities())
            {
                AccionesSeguro accionesSeguro = new AccionesSeguro();
                //Caso1: Plan obtiene beneficios                
                //Caso2: Plan no tiene beneficios
                throw new NotImplementedException();
            }
            
        }

        [TestMethod]
        public void obtenerBeneficioPrestacion()
        {
            throw new NotImplementedException();
        }
    }
}
