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
            
            //Caso 1
            //Afiliado tiene un seguro privado, obtiene un 25% de descuento          
            
            //Caso 2
            //Afiliado tiene un seguro público, obtiene un 40% de descuento
            
            //Caso 3
            //Afiliado no tiene seguro
            
            //Caso 4: 
            //Afiliado no existe
            
            //Caso 5: prestación no existe
            
        }
        [TestMethod]
        public void obtenerAfiliadoTest()
        {
            using (var entities = new SeguroEntities())
            {
                //Caso1: obtener afiliado correctamente
                
                //Caso2: afiliado no existe
            }
        }



    }
}
