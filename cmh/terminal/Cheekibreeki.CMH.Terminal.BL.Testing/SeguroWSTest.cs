using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cheekibreeki.CMH.Seguro.BL;
using Cheekibreeki.CMH.Seguro.DAL;
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
            //crear tipo empresa
            T_EMPRESA tipoEmpresaPrivada = new T_EMPRESA();
            tipoEmpresaPrivada.NOMBRE = "Privada";
            T_EMPRESA tipoEmpresaPublica = new T_EMPRESA();
            tipoEmpresaPublica.NOMBRE = "Publica";
            
            
            
            //crear empresa
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
    }
}
