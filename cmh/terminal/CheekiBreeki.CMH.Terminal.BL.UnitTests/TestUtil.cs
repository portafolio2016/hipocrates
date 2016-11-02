using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheekiBreeki.CMH.Terminal.BL;

namespace CheekiBreeki.CMH.Terminal.BL.UnitTests
{
    [TestClass]
    public class TestUtil
    {
        [TestMethod]
        public void isObjetoNuloTest()
        {
            // Caso 1: objeto es nulo
            String caso1 = null;
            Boolean res1 = Util.isObjetoNulo(caso1);
            Assert.AreEqual(res1, true);

            // Caso 2: objeto no es nulo
            String caso2 = "algo";
            Boolean res2 = Util.isObjetoNulo(caso2);
            Assert.AreEqual(res2, false);
        }

        [TestMethod]
        public void generarPassTest()
        {
            string pass = string.Empty;
            pass = Util.generarPass();
            Console.WriteLine(pass);

            Object resultadoNoEsperado1 = string.Empty;
            Assert.AreNotEqual(resultadoNoEsperado1, pass);
        }

        [TestMethod]
        public void hashMD5Test()
        {
            string pass = "cadena";
            string md5 = Util.hashMD5(pass);
            Console.WriteLine(md5);

            Object resultadoNoEsperado1 = pass;
            Assert.AreNotEqual(resultadoNoEsperado1, md5);
        }
    }
}
