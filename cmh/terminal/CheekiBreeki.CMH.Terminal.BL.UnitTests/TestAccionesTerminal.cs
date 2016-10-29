using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheekiBreeki.CMH.Terminal.DAL;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace CheekiBreeki.CMH.Terminal.BL.UnitTests
{
    [TestClass]
    public class TestAccionesTerminal
    {
        #region Agregar atención agendada
        private ATENCION_AGEN agregarAtencionAgendada()
        {
            ORDEN_ANALISIS orden1 = new ORDEN_ANALISIS();
            PACIENTE paciente1 = new PACIENTE();
            TIPO_PRES tipopres1 = new TIPO_PRES();
            PRESTACION prestacion1 = new PRESTACION();
            ESTADO_ATEN estadoaten1 = new ESTADO_ATEN();
            ESTADO_ATEN estadoaten2 = new ESTADO_ATEN();
            ESPECIALIDAD especialidad1 = new ESPECIALIDAD();
            PERSONAL personal1 = new PERSONAL();
            CARGO cargo1 = new CARGO();
            FUNCIONARIO funcionario1 = new FUNCIONARIO();
            BLOQUE bloque1 = new BLOQUE();
            DIA_SEM dia1 = new DIA_SEM();
            PERS_MEDICO persmedico1 = new PERS_MEDICO();
            ATENCION_AGEN aten_agen1 = new ATENCION_AGEN();

            using (var context = new CMHEntities())
            {
                int idEspecialidad = 0, 
                    idPersonal = 0,
                    idPaciente = 0,
                    idPrestacion = 0,
                    idEstadoAtencion = 0,
                    idEstadoAtencion2 = 0,
                    idBloque = 0,
                    idCargo = 0;
                PACIENTE pacientePrevio = context.PACIENTE.Where(d => d.RUT == 18861423).FirstOrDefault();
                if(!Util.isObjetoNulo(pacientePrevio))
                {
                    idPaciente = pacientePrevio.ID_PACIENTE;
                    context.PACIENTE.Remove(pacientePrevio);
                }
                PERS_MEDICO presMedicoPrevia = context.PERS_MEDICO.Where(d => d.PERSONAL.RUT == 12345678 && d.ESPECIALIDAD.NOM_ESPECIALIDAD == "Oculista").FirstOrDefault();
                if (!Util.isObjetoNulo(presMedicoPrevia))
                {
                    foreach (ATENCION_AGEN aten in presMedicoPrevia.ATENCION_AGEN.ToList())
                    {
                        context.ATENCION_AGEN.Remove(aten);
                    }
                    context.PERS_MEDICO.Remove(presMedicoPrevia);
                }
                ESPECIALIDAD especialidadPrevia = context.ESPECIALIDAD.Where(d => d.NOM_ESPECIALIDAD == "Oculista").FirstOrDefault();
                if (!Util.isObjetoNulo(especialidadPrevia))
                {
                    idEspecialidad = especialidadPrevia.ID_ESPECIALIDAD;
                    context.ESPECIALIDAD.Remove(especialidadPrevia);
                }
                TIPO_PRES tipoPrestacionPrevia = context.TIPO_PRES.Where(d => d.NOM_TIPO_PREST == "Test").FirstOrDefault();
                if (!Util.isObjetoNulo(tipoPrestacionPrevia))
                    context.TIPO_PRES.Remove(tipoPrestacionPrevia);
                PRESTACION prestacionPrevia = context.PRESTACION.Where(d => d.CODIGO_PRESTACION == "A002").FirstOrDefault();
                if (!Util.isObjetoNulo(prestacionPrevia))
                {
                    idPrestacion = prestacionPrevia.ID_PRESTACION;
                    context.PRESTACION.Remove(prestacionPrevia);
                }
                ESTADO_ATEN estadoAtencionPrevia = context.ESTADO_ATEN.Where(d => d.NOM_ESTADO_ATEN == "Vigente").FirstOrDefault();
                if (!Util.isObjetoNulo(estadoAtencionPrevia))
                {
                    idEstadoAtencion = estadoAtencionPrevia.ID_ESTADO_ATEN;
                    context.ESTADO_ATEN.Remove(estadoAtencionPrevia);
                }
                ESTADO_ATEN estadoAtencionPrevia2 = context.ESTADO_ATEN.Where(d => d.NOM_ESTADO_ATEN == "En proceso").FirstOrDefault();
                if (!Util.isObjetoNulo(estadoAtencionPrevia2))
                {
                    idEstadoAtencion2 = estadoAtencionPrevia2.ID_ESTADO_ATEN;
                    context.ESTADO_ATEN.Remove(estadoAtencionPrevia2);
                }
                FUNCIONARIO funcionarioPrevia = context.FUNCIONARIO.Where(d => d.CARGO.NOMBRE_CARGO == "Cargo test" && d.PERSONAL.RUT == 12345678).FirstOrDefault();
                if (!Util.isObjetoNulo(funcionarioPrevia))
                {
                    foreach (CAJA cajita in funcionarioPrevia.CAJA.ToList())
                    {
                        cajita.PAGO.ToList().ForEach(o => context.PAGO.Remove(o));
                        context.CAJA.Remove(cajita);
                    }
                    context.FUNCIONARIO.Remove(funcionarioPrevia);
                }
                CARGO cargoPrevia = context.CARGO.Where(d => d.NOMBRE_CARGO == "Cargo test").FirstOrDefault();
                if (!Util.isObjetoNulo(cargoPrevia))
                {
                    idCargo = cargoPrevia.ID_CARGO_FUNCI;
                    context.CARGO.Remove(cargoPrevia);
                }
                PERSONAL personalPrevia = context.PERSONAL.Where(d => d.RUT == 12345678).FirstOrDefault();
                if (!Util.isObjetoNulo(personalPrevia))
                {
                    idPersonal = personalPrevia.ID_PERSONAL;
                    context.PERSONAL.Remove(personalPrevia);
                }
                BLOQUE bloquePrevia = context.BLOQUE.Where(d => d.NUM_BLOQUE == 5).FirstOrDefault();
                if (!Util.isObjetoNulo(bloquePrevia))
                {
                    idBloque = bloquePrevia.ID_BLOQUE;
                    context.BLOQUE.Remove(bloquePrevia);
                }
                DIA_SEM diaPrevia = context.DIA_SEM.Where(d => d.NOMBRE_IDA == "Lumamijunes").FirstOrDefault();
                if (!Util.isObjetoNulo(diaPrevia))
                    context.DIA_SEM.Remove(diaPrevia);
                ATENCION_AGEN atencionagenPrevia = context.ATENCION_AGEN.
                    Where(d => 
                          d.ID_PACIENTE == idPaciente && 
                          d.ID_PRESTACION == idPrestacion &&
                          (d.ID_ESTADO_ATEN == idEstadoAtencion || 
                          d.ID_ESTADO_ATEN == idEstadoAtencion2) && 
                          d.ID_PERS_ATIENDE == idPersonal 
                          && d.ID_BLOQUE == idBloque).FirstOrDefault();
                if (!Util.isObjetoNulo(atencionagenPrevia))
                {
                    context.ATENCION_AGEN.Remove(atencionagenPrevia);
                }
                context.SaveChangesAsync();

                paciente1.NOMBRES_PACIENTE = "Miku";
                paciente1.APELLIDOS_PACIENTE = "Hatsune";
                paciente1.RUT = 18861423;
                paciente1.DIGITO_VERIFICADOR = "K";
                paciente1.EMAIL_PACIENTE = "netflixtrucho1@gmail.com";
                paciente1.HASHED_PASS = "4231";
                paciente1.SEXO = "F";
                paciente1.FEC_NAC = DateTime.Today;
                context.PACIENTE.Add(paciente1);
                context.SaveChangesAsync();

                especialidad1.NOM_ESPECIALIDAD = "Oculista";
                context.ESPECIALIDAD.Add(especialidad1);
                context.SaveChangesAsync();

                tipopres1.NOM_TIPO_PREST = "Test";
                context.TIPO_PRES.Add(tipopres1);
                context.SaveChangesAsync();

                prestacion1.NOM_PRESTACION = "Chubi";
                prestacion1.PRECIO_PRESTACION = 50000;
                prestacion1.CODIGO_PRESTACION = "A002";
                prestacion1.ID_ESPECIALIDAD = especialidad1.ID_ESPECIALIDAD;
                prestacion1.ID_TIPO_PRESTACION = tipopres1.ID_TIPO_PRESTACION;
                context.PRESTACION.Add(prestacion1);
                context.SaveChangesAsync();

                estadoaten1.NOM_ESTADO_ATEN = "Vigente";
                context.ESTADO_ATEN.Add(estadoaten1);
                context.SaveChangesAsync();

                estadoaten2.NOM_ESTADO_ATEN = "En proceso";
                context.ESTADO_ATEN.Add(estadoaten2);
                context.SaveChangesAsync();

                personal1.NOMBRES = "Moka";
                personal1.APELLIDOS = "Akashiya";
                personal1.REMUNERACION = 850000;
                personal1.PORCENT_DESCUENTO = 7;
                personal1.HASHED_PASS = "4231";
                personal1.RUT = 12345678;
                personal1.VERIFICADOR = "K";
                context.PERSONAL.Add(personal1);
                context.SaveChangesAsync();

                cargo1.NOMBRE_CARGO = "Cargo test";
                context.CARGO.Add(cargo1);
                context.SaveChangesAsync();

                funcionario1.ID_CARGO_FUNCI = cargo1.ID_CARGO_FUNCI;
                funcionario1.ID_PERSONAL = personal1.ID_PERSONAL;
                context.FUNCIONARIO.Add(funcionario1);
                context.SaveChangesAsync();

                dia1.NOMBRE_IDA = "Lumamijunes";
                context.DIA_SEM.Add(dia1);
                context.SaveChangesAsync();

                bloque1.ID_DIA_SEM = dia1.ID_DIA;
                bloque1.NUM_BLOQUE = 5;
                bloque1.NUM_HORA_INI = 11;
                bloque1.NUM_MINU_INI = 22;
                bloque1.NUM_HORA_FIN = 16;
                bloque1.NUM_MINU_FIN = 45;
                context.BLOQUE.Add(bloque1);
                context.SaveChangesAsync();

                persmedico1.ID_ESPECIALIDAD = especialidad1.ID_ESPECIALIDAD;
                persmedico1.ID_PERSONAL = personal1.ID_PERSONAL;
                context.PERS_MEDICO.Add(persmedico1);
                context.SaveChangesAsync();

                aten_agen1.FECHOR = DateTime.Today;
                aten_agen1.OBSERVACIONES = "Observacion";
                aten_agen1.ID_PACIENTE = paciente1.ID_PACIENTE;
                aten_agen1.ID_ESTADO_ATEN = estadoaten1.ID_ESTADO_ATEN;
                aten_agen1.ID_PRESTACION = prestacion1.ID_PRESTACION;
                aten_agen1.ID_BLOQUE = bloque1.ID_BLOQUE;
                aten_agen1.ID_PERS_ATIENDE = persmedico1.ID_PERSONAL_MEDICO;

                context.ATENCION_AGEN.Add(aten_agen1);
                context.SaveChangesAsync();
                return aten_agen1;
            }
        }
        #endregion

        #region Ingresar paciente
        [TestMethod]
        public void ingresarPacienteTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Caso 1: Ingreso correcto
            ATENCION_AGEN atencion1 = agregarAtencionAgendada();
            Boolean res1 = at.ingresarPaciente(atencion1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(resultadoEsperado1, res1);

            // Caso 2: Estado incorrecto
            ATENCION_AGEN atencion2;
            using (var context = new CMHEntities())
            {
                atencion2 = agregarAtencionAgendada();
                atencion2 = context.ATENCION_AGEN.Find(atencion2.ID_ATENCION_AGEN);
                atencion2.ID_ESTADO_ATEN = context.ESTADO_ATEN.Where(d => d.NOM_ESTADO_ATEN == "En proceso").FirstOrDefault().ID_ESTADO_ATEN;
                context.SaveChangesAsync();
            }
            Boolean res2 = at.ingresarPaciente(atencion2);
            Boolean resultadoEsperado2 = false;
            Assert.AreEqual(resultadoEsperado2, res2);

            // Caso 3: Atención no existe
            ATENCION_AGEN atencion3 = new ATENCION_AGEN();
            atencion3.ID_ATENCION_AGEN = 0;
            Boolean res3 = at.ingresarPaciente(atencion3);
            Boolean resultadoEsperado3 = false;
            Assert.AreEqual(resultadoEsperado3, res3);
        }
        #endregion

        #region Registrar pago
        [TestMethod]
        public void registrarPagoTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            ATENCION_AGEN atencion = agregarAtencionAgendada();
            CAJA caja1 = new CAJA();
            BONO bono1 = new BONO();
            ASEGURADORA aseguradora1 = new ASEGURADORA();
            // Dependencias
            using (var context = new CMHEntities())
            {
                // Caja
                caja1.FECHOR_APERTURA = DateTime.Today;
                caja1.ID_FUNCIONARIO = atencion.PERS_MEDICO.PERSONAL.FUNCIONARIO.FirstOrDefault().ID_FUNCIONARIO;
                context.CAJA.Add(caja1);
                context.SaveChangesAsync();

                // Aseguradora 
                aseguradora1.NOM_ASEGURADORA = "Aseguradora test";
                context.ASEGURADORA.Add(aseguradora1);    
                context.SaveChangesAsync();

                // Bono
                bono1.CANT_BONO = 100;
                bono1.COD_ASEGURADORA = "C001";
                bono1.ASEGURADORA = aseguradora1;
                context.BONO.Add(bono1);     
                context.SaveChangesAsync();
            }

            // Caso 1: Pago correcto
            PAGO pago1 = new PAGO();
            pago1.ID_ATENCION_AGEN = atencion.ID_ATENCION_AGEN;
            pago1.ID_BONO = bono1.ID_BONO;
            pago1.ID_CAJA = caja1.ID_CAJA;
            pago1.FECHOR = DateTime.Today;
            pago1.MONTO_PAGO = 10000;

            Boolean res1 = at.registrarPago(pago1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(resultadoEsperado1, res1, "Error místico al registrar pago");

            // Caso 2: Atención no existente
            PAGO pago2 = new PAGO();
            pago2.ID_ATENCION_AGEN = 0;
            pago2.ID_BONO = bono1.ID_BONO;
            pago2.ID_CAJA = caja1.ID_CAJA;
            pago2.FECHOR = DateTime.Today;
            pago2.MONTO_PAGO = 20000;

            Boolean res2 = at.registrarPago(pago2);
            Boolean resultadoEsperado2 = false;
            Assert.AreEqual(resultadoEsperado2, res2, "No debería ingresar");

            // Caso 3: Atención no existente
            PAGO pago3 = new PAGO();
            pago3.ID_ATENCION_AGEN = atencion.ID_ATENCION_AGEN;
            pago3.ID_BONO = 0;
            pago3.ID_CAJA = caja1.ID_CAJA;
            pago3.FECHOR = DateTime.Today;
            pago3.MONTO_PAGO = 30000;

            Boolean res3 = at.registrarPago(pago3);
            Boolean resultadoEsperado3 = false;
            Assert.AreEqual(resultadoEsperado3, res3, "No debería ingresar");

            // Caso 4: Caja no existente
            PAGO pago4 = new PAGO();
            pago4.ID_ATENCION_AGEN = atencion.ID_ATENCION_AGEN;
            pago4.ID_BONO = bono1.ID_BONO;
            pago4.ID_CAJA = 0;
            pago4.FECHOR = DateTime.Today;
            pago4.MONTO_PAGO = 40000;

            Boolean res4 = at.registrarPago(pago4);
            Boolean resultadoEsperado4 = false;
            Assert.AreEqual(resultadoEsperado4, res4, "No debería ingresar");
        }
        #endregion

        #region Agenda diaria
        [TestMethod]
        public void revisarAgendaDiariaTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            agregarAtencionAgendada();

            // Caso 1: Obtener agenda
            List<ATENCION_AGEN> atenciones1 = null;
            int rutPersonal1 = 12345678;
            DateTime fecha1 = DateTime.Today;

            atenciones1 = at.revisarAgendaDiaria(rutPersonal1, fecha1);
            Object resultadoNoEsperado1 = null;
            Assert.AreNotEqual(resultadoNoEsperado1, atenciones1);

            // Mostrar atenciones
            foreach (ATENCION_AGEN atencion in atenciones1)
            {
                Console.WriteLine("--- ATENCION " + atencion.ID_ATENCION_AGEN + " ---");
                Console.WriteLine("Inicio: " + atencion.BLOQUE.NUM_HORA_INI + ":" + atencion.BLOQUE.NUM_MINU_INI);
                Console.WriteLine("Fin: " + atencion.BLOQUE.NUM_HORA_FIN + ":" + atencion.BLOQUE.NUM_MINU_FIN);
            }

            // Caso 2: Personal no existente
            List<ATENCION_AGEN> atenciones2 = null;
            int rutPersonal2 = 0;
            DateTime fecha2 = DateTime.Today;

            atenciones2 = at.revisarAgendaDiaria(rutPersonal2, fecha2);
            Object resultadoEsperado2 = null;
            Assert.AreEqual(resultadoEsperado2, atenciones2);

            // Caso 3: Personal sin atenciones agendada
            PERSONAL personal3 = new PERSONAL();
            List<ATENCION_AGEN> atenciones3 = null;
            DateTime fecha3 = DateTime.Today;
            int rutPersonal3 = 11111111;

            using (var context = new CMHEntities())
            { 
                PERSONAL personalPrevia = context.PERSONAL.Where(d => d.RUT == rutPersonal3).FirstOrDefault();
                if (Util.isObjetoNulo(personalPrevia))
                {
                    personal3.NOMBRES = "Moka";
                    personal3.APELLIDOS = "Akashiya";
                    personal3.REMUNERACION = 850000;
                    personal3.PORCENT_DESCUENTO = 7;
                    personal3.HASHED_PASS = "4231";
                    personal3.RUT = rutPersonal3;
                    personal3.VERIFICADOR = "K";
                    context.PERSONAL.Add(personal3);
                    context.SaveChangesAsync();
                }

                atenciones3 = at.revisarAgendaDiaria(personal3.RUT, fecha3);
                Object resultadoEsperado3 = null;
                int resultadoEsperado4 = 0;
                Boolean resFinal = true;
                Boolean finalEsperado = false;
                if (atenciones3 == resultadoEsperado3 || atenciones3.Count == resultadoEsperado4)
                    resFinal = false;
                Assert.AreEqual(finalEsperado, resFinal);

                context.PERSONAL.Remove(context.PERSONAL.Where(d => d.RUT == rutPersonal3).FirstOrDefault());
                context.SaveChangesAsync();
            }
        }
        #endregion

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

        #region Envío correo
        [TestMethod]
        public void enviarCorreoTest()
        {
            Emailer emailer = new Emailer();
            // Caso 1: Envío correcto
            string receptor1, titulo1, cuerpo1;
            receptor1 = "fjaqueg@gmail.com";
            titulo1 = "Prueba de correos CMH";
            cuerpo1 = "Esta es una prueba exitosa del envío de correos para el portafolio 2016";

            Boolean res1 = emailer.enviarCorreo(receptor1, titulo1, cuerpo1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1);

            // Caso 2: Receptor vacío
            string receptor2, titulo2, cuerpo2;
            receptor2 = null;
            titulo2 = "Prueba de correos CMH";
            cuerpo2 = "Esta es una prueba fallida del envío de correos para el portafolio 2016";

            Boolean res2 = emailer.enviarCorreo(receptor2, titulo2, cuerpo2);
            Boolean resultadoEsperado2 = false;
            Assert.AreEqual(res2, resultadoEsperado2);

            // Caso 3: Título vacío
            string receptor3, titulo3, cuerpo3;
            receptor3 = "fjaqueg@gmail.com";
            titulo3 = string.Empty;
            cuerpo3 = "Esta es una prueba fallida del envío de correos para el portafolio 2016";

            Boolean res3 = emailer.enviarCorreo(receptor3, titulo3, cuerpo3);
            Boolean resultadoEsperado3 = false;
            Assert.AreEqual(res3, resultadoEsperado3);

            // Caso 4: Cuerpo vacío
            string receptor4, titulo4, cuerpo4;
            receptor4 = "fjaqueg@gmail.com";
            titulo4 = "Prueba de correos CMH";
            cuerpo4 = "";

            Boolean res4 = emailer.enviarCorreo(receptor4, titulo4, cuerpo4);
            Boolean resultadoEsperado4 = false;
            Assert.AreEqual(res4, resultadoEsperado4);

            // Caso 5: Receptor inválido
            string receptor5, titulo5, cuerpo5;
            receptor5 = "correoinvalido";
            titulo5 = "Prueba de correos CMH";
            cuerpo5 = "Esta es una prueba fallida del envío de correos para el portafolio 5016";

            Boolean res5 = emailer.enviarCorreo(receptor5, titulo5, cuerpo5);
            Boolean resultadoEsperado5 = false;
            Assert.AreEqual(res5, resultadoEsperado5);
        }
        #endregion

        #region Archivo base64
        [TestMethod]
        public void conversionABase64Test()
        {
            ConversorBase64 conversor = new ConversorBase64();
            // Caso 1: Conversión correcta
            string archivo1 = "../../file.pdf";

            Object res1 = conversor.convertirABase64(archivo1);
            Object resultadoNoEsperado1 = null;
            Assert.AreNotEqual(res1, resultadoNoEsperado1);
        }

        [TestMethod]
        public void conversionDesdeBase64Test()
        {
            ConversorBase64 conversor = new ConversorBase64();
            // Caso 1: Conversión correcta
            string uri = conversor.convertirABase64("../../file.pdf");

            string salida1 = "file_resultado";
            string extension1 = "pdf";
            string nombre1 = salida1 + "." + extension1;

            if (File.Exists(nombre1))
            {
                File.Delete(nombre1);
            }

            Boolean res1 = conversor.convertirDesdeBase64(uri, salida1, extension1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1);
        }
        #endregion
    }
}
