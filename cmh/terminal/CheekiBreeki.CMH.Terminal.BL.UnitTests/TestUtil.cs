using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheekiBreeki.CMH.Terminal.BL;
using System.Windows.Forms;

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
        public void rutValidoTest()
        {
            // Caso 1: RUT válido
            int rut1 = 18861423;
            string dv1 = "k";

            Boolean res1 = Util.rutValido(rut1, dv1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(resultadoEsperado1, res1);

            // Caso 2: RUT inválido
            int rut2 = 18861423;
            string dv2 = "5";

            Boolean res2 = Util.rutValido(rut2, dv2);
            Boolean resultadoEsperado2 = false;
            Assert.AreEqual(resultadoEsperado2, res2);
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

        [TestMethod]
        public void validarTextBoxVaciosTest()
        {
            // Caso 1: TextBox con valores
            Form formulario1 = new Form();
            TextBox textbox1 = new TextBox();
            textbox1.Text = "algo";
            formulario1.Controls.Add(textbox1);

            Boolean res1 = Util.validarTextBoxVacios(formulario1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(resultadoEsperado1, res1);

            // Caso 2: TextBox vacío
            Form formulario2 = new Form();
            TextBox textbox2 = new TextBox();
            formulario2.Controls.Add(textbox2);

            Boolean res2 = Util.validarTextBoxVacios(formulario2);
            Boolean resultadoEsperado2 = false;
            Assert.AreEqual(resultadoEsperado2, res2);
        }

        
    }
}
