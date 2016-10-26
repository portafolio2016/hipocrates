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
            T_EMPRESA tipoEmpresaPublica = crearTipoEmpresa("Publica");
            T_EMPRESA tipoEmpresaPrivada = crearTipoEmpresa("Privada");
            //crear empresa
            EMPRESA fonasa = crearEmpresa("Fonasa", tipoEmpresaPublica);
            EMPRESA banmedica = crearEmpresa("Banmedica", tipoEmpresaPrivada);
            //crear plan
            PLAN planPublico = crearPlan("Plan Fonasa", fonasa);
            PLAN planPrivado = crearPlan("Plan Banmedica", banmedica);
            //crear afiliado
            AFILIADO afiliadoPublico = crearAfiliado(12345678, "1", planPublico);
            AFILIADO afiliadoPrivado = crearAfiliado(98765432, "2", planPrivado);
            AFILIADO afiliadoSinSeguro = crearAfiliado(123123, "3", null);
            //crear prestacion
            PRESTACION prestacion = crearPrestacion("Examen de sangre", "EX001");
            //crear beneficio
            BENEFICIO beneficioPrivado = crearBeneficio(25, 10000, prestacion.ID_PRESTACION);
            BENEFICIO beneficioPublico = crearBeneficio(40, 10000, prestacion.ID_PRESTACION);
            AccionesSeguro accionesSeguro = new AccionesSeguro();
            //Caso 1
            //Afiliado tiene un seguro privado, obtiene un 25% de descuento          
            ComprobarSeguroResponse response = accionesSeguro.comprobarSeguro(afiliadoPrivado.RUT.Value, prestacion.CODIGO, 100);
            ComprobarSeguroResponse expectedResponse1 = new ComprobarSeguroResponse(true, 25);
            Assert.IsTrue(response.Equals(expectedResponse1), "Caso 1 fallando");
            //Caso 2
            //Afiliado tiene un seguro público, obtiene un 40% de descuento
            ComprobarSeguroResponse response2 = accionesSeguro.comprobarSeguro(afiliadoPublico.RUT.Value, prestacion.CODIGO, 100);
            ComprobarSeguroResponse expectedResponse2 = new ComprobarSeguroResponse(true, 40);
            Assert.IsTrue(response2.Equals(expectedResponse2));
            //Caso 3
            //Afiliado no tiene seguro
            ComprobarSeguroResponse response3 = accionesSeguro.comprobarSeguro(afiliadoSinSeguro.RUT.Value, prestacion.CODIGO, 100);
            ComprobarSeguroResponse expectedResponse3 = new ComprobarSeguroResponse();
            Assert.IsTrue(response3.Equals(expectedResponse3));
            //Caso 4: 
            //Afiliado no existe
            ComprobarSeguroResponse response4 = accionesSeguro.comprobarSeguro(0, prestacion.CODIGO, 100);
            ComprobarSeguroResponse expectedResponse4 = new ComprobarSeguroResponse();
            Assert.IsFalse(response4.Equals(expectedResponse4));
            //Caso 5: prestación no existe
            ComprobarSeguroResponse response5 = accionesSeguro.comprobarSeguro(afiliadoPrivado.RUT.Value, "codigofalso", 100);
            ComprobarSeguroResponse expectedResponse5 = new ComprobarSeguroResponse();
            Assert.IsFalse(response5.Equals(expectedResponse5));
        }

        private T_EMPRESA crearTipoEmpresa(String nombre)
        {
            using (var entities = new SeguroEntities())
            {
                T_EMPRESA tipoEmpresa = new T_EMPRESA();
                tipoEmpresa.NOMBRE = nombre;
                entities.T_EMPRESA.Add(tipoEmpresa);
                entities.SaveChangesAsync();
                return tipoEmpresa;
            }
        }

        private PRESTACION crearPrestacion(String nombre, String codigo)
        {
            using (var entities = new SeguroEntities())
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

                entities.PRESTACION.Add(prestacion);
                entities.SaveChangesAsync();
                prestacion = (from p in entities.PRESTACION
                              where p.CODIGO == codigo
                              select p).FirstOrDefault<PRESTACION>();
                return prestacion;
            }
        }

        private EMPRESA crearEmpresa(String nombre, T_EMPRESA tipoEmpresa){
            EMPRESA empresa = new EMPRESA();
            empresa.NOMBRE = nombre;
            empresa.T_EMPRESA = tipoEmpresa;
            using(var entities = new SeguroEntities())
            {
                entities.EMPRESA.Add(empresa);
                entities.SaveChangesAsync();
            }
            
            return empresa;
        }

        private PLAN crearPlan(String nombre, EMPRESA empresa)
        {
            PLAN plan = new PLAN();
            plan.NOMBRE = nombre;
            plan.EMPRESA = empresa;
            using (var entities = new SeguroEntities())
            {
                entities.PLAN.Add(plan);
                entities.SaveChangesAsync();
                return plan;
            }
        }

        private AFILIADO crearAfiliado(int rut, String digitoVerificador, PLAN plan)
        {
            AFILIADO afiliado = new AFILIADO();
            afiliado.RUT = rut;
            afiliado.VERIFICADOR = digitoVerificador;
            afiliado.PLAN = plan;
            using (var entities = new SeguroEntities())
            {
                entities.AFILIADO.Add(afiliado);
                entities.SaveChangesAsync();
                return afiliado;
            }
            
        }

        private BENEFICIO crearBeneficio(decimal porcentaje, int limite, int idPrestacion)
        {
            BENEFICIO beneficio = new BENEFICIO();
            beneficio.PORCENTAJE = porcentaje;
            beneficio.LIMITE_DINERO = limite;
            beneficio.ID_PRESTACION = idPrestacion;
            using (var entities = new SeguroEntities())
            {
                entities.BENEFICIO.Add(beneficio);
                entities.SaveChangesAsync();
                return beneficio;
            }
        }
    }
}
