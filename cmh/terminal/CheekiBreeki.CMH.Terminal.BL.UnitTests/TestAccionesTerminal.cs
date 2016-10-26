using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheekiBreeki.CMH.Terminal.DAL;
using System.Linq;
namespace CheekiBreeki.CMH.Terminal.BL.UnitTests
{
    [TestClass]
    public class TestAccionesTerminal
    {
        #region Paciente
        [TestMethod]
        public void nuevoPacienteTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Caso 1: Paciente correcto
            PACIENTE paciente1 = new PACIENTE();

            paciente1.NOMBRES_PACIENTE = "Miku";
            paciente1.APELLIDOS_PACIENTE = "Hatsune";
            paciente1.RUT = 18861423;
            paciente1.DIGITO_VERIFICADOR = "K";
            paciente1.EMAIL_PACIENTE = "netflixtrucho1@gmail.com";
            paciente1.HASHED_PASS = "4231";
            CMHEntities entities = new CMHEntities();
            using (var context = entities)
            {
                var pac1 = from p in entities.PACIENTE
                       where p.RUT == paciente1.RUT
                       select p;
                if(pac1.Count<PACIENTE>() > 0)
                {
                    entities.PACIENTE.Remove(pac1.First<PACIENTE>());
                    entities.SaveChangesAsync();
                }
            }

            Boolean res1 = at.nuevoPaciente(paciente1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1, "Caso 1: debería ser correcto pero NO");
            //Assert.AreEqual(res1, resultadoEsperado1);

            // Caso 2: Paciente nulo
            PACIENTE paciente2 = null;

            Boolean res2 = at.nuevoPaciente(paciente2);
            Boolean resultadoEsperado2 = false;
            Assert.AreEqual(res2, resultadoEsperado2);

            // Caso 3: Nombre o apellido nulo
            PACIENTE paciente3 = new PACIENTE();
            paciente3.NOMBRES_PACIENTE = null;
            paciente3.APELLIDOS_PACIENTE = "";
            paciente3.RUT = 18861423;
            paciente3.DIGITO_VERIFICADOR = "K";
            paciente3.EMAIL_PACIENTE = "netflixtrucho1@gmail.com";
            paciente3.HASHED_PASS = "4231";

            Boolean res3 = at.nuevoPaciente(paciente3);
            Boolean resultadoEsperado3 = false;
            Assert.AreEqual(res3, resultadoEsperado3);

            // Caso 4: Email nulo
            PACIENTE paciente4 = new PACIENTE();
            paciente4.EMAIL_PACIENTE = "";
            paciente4.NOMBRES_PACIENTE = "Miku";
            paciente4.APELLIDOS_PACIENTE = "Hatsune";
            paciente4.RUT = 18861423;
            paciente4.DIGITO_VERIFICADOR = "K";
            paciente4.HASHED_PASS = "4231";

            Boolean res4 = at.nuevoPaciente(paciente4);
            Boolean resultadoEsperado4 = false;
            Assert.AreEqual(res4, resultadoEsperado4);

            // Caso 5: Rut nulo
            PACIENTE paciente5 = new PACIENTE();
            paciente5.NOMBRES_PACIENTE = "Miku";
            paciente5.APELLIDOS_PACIENTE = "Hatsune";
            paciente5.RUT = 0;
            paciente5.DIGITO_VERIFICADOR = "K";
            paciente5.EMAIL_PACIENTE = "netflixtrucho1@gmail.com";
            paciente5.HASHED_PASS = "4231";

            Boolean res5 = at.nuevoPaciente(paciente5);
            Boolean resultadoEsperado5 = false;
            Assert.AreEqual(res5, resultadoEsperado5);

            // Caso 6: RUT repetido
            PACIENTE paciente6 = new PACIENTE();
            paciente6.NOMBRES_PACIENTE = "Miku";
            paciente6.APELLIDOS_PACIENTE = "Hatsune";
            paciente6.RUT = 18861423;
            paciente6.DIGITO_VERIFICADOR = "K";
            paciente6.EMAIL_PACIENTE = "netflixtrucho1@gmail.com";
            paciente6.HASHED_PASS = "4231";

            Boolean res6 = at.nuevoPaciente(paciente6);
            Boolean resultadoEsperado6 = false;
            Assert.AreEqual(res6, resultadoEsperado6);
        }

        [TestMethod]
        public void buscarPacienteTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            
            // Caso 1: Paciente existente
            int rut1 = 18861423;
            string dv1 = "K";
            PACIENTE res1 = at.buscarPaciente(rut1, dv1);
            Object resultadoNoEsperado1 = null;
            Assert.AreNotEqual(res1, resultadoNoEsperado1);

            // Caso 2: Paciente no existente
            int rut2 = 999999;
            string dv2 = "K";
            PACIENTE res2 = at.buscarPaciente(rut2, dv2);
            Object resultadoEsperado2 = null;
            Assert.AreEqual(res2, resultadoEsperado2);
        }

        [TestMethod]
        public void actualizarPacienteTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Caso 1: Paciente correcto
            int rut1 = 18861423;
            string dv1 = "K";
            PACIENTE paciente1 = at.buscarPaciente(rut1, dv1);

            paciente1.NOMBRES_PACIENTE = "Yuzuki";
            paciente1.APELLIDOS_PACIENTE = "Yukari";

            Boolean res1 = at.actualizarPaciente(paciente1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1);

            // Caso 2: Paciente nulo
            PACIENTE paciente2 = null;

            Boolean res2 = at.actualizarPaciente(paciente2);
            Boolean resultadoEsperado2 = false;
            Assert.AreEqual(res2, resultadoEsperado2);

            // Caso 3: Nombre o apellido nulo
            PACIENTE paciente3 = new PACIENTE();
            paciente3.NOMBRES_PACIENTE = null;
            paciente3.APELLIDOS_PACIENTE = "";
            paciente3.RUT = 18861423;
            paciente3.DIGITO_VERIFICADOR = "K";
            paciente3.EMAIL_PACIENTE = "netflixtrucho1@gmail.com";
            paciente3.HASHED_PASS = "4231";

            Boolean res3 = at.actualizarPaciente(paciente3);
            Boolean resultadoEsperado3 = false;
            Assert.AreEqual(res3, resultadoEsperado3);

            // Caso 4: Email nulo
            PACIENTE paciente4 = new PACIENTE();
            paciente4.EMAIL_PACIENTE = "";
            paciente4.NOMBRES_PACIENTE = "Miku";
            paciente4.APELLIDOS_PACIENTE = "Hatsune";
            paciente4.RUT = 18861423;
            paciente4.DIGITO_VERIFICADOR = "K";
            paciente4.HASHED_PASS = "4231";

            Boolean res4 = at.actualizarPaciente(paciente4);
            Boolean resultadoEsperado4 = false;
            Assert.AreEqual(res4, resultadoEsperado4);

            // Caso 5: Rut nulo
            PACIENTE paciente5 = new PACIENTE();
            paciente5.NOMBRES_PACIENTE = "Miku";
            paciente5.APELLIDOS_PACIENTE = "Hatsune";
            paciente5.RUT = 0;
            paciente5.DIGITO_VERIFICADOR = "K";
            paciente5.EMAIL_PACIENTE = "netflixtrucho1@gmail.com";
            paciente5.HASHED_PASS = "4231";

            Boolean res5 = at.actualizarPaciente(paciente5);
            Boolean resultadoEsperado5 = false;
            Assert.AreEqual(res5, resultadoEsperado5);
        }

        [TestMethod]
        public void borrarPacienteTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Caso 1: Paciente existe
            int rut1 = 18861423;
            string dv1 = "K";
            Object res1 = at.buscarPaciente(rut1, dv1);
            if (Util.isObjetoNulo(res1))
                Assert.Fail("Paciente no existe");
            PACIENTE paciente1 = (PACIENTE)res1;
            at.borrarPaciente(paciente1);
            Object resultadoEsperado1 = null;
            Assert.AreEqual(at.buscarPaciente(rut1, dv1), resultadoEsperado1);
        }
        #endregion

        #region Personal
        [TestMethod]
        public void nuevoPersonalTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Caso 1: Personal correcto
            PERSONAL personal1 = new PERSONAL();
            FUNCIONARIO funcionario1 = new FUNCIONARIO();

            personal1.NOMBRES = "Moka";
            personal1.APELLIDOS = "Akashiya";
            personal1.REMUNERACION = 850000;
            personal1.PORCENT_DESCUENTO = 7;
            personal1.HASHED_PASS = "4231";
            personal1.RUT = 12345678;
            personal1.VERIFICADOR = "K";
            CMHEntities entities = new CMHEntities();
            using (var context = entities)
            {
                var pers = from p in entities.PERSONAL
                           where p.RUT == personal1.RUT
                           select p;
                if (pers.Count<PERSONAL>() > 0)
                {
                    entities.PERSONAL.Remove(pers.First<PERSONAL>());
                    entities.SaveChangesAsync();
                }
            }

            Boolean res1 = at.nuevoPersonal(personal1);
            
            funcionario1.ID_CARGO_FUNCI = 1;
            funcionario1.ID_PERSONAL = personal1.ID_PERSONAL;

            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1);

           
            // Caso 2: Personal nulo
            PERSONAL personal2 = null;

            Boolean res2 = at.nuevoPersonal(personal2);
            Boolean resultadoEsperado2 = false;
            Assert.AreEqual(res2, resultadoEsperado2);

            // Caso 3: Nombre o apellido nulo
            PERSONAL personal3 = new PERSONAL();

            personal3.NOMBRES = null;
            personal3.APELLIDOS = "";
            personal3.REMUNERACION = 850000;
            personal3.PORCENT_DESCUENTO = 7;
            personal3.HASHED_PASS = "4231";

            Boolean res3 = at.nuevoPersonal(personal3);
            Boolean resultadoEsperado3 = false;
            Assert.AreEqual(res3, resultadoEsperado3);

            // Caso 4: RUT vacío
            PERSONAL personal4 = new PERSONAL();

            personal4.NOMBRES = "Moka";
            personal4.APELLIDOS = "Akashiya";
            personal4.REMUNERACION = 850000;
            personal4.PORCENT_DESCUENTO = 7;
            personal4.HASHED_PASS = "4231";
            personal4.VERIFICADOR = string.Empty;

            Boolean res4 = at.nuevoPersonal(personal4);
            Boolean resultadoEsperado4 = false;
            Assert.AreEqual(res4, resultadoEsperado4);

            // Caso 5: RUT repetido
            PERSONAL personal5 = new PERSONAL();

            personal5.NOMBRES = "Moka";
            personal5.APELLIDOS = "Akashiya";
            personal5.REMUNERACION = 850000;
            personal5.PORCENT_DESCUENTO = 7;
            personal5.HASHED_PASS = "4231";
            personal5.RUT = 12345678;
            personal5.VERIFICADOR = "K";

            Boolean res5 = at.nuevoPersonal(personal5);
            Boolean resultadoEsperado5 = false;
            Assert.AreEqual(res5, resultadoEsperado5);
        }

        [TestMethod]
        public void buscarPersonalTest()
        {
            AccionesTerminal at = new AccionesTerminal();

            // Caso 1: Personal existente
            int rut1 = 12345678;
            string dv1 = "K";
            PERSONAL res1 = at.buscarPersonal(rut1, dv1);
            Object resultadoNoEsperado1 = null;
            Assert.AreNotEqual(res1, resultadoNoEsperado1);

            // Caso 2: Personal no existente
            int rut2 = 999999;
            string dv2 = "K";
            PERSONAL res2 = at.buscarPersonal(rut2, dv2);
            Object resultadoEsperado2 = null;
            Assert.AreEqual(res2, resultadoEsperado2);
        }

        [TestMethod]
        public void actualizarPersonalTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Caso 1: Personal correcto
            int rut1 = 12345678;
            string dv1 = "K";
            PERSONAL personal1 = at.buscarPersonal(rut1, dv1);

            personal1.NOMBRES = "Mizore";
            personal1.APELLIDOS = "Shirayuki";
            personal1.REMUNERACION = 900000;
            personal1.PORCENT_DESCUENTO = 8;
            personal1.HASHED_PASS = "4231";

            Boolean res1 = at.actualizarPersonal(personal1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1);

            // Caso 2: Personal nulo
            PERSONAL personal2 = null;

            Boolean res2 = at.actualizarPersonal(personal2);
            Boolean resultadoEsperado2 = false;
            Assert.AreEqual(res2, resultadoEsperado2);

            // Caso 3: Nombre o apellido nulo
            PERSONAL personal3 = at.buscarPersonal(rut1, dv1);

            personal3.NOMBRES = null;
            personal3.APELLIDOS = "";
            personal3.REMUNERACION = 850000;
            personal3.PORCENT_DESCUENTO = 7;
            personal3.HASHED_PASS = "4231";

            Boolean res3 = at.actualizarPersonal(personal3);
            Boolean resultadoEsperado3 = false;
            Assert.AreEqual(res3, resultadoEsperado3);
        }

        [TestMethod]
        public void borrarPersonalTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            int rut1 = 12345678;
            string dv1 = "K";
            PERSONAL personal1 = at.buscarPersonal(rut1, dv1);

            // Caso 1: Personal no existe
            if (Util.isObjetoNulo(personal1))
                Assert.Fail("Personal no existe");

            // Caso 2: Personal existe
            at.borrarPersonal(personal1);
            Object resultadoEsperado1 = null;
            Assert.AreEqual(at.buscarPersonal(rut1, dv1), resultadoEsperado1);
        }
        #endregion

        #region Prestación médica

        [TestMethod]
        public void nuevaPrestacionMedicaTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Caso 1: Prestación correcto
            PRESTACION prestacion1 = new PRESTACION();
            prestacion1.NOM_PRESTACION = "Prestación test";
            prestacion1.PRECIO_PRESTACION = 100;
            prestacion1.CODIGO_PRESTACION = "PR01";
            prestacion1.ID_TIPO_PRESTACION = 1;

            Boolean res1 = at.nuevaPrestacionMedica(prestacion1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1);

            // Caso 2: Nombre vacío
            PRESTACION prestacion2 = new PRESTACION();
            prestacion2.NOM_PRESTACION = null;
            prestacion2.PRECIO_PRESTACION = 100;
            prestacion2.CODIGO_PRESTACION = "PR01";
            prestacion2.ID_TIPO_PRESTACION = 1;

            Boolean res2 = at.nuevaPrestacionMedica(prestacion2);
            Boolean resultadoEsperado2 = false;
            Assert.AreEqual(res2, resultadoEsperado2);

            // Caso 3: Código vacío
            PRESTACION prestacion3 = new PRESTACION();
            prestacion3.NOM_PRESTACION = "Prestación test";
            prestacion3.PRECIO_PRESTACION = 100;
            prestacion3.ID_TIPO_PRESTACION = 1;

            Boolean res3 = at.nuevaPrestacionMedica(prestacion3);
            Boolean resultadoEsperado3 = false;
            Assert.AreEqual(res3, resultadoEsperado3);

            // Caso 4: Tipo vacío
            PRESTACION prestacion4 = new PRESTACION();
            prestacion1.NOM_PRESTACION = "Prestación test";
            prestacion4.PRECIO_PRESTACION = 100;
            prestacion4.CODIGO_PRESTACION = "PR01";

            Boolean res4 = at.nuevaPrestacionMedica(prestacion4);
            Boolean resultadoEsperado4 = false;
            Assert.AreEqual(res4, resultadoEsperado4);

            // Caso 5: Prestación ya ingresada
            PRESTACION prestacion5 = new PRESTACION();
            prestacion5.NOM_PRESTACION = "Prestación test";
            prestacion5.PRECIO_PRESTACION = 100;
            prestacion5.CODIGO_PRESTACION = "PR01";
            prestacion5.ID_TIPO_PRESTACION = 1;

            Boolean res5 = at.nuevaPrestacionMedica(prestacion5);
            Boolean resultadoEsperado5 = false;
            Assert.AreEqual(res5, resultadoEsperado5);

            // Caso 6: Prestación no existe
            PRESTACION prestacion6 = null;

            Boolean res6 = at.nuevaPrestacionMedica(prestacion6);
            Boolean resultadoEsperado6 = false;
            Assert.AreEqual(res6, resultadoEsperado6);
        }

        [TestMethod]
        public void buscarPrestacionMedicaTest()
        {
            AccionesTerminal at = new AccionesTerminal();

            // Caso 1: Personal existente
            string id1 = "PR01";
            PRESTACION res1 = at.buscarPrestacionMedica(id1);
            Object resultadoNoEsperado1 = null;
            Assert.AreNotEqual(res1, resultadoNoEsperado1);

            // Caso 2: Personal no existente
            string id2 = "PR00";
            PRESTACION res2 = at.buscarPrestacionMedica(id2);
            Object resultadoEsperado2 = null;
            Assert.AreEqual(res2, resultadoEsperado2);
        }

        [TestMethod]
        public void actualizarPrestacionMedicaTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Caso 1: Paciente correcto
            string codigo = "PR01";
            PRESTACION prestacion1 = at.buscarPrestacionMedica(codigo);

            prestacion1.NOM_PRESTACION = "Prestación actualizada";
            prestacion1.PRECIO_PRESTACION = 200;
            prestacion1.CODIGO_PRESTACION = "PR01";
            prestacion1.ID_TIPO_PRESTACION = 1;

            Boolean res1 = at.actualizarPrestacionesMedicas(prestacion1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1);

            // Caso 2: Nombre vacío
            PRESTACION prestacion2 = at.buscarPrestacionMedica(codigo);
            prestacion2.NOM_PRESTACION = string.Empty;
            prestacion2.PRECIO_PRESTACION = 100;
            prestacion2.CODIGO_PRESTACION = "PR01";
            prestacion2.ID_TIPO_PRESTACION = 1;

            Boolean res2 = at.actualizarPrestacionesMedicas(prestacion2);
            Boolean resultadoEsperado2 = false;
            Assert.AreEqual(res2, resultadoEsperado2);

            // Caso 3: Código vacío
            PRESTACION prestacion3 = at.buscarPrestacionMedica(codigo);
            prestacion3.NOM_PRESTACION = "Prestación test";
            prestacion3.PRECIO_PRESTACION = 300;
            prestacion3.ID_TIPO_PRESTACION = 1;
            prestacion3.CODIGO_PRESTACION = null;

            Boolean res3 = at.actualizarPrestacionesMedicas(prestacion3);
            Boolean resultadoEsperado3 = false;
            Assert.AreEqual(res3, resultadoEsperado3);

            // Caso 4: Tipo vacío
            PRESTACION prestacion4 = at.buscarPrestacionMedica(codigo);
            prestacion4.NOM_PRESTACION = "Prestación test";
            prestacion4.PRECIO_PRESTACION = 100;
            prestacion4.CODIGO_PRESTACION = "PR01";
            prestacion4.ID_TIPO_PRESTACION = null;

            Boolean res4 = at.actualizarPrestacionesMedicas(prestacion4);
            Boolean resultadoEsperado4 = false;
            Assert.AreEqual(res4, resultadoEsperado4);

            // Caso 5: Prestación no existe
            PRESTACION prestacion5 = null;

            Boolean res5 = at.actualizarPrestacionesMedicas(prestacion5);
            Boolean resultadoEsperado5 = false;
            Assert.AreEqual(res5, resultadoEsperado5);
        }
        
        [TestMethod]
        public void borrarPrestacionMedicaTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            string codigo = "PR01";
            PRESTACION res1 = at.buscarPrestacionMedica(codigo);
            // Caso 1: Prestación no existe
            if (Util.isObjetoNulo(res1))
                Assert.Fail("Prestación no existe");
            // Caso 2: Prestación existe
            at.borrarPrestacionMedica(res1);
            Object resultadoEsperado1 = null;
            Assert.AreEqual(at.buscarPrestacionMedica(codigo), resultadoEsperado1);
        }
        #endregion

        #region Equipo
        [TestMethod]
        public void nuevoEquipoTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Caso 1: Equipo correcto
            TIPO_EQUIPO equipo1 = new TIPO_EQUIPO();
            equipo1.NOMBRE_TIPO_EQUIPO = "Test equipo";

            Boolean res1 = at.nuevoEquipo(equipo1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1);

            // Caso 2: Equipo nulo
            TIPO_EQUIPO equipo2 = new TIPO_EQUIPO();

            Boolean res2 = at.nuevoEquipo(equipo2);
            Boolean resultadoEsperado2 = false;
            Assert.AreEqual(res2, resultadoEsperado2);

            // Caso 3: Nombre nulo
            TIPO_EQUIPO equipo3 = new TIPO_EQUIPO();
            equipo3.NOMBRE_TIPO_EQUIPO = string.Empty;

            Boolean res3 = at.nuevoEquipo(equipo3);
            Boolean resultadoEsperado3 = false;
            Assert.AreEqual(res3, resultadoEsperado3);

            // Caso 4: Equipo repetido
            TIPO_EQUIPO equipo4 = new TIPO_EQUIPO();
            equipo4.NOMBRE_TIPO_EQUIPO = "Test equipo";

            Boolean res4 = at.nuevoEquipo(equipo4);
            Boolean resultadoEsperado4 = false;
            Assert.AreEqual(res4, resultadoEsperado4);
        }

        [TestMethod]
        public void buscarEquipoTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Caso 1: Equipo correcto
            string nombre1 = "Test equipo";
            TIPO_EQUIPO res1 = at.buscarEquipo(nombre1);

            Object resultadoNoEsperado1 = null;
            Assert.AreNotEqual(res1, resultadoNoEsperado1);

            // Caso 2: Equipo no existente
            string nombre2 = "Test equipo no existente";

            TIPO_EQUIPO res2 = at.buscarEquipo(nombre2);
            Object resultadoEsperado2 = null;
            Assert.AreEqual(res2, resultadoEsperado2);
        }

        [TestMethod]
        public void actualizarEquipoCantidadTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Caso 1: Equipo correcto
            string nombre1 = "Test equipo";
            int cantidad1 = 10;
            Boolean res1 = at.actualizarEquipoCantidad(nombre1, cantidad1);

            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1);

            // Caso 2: Equipo no existente
            string nombre2 = "Test equipo no existente";
            int cantidad2 = 10;

            Boolean res2 = at.actualizarEquipoCantidad(nombre2, cantidad2);
            Object resultadoEsperado2 = false;
            Assert.AreEqual(res2, resultadoEsperado2);
        }

        [TestMethod]
        public void borrarEquipoTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Caso 1: Equipo correcto
            string nombre = "Test equipo";

            TIPO_EQUIPO res1 = at.buscarEquipo(nombre);
            if (Util.isObjetoNulo(res1))
                Assert.Fail("Equipo no existe");

            at.borrarEquipo(res1);
            Object resultadoEsperado1 = null;
            Assert.AreEqual(at.buscarEquipo(nombre), resultadoEsperado1);
        }
        #endregion

        #region Funcionario
        [TestMethod]
        public void nuevoFuncionarioTest()
        {
            AccionesTerminal at = new AccionesTerminal();

            // Caso 1: Funcionario correcto
            FUNCIONARIO funcionario1 = new FUNCIONARIO();
            int rutPersonal1 = 12345678;
            string dvPersonal1 = "K";
            CMHEntities entities = new CMHEntities();
            using (var context = entities)
            {
                var pers = from p in entities.PERSONAL
                           where p.RUT == rutPersonal1
                           select p;
                if(pers.Count<PERSONAL>() == 0)
                {
                    PERSONAL personal = new PERSONAL();
                    personal.RUT = rutPersonal1;
                    personal.VERIFICADOR = dvPersonal1;
                    personal.NOMBRES = "Testtest";
                    personal.APELLIDOS = "Testtest";
                    entities.PERSONAL.Add(personal);
                    entities.SaveChangesAsync();
                }else
                {
                    entities.PERSONAL.Remove(pers.First<PERSONAL>());
                    entities.SaveChangesAsync();
                }
            }
            PERSONAL personal1 = at.buscarPersonal(rutPersonal1, dvPersonal1);

            funcionario1.ID_PERSONAL = personal1.ID_PERSONAL;
            funcionario1.ID_CARGO_FUNCI = 1;

            Boolean res1 = at.nuevoFuncionario(funcionario1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1);
            
            // Caso 2: Funcionario nulo
            FUNCIONARIO funcionario2 = new FUNCIONARIO();

            Boolean res2 = at.nuevoFuncionario(funcionario2);
            Boolean resultadoEsperado2 = false;
            Assert.AreEqual(res2, resultadoEsperado2);

            // Caso 3: Cargo no existe
            FUNCIONARIO funcionario3 = new FUNCIONARIO();
            funcionario3.ID_CARGO_FUNCI = 0;

            Boolean res3 = at.nuevoFuncionario(funcionario3);
            Boolean resultadoEsperado3 = false;
            Assert.AreEqual(res3, resultadoEsperado3);

            // Caso 4: Funcionario repetido
            FUNCIONARIO funcionario4 = new FUNCIONARIO();
            int rutPersonal4 = 12345678;
            string dvPersonal4 = "K";
            funcionario1.ID_PERSONAL = at.buscarPersonal(rutPersonal4, dvPersonal4).ID_PERSONAL;
            funcionario1.ID_CARGO_FUNCI = 1;

            Boolean res4 = at.nuevoFuncionario(funcionario4);
            Boolean resultadoEsperado4 = false;
            Assert.AreEqual(res4, resultadoEsperado4);
        }

        [TestMethod]
        public void buscarFuncionarioTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Caso 1: Funcionario correcto
            CARGO cargo = new CARGO();
            cargo.NOMBRE_CARGO = "Testcargo";
            PERSONAL personal = new PERSONAL();
            personal.RUT = 123;
            personal.VERIFICADOR = "a";
            personal.NOMBRES = "Test";
            personal.APELLIDOS = "TEST";
            CMHEntities entities = new CMHEntities();
            entities.PERSONAL.Add(personal);
            entities.CARGO.Add(cargo);
            entities.SaveChangesAsync();
            int idCargo1 = (from c in entities.CARGO
                            where c.NOMBRE_CARGO == cargo.NOMBRE_CARGO
                            select c).First<CARGO>().ID_CARGO_FUNCI;
            int idPersonal1 = (from p in entities.PERSONAL
                                where p.RUT == personal.RUT
                               select p).First<PERSONAL>().ID_PERSONAL;
            FUNCIONARIO funcionario = new FUNCIONARIO();
            funcionario.ID_CARGO_FUNCI = idCargo1;
            funcionario.ID_PERSONAL = idPersonal1;
            entities.FUNCIONARIO.Add(funcionario);
            entities.SaveChangesAsync();
            FUNCIONARIO res1 = at.buscarFuncionario(idCargo1, idPersonal1);

            Object resultadoNoEsperado1 = null;
            Assert.AreNotEqual(res1, resultadoNoEsperado1);

            // Caso 2: Funcionario no existente
            int cargo2 = 0;
            int personal2 = 0;

            FUNCIONARIO res2 = at.buscarFuncionario(cargo2, personal2);
            Object resultadoEsperado2 = null;
            Assert.AreEqual(res2, resultadoEsperado2);
        }

        [TestMethod]
        public void actualizarFuncionarioTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Caso 1: Funcionario correcto
            //instanciar persistencia
            CMHEntities entities = new CMHEntities();
            //buscar personal
            PERSONAL personal = (from p in entities.PERSONAL select p).First<PERSONAL>();
            //buscar cargo
            CARGO cargo = (from c in entities.CARGO select c).First<CARGO>();
            //crear funcionario
            FUNCIONARIO funcionario = new FUNCIONARIO();
            funcionario.ID_CARGO_FUNCI = cargo.ID_CARGO_FUNCI;
            funcionario.ID_PERSONAL = personal.ID_PERSONAL;
            //persistir funcionario
            entities.FUNCIONARIO.Add(funcionario);
            entities.SaveChangesAsync();

            FUNCIONARIO funcionario1 = at.buscarFuncionario(cargo.ID_CARGO_FUNCI, personal.ID_PERSONAL);
            Boolean res1 = at.actualizarFuncionario(funcionario1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1);

            // Caso 2: Funcionario nulo
            FUNCIONARIO funcionario2 = at.buscarFuncionario(0, 0);

            Boolean res2 = at.nuevoFuncionario(funcionario2);
            Boolean resultadoEsperado2 = false;
            Assert.AreEqual(res2, resultadoEsperado2);

            // Caso 3: Cargo no existe
            FUNCIONARIO funcionario3 = new FUNCIONARIO();
            funcionario3.ID_CARGO_FUNCI = 0;

            Boolean res3 = at.actualizarFuncionario(funcionario3);
            Boolean resultadoEsperado3 = false;
            Assert.AreEqual(res3, resultadoEsperado3);
        }

        [TestMethod]
        public void borrarFuncionarioTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Caso 1: Funcionario correcto
            //Instanciar controlador persistencia
            CMHEntities entities = new CMHEntities();
            //obtener un personal existente
            PERSONAL personal = (from p in entities.PERSONAL select p).First<PERSONAL>();
            //obtener un cargo existente
            CARGO cargo = (from c in entities.CARGO select c).First<CARGO>();
            //crear un nuevo funcionario
            FUNCIONARIO funcionario = new FUNCIONARIO();
            funcionario.ID_PERSONAL = personal.ID_PERSONAL;
            funcionario.ID_CARGO_FUNCI = cargo.ID_CARGO_FUNCI;
            //persistir nuevo funcionario
            entities.FUNCIONARIO.Add(funcionario);
            entities.SaveChangesAsync();
            int idPersonal = personal.ID_PERSONAL;
            int idCargo = cargo.ID_CARGO_FUNCI;
            FUNCIONARIO funcionario1 = at.buscarFuncionario(idCargo, idPersonal);
            if (Util.isObjetoNulo(funcionario1))
                Assert.Fail("Funcionario no existe");

            bool resultado = at.borrarFuncionario(funcionario1);
            bool resultadoEsperado1 = true;
            Assert.AreEqual(resultado, resultadoEsperado1);
        }
        #endregion


        #region IngresoPaciente
        [TestMethod]
        public void ingresoPacienteTest()
        {
            AccionesTerminal at = new AccionesTerminal();

            //Caso 1: Ingreso paciente correcto
            //Caso 2: Paciente no existente
            //Caso 3: Atención no existente
            //Caso 4: Atención no vigente
        }
        #endregion

        #region Revisar agenda diaria
        [TestMethod]
        public void revisarAgendaDiariaTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            //Caso 1: Agenda correcta
            //Atencion_agen, paciente, prestacion(tipo_prestacion), estado_atencion, pers_medico(personal,especialidad), bloque(dia_sem)
            //Caso 2: 
        }
        #endregion

        #region Registrar pago
        [TestMethod]
        public void registrarPagoTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            //Caso 1: Pago correcto
            //Bono,Caja,Devolucion,Atencion_agen
        }
        #endregion 

        #region Abrir Caja
        [TestMethod]
        public void abrirCajaTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            CMHEntities conexionBD = new CMHEntities();
            //Caso 1: Caja correcta
                //Instanciar y Crear Cargo
            CARGO cargo1 = new CARGO();
            cargo1.NOMBRE_CARGO = "Operador";
            conexionBD.CARGO.Add(cargo1);
            conexionBD.SaveChangesAsync();
            Console.WriteLine("ID CARGO: " + cargo1.ID_CARGO_FUNCI);
                //Instanciar y Crear Personal
            PERSONAL personal1 = new PERSONAL();
            personal1.NOMBRES = "Gonzalo";
            personal1.APELLIDOS = "Lopez";
            personal1.REMUNERACION = 1000000;
            personal1.HASHED_PASS = "QWERTY1";
            personal1.PORCENT_DESCUENTO = 50;
            personal1.RUT = 12345678;
            personal1.VERIFICADOR = "K";
            personal1.EMAIL = "asdf@gmail.com";
            personal1.ACTIVO = true;
            conexionBD.PERSONAL.Add(personal1);
            conexionBD.SaveChangesAsync();
            Console.WriteLine("ID PERSONAL: " + personal1.ID_PERSONAL);
                //Instanciar y Crear Funcionario
            FUNCIONARIO funcionario1 = new FUNCIONARIO();
            funcionario1.ID_CARGO_FUNCI = cargo1.ID_CARGO_FUNCI;
            funcionario1.ID_PERSONAL = personal1.ID_PERSONAL;
            conexionBD.FUNCIONARIO.Add(funcionario1);
            conexionBD.SaveChangesAsync();
            Console.WriteLine("ID FUNCIONARIO: " + funcionario1.ID_FUNCIONARIO);
                //Instanciar y Crear Caja
            CAJA caja1 = new CAJA();
            caja1.FECHOR_APERTURA = DateTime.Today;
            caja1.ID_FUNCIONARIO = funcionario1.ID_FUNCIONARIO;
            conexionBD.CAJA.Add(caja1);
            conexionBD.SaveChangesAsync();
            Console.WriteLine("ID CAJA: " + caja1.ID_CAJA);

            Boolean res1 = at.abrirCaja(caja1, funcionario1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1, "Caso 1: debería ser correcto");

            //Caso 2: No existe funcionario
                //Funcionario (no existe)
            int id_cargo = -56;
            int id_personal = -47;
            FUNCIONARIO res2 = at.buscarFuncionario(id_cargo, id_personal);
            Object resultadoNoEsperado2 = null;
            Assert.AreEqual(res2, resultadoNoEsperado2, "Caso 2: debería ser correcto");

        }
        #endregion 

        #region Cerrar caja
        [TestMethod]
        public void cerrarCajaTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            CAJA cajaBuscada = new CAJA();
            using (var conexionBD = new CMHEntities())
            {
                //Caso 1: Caja cierre correcta
                //Instanciar y crear Cargo
                CARGO cargo1 = new CARGO();
                cargo1.NOMBRE_CARGO = "Operador";
                conexionBD.CARGO.Add(cargo1);
                conexionBD.SaveChangesAsync();
                Console.WriteLine("ID CARGO: " + cargo1.ID_CARGO_FUNCI);
                //Instanciar y crear personal
                PERSONAL personal1 = new PERSONAL();
                personal1.NOMBRES = "Gonzalo";
                personal1.APELLIDOS = "Lopez";
                personal1.REMUNERACION = 1000000;
                personal1.HASHED_PASS = "QWERTY1";
                personal1.PORCENT_DESCUENTO = 50;
                personal1.RUT = 12345678;
                personal1.VERIFICADOR = "K";
                personal1.EMAIL = "asdf@gmail.com";
                personal1.ACTIVO = true;
                conexionBD.PERSONAL.Add(personal1);
                conexionBD.SaveChangesAsync();
                Console.WriteLine("ID PERSONAL: " + personal1.ID_PERSONAL);
                //Instanciar y crear funcionario
                FUNCIONARIO funcionario1 = new FUNCIONARIO();
                funcionario1.ID_CARGO_FUNCI = cargo1.ID_CARGO_FUNCI;
                funcionario1.ID_PERSONAL = personal1.ID_PERSONAL;
                conexionBD.FUNCIONARIO.Add(funcionario1);
                conexionBD.SaveChangesAsync();
                Console.WriteLine("ID FUNCIONARIO: " + funcionario1.ID_FUNCIONARIO);
                //Instanciar y crear caja
                CAJA caja1 = new CAJA();
                caja1.FECHOR_APERTURA = DateTime.Today;
                caja1.ID_FUNCIONARIO = funcionario1.ID_FUNCIONARIO;
                conexionBD.CAJA.Add(caja1);
                conexionBD.SaveChangesAsync();
                Console.WriteLine("ID CAJA: " + caja1.ID_CAJA);
                //Modificar caja (Agregar Fechor termino)

                cajaBuscada.ID_CAJA = caja1.ID_CAJA;
            }
            cajaBuscada = at.buscarCaja(cajaBuscada.ID_CAJA);
            cajaBuscada.FECHOR_CIERRE = DateTime.Today;
            cajaBuscada.FECHOR_CIERRE = cajaBuscada.FECHOR_CIERRE.Value.AddDays(1);

            Boolean res1 = at.cerrarCaja(cajaBuscada);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1);
            
            //Caso 2: Caja no existe

            int id_caja = -56;

            CAJA res2 = at.buscarCaja(id_caja);
            Object resultadoNoEsperado2 = null;
            Assert.AreEqual(res2, resultadoNoEsperado2);

        }
        #endregion 



    }
}
