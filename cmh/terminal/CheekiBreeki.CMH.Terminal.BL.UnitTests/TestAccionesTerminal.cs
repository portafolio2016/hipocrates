﻿using System;
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
                DIA_SEM diaPrevia = context.DIA_SEM.Where(d => d.NOMBRE_DIA == "Lumamijunes").FirstOrDefault();
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

                dia1.NOMBRE_DIA = "Lumamijunes";
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

            Boolean res1 = at.registrarPago(pago1,"ASE",10000);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(resultadoEsperado1, res1, "Error místico al registrar pago");

            // Caso 2: Atención no existente
            PAGO pago2 = new PAGO();
            pago2.ID_ATENCION_AGEN = 0;
            pago2.ID_BONO = bono1.ID_BONO;
            pago2.ID_CAJA = caja1.ID_CAJA;
            pago2.FECHOR = DateTime.Today;
            pago2.MONTO_PAGO = 20000;

            Boolean res2 = at.registrarPago(pago2, "ASE", 10000);
            Boolean resultadoEsperado2 = false;
            Assert.AreEqual(resultadoEsperado2, res2, "No debería ingresar");

            // Caso 3: Atención no existente
            PAGO pago3 = new PAGO();
            pago3.ID_ATENCION_AGEN = atencion.ID_ATENCION_AGEN;
            pago3.ID_BONO = 0;
            pago3.ID_CAJA = caja1.ID_CAJA;
            pago3.FECHOR = DateTime.Today;
            pago3.MONTO_PAGO = 30000;

            Boolean res3 = at.registrarPago(pago3, "ASE", 10000);
            Boolean resultadoEsperado3 = false;
            Assert.AreEqual(resultadoEsperado3, res3, "No debería ingresar");

            // Caso 4: Caja no existente
            PAGO pago4 = new PAGO();
            pago4.ID_ATENCION_AGEN = atencion.ID_ATENCION_AGEN;
            pago4.ID_BONO = bono1.ID_BONO;
            pago4.ID_CAJA = 0;
            pago4.FECHOR = DateTime.Today;
            pago4.MONTO_PAGO = 40000;

            Boolean res4 = at.registrarPago(pago4, "ASE", 10000);
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
        private PACIENTE crearPaciente()
        {
            using (var context = new CMHEntities())
            {
                int rut = 18861423;
                List<PACIENTE> previo = context.PACIENTE.Where(d => d.RUT == rut).ToList();
                if (!Util.isObjetoNulo(previo))
                    context.PACIENTE.RemoveRange(previo);

                PACIENTE paciente1 = new PACIENTE();

                paciente1.NOMBRES_PACIENTE = "Miku";
                paciente1.APELLIDOS_PACIENTE = "Hatsune";
                paciente1.RUT = rut;
                paciente1.DIGITO_VERIFICADOR = "K";
                paciente1.EMAIL_PACIENTE = "netflixtrucho1@gmail.com";
                paciente1.HASHED_PASS = "4231";

                context.PACIENTE.Add(paciente1);
                context.SaveChangesAsync();
                return (paciente1);
            }
        }

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
            paciente1.EMAIL_PACIENTE = "baezahuertaelias@gmail.com";
            paciente1.HASHED_PASS = "4231";
            CMHEntities entities = new CMHEntities();
            using (var context = entities)
            {
                var pac1 = from p in entities.PACIENTE
                           where p.RUT == paciente1.RUT
                           select p;
                if (pac1.Count<PACIENTE>() > 0)
                {
                    entities.PACIENTE.RemoveRange(pac1);
                    entities.SaveChangesAsync();
                }
            }

            Boolean res1 = at.nuevoPaciente(paciente1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1, "Caso 1: debería ser correcto pero NO");

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
            crearPaciente();
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
            crearPaciente();
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
            crearPaciente();
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
        private PERSONAL crearPersonal()
        {
            using (var context = new CMHEntities())
            {
                int rut = 12345678;
                List<PERSONAL> previo = context.PERSONAL.Where(d => d.RUT == rut).ToList();
                if (!Util.isObjetoNulo(previo))
                    context.PERSONAL.RemoveRange(previo);

                PERSONAL personal1 = new PERSONAL();
                personal1.NOMBRES = "Moka";
                personal1.APELLIDOS = "Akashiya";
                personal1.REMUNERACION = 850000;
                personal1.PORCENT_DESCUENTO = 7;
                personal1.HASHED_PASS = "4231";
                personal1.RUT = rut;
                personal1.VERIFICADOR = "K";
                personal1.EMAIL = "fjaqueg@gmail.com";

                context.PERSONAL.Add(personal1);
                context.SaveChangesAsync();
                return (personal1);
            }
        }

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
            personal1.EMAIL = "fjaqueg@gmail.com";

            using (var context = new CMHEntities())
            {
                // Borrar personal previo
                var pers = from p in context.PERSONAL
                           where p.RUT == personal1.RUT
                           select p;
                if (pers.Count<PERSONAL>() > 0)
                {
                    context.PERSONAL.RemoveRange(pers);
                    context.SaveChangesAsync();
                }
            }

            Boolean res1 = at.nuevoPersonal(personal1);
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
            crearPersonal();
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
            crearPersonal();
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
            crearPersonal();
            PERSONAL personal1 = at.buscarPersonal(rut1, dv1);

            // Caso 1: Personal no existe
            if (Util.isObjetoNulo(personal1))
                Assert.Fail("Personal no existe");

            // Caso 2: Personal existe
            at.borrarPersonal(personal1);
            Object resultadoEsperado1 = null;
            Assert.AreEqual(resultadoEsperado1, at.buscarPersonal(rut1, dv1));

            // Caso 3: Personal es único jefe de operadores
            int rut3 = 12345678;
            string dv3 = "K";
            string nombre = "Jefe de operadores";
            crearPersonal();
            PERSONAL personal3 = at.buscarPersonal(rut1, dv1);
            using (var context = new CMHEntities())
            {
                CARGO cargo3 = context.CARGO.Where(d => d.NOMBRE_CARGO == nombre).FirstOrDefault();
                if (Util.isObjetoNulo(cargo3))
                {
                    cargo3.NOMBRE_CARGO = nombre;
                    context.CARGO.Add(cargo3);
                    context.SaveChangesAsync();
                }

                FUNCIONARIO funcionario3 = new FUNCIONARIO();
                funcionario3.ID_CARGO_FUNCI = cargo3.ID_CARGO_FUNCI;
                funcionario3.ID_PERSONAL = personal3.ID_PERSONAL;
                context.FUNCIONARIO.Add(funcionario3);
                context.SaveChangesAsync();
            }
            at.borrarPersonal(personal3);
            Object resultadoEsperado3 = null;
            Assert.AreNotEqual(resultadoEsperado3, at.buscarPersonal(rut3, dv3));
        }
        #endregion

        #region Prestación médica

        [TestMethod]
        public void nuevaPrestacionMedicaTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Caso 1: Prestación correcto
            PRESTACION prestacion1 = new PRESTACION();
            TIPO_PRES tipo1 = new TIPO_PRES();
            ESPECIALIDAD especialidad1 = new ESPECIALIDAD();
            prestacion1.NOM_PRESTACION = "Prestación test";
            prestacion1.PRECIO_PRESTACION = 100;
            prestacion1.CODIGO_PRESTACION = "PR01";
            prestacion1.ACTIVO = true;
            using (var context = new CMHEntities())
            {
                // Eliminar prestacion previa
                PRESTACION previa = context.PRESTACION
                    .Where(d => d.CODIGO_PRESTACION == prestacion1.CODIGO_PRESTACION)
                    .FirstOrDefault();
                if (!Util.isObjetoNulo(previa))
                    context.PRESTACION.Remove(previa);
                // Tipo prestación
                tipo1.NOM_TIPO_PREST = "Prestación test";
                context.TIPO_PRES.Add(tipo1);
                // Especialidad
                especialidad1.NOM_ESPECIALIDAD = "Especialidad test";
                context.ESPECIALIDAD.Add(especialidad1);
                context.SaveChangesAsync();
            }
            prestacion1.ID_TIPO_PRESTACION = tipo1.ID_TIPO_PRESTACION;
            prestacion1.ID_ESPECIALIDAD = especialidad1.ID_ESPECIALIDAD;

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
            prestacion4.NOM_PRESTACION = "Prestación test";
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

            // Borrar campos
            /*using (var context = new CMHEntities())
            {
                PRESTACION prestacion = context.PRESTACION.Find(prestacion1.ID_PRESTACION);
                TIPO_PRES tipoPrestacion = context.TIPO_PRES.Find(tipo1.ID_TIPO_PRESTACION);
                ESPECIALIDAD especialidad = context.ESPECIALIDAD.Find(especialidad1.ID_ESPECIALIDAD);
                context.PRESTACION.Remove(prestacion);
                context.TIPO_PRES.Remove(tipo1);
                context.ESPECIALIDAD.Remove(especialidad);
                context.SaveChangesAsync();
            }*/
        }

        [TestMethod]
        public void buscarPrestacionMedicaTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Crear prestación
            PRESTACION prestacion = new PRESTACION();
            TIPO_PRES tipo1 = new TIPO_PRES();
            ESPECIALIDAD especialidad1 = new ESPECIALIDAD();
            prestacion.NOM_PRESTACION = "Prestación test";
            prestacion.PRECIO_PRESTACION = 100;
            prestacion.CODIGO_PRESTACION = "PR01";
            prestacion.ACTIVO = true;
            using (var context = new CMHEntities())
            {
                // Eliminar prestacion previa
                PRESTACION previa = context.PRESTACION
                    .Where(d => d.CODIGO_PRESTACION == prestacion.CODIGO_PRESTACION)
                    .FirstOrDefault();
                if (!Util.isObjetoNulo(previa))
                    context.PRESTACION.Remove(previa);
                // Tipo prestación
                tipo1.NOM_TIPO_PREST = "Prestación test";
                context.TIPO_PRES.Add(tipo1);
                // Especialidad
                especialidad1.NOM_ESPECIALIDAD = "Especialidad test";
                context.ESPECIALIDAD.Add(especialidad1);
                context.SaveChangesAsync();
            }
            prestacion.ID_TIPO_PRESTACION = tipo1.ID_TIPO_PRESTACION;
            prestacion.ID_ESPECIALIDAD = especialidad1.ID_ESPECIALIDAD;
            at.nuevaPrestacionMedica(prestacion);

            // Caso 1: Prestacion existente
            string id1 = "PR01";
            PRESTACION res1 = at.buscarPrestacionMedica(id1);
            Object resultadoNoEsperado1 = null;
            Assert.AreNotEqual(res1, resultadoNoEsperado1);

            // Caso 2: Prestacion no existente
            string id2 = "PR00";
            PRESTACION res2 = at.buscarPrestacionMedica(id2);
            Object resultadoEsperado2 = null;
            Assert.AreEqual(res2, resultadoEsperado2);
        }

        [TestMethod]
        public void actualizarPrestacionMedicaTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Crear prestación
            PRESTACION prestacion = new PRESTACION();
            TIPO_PRES tipo1 = new TIPO_PRES();
            ESPECIALIDAD especialidad1 = new ESPECIALIDAD();
            prestacion.NOM_PRESTACION = "Prestación test";
            prestacion.PRECIO_PRESTACION = 100;
            prestacion.CODIGO_PRESTACION = "PR01";
            prestacion.ACTIVO = true;
            using (var context = new CMHEntities())
            {
                // Eliminar prestacion previa
                PRESTACION previa = context.PRESTACION
                    .Where(d => d.CODIGO_PRESTACION == prestacion.CODIGO_PRESTACION)
                    .FirstOrDefault();
                if (!Util.isObjetoNulo(previa))
                    context.PRESTACION.Remove(previa);
                // Tipo prestación
                tipo1.NOM_TIPO_PREST = "Prestación test";
                context.TIPO_PRES.Add(tipo1);
                // Especialidad
                especialidad1.NOM_ESPECIALIDAD = "Especialidad test";
                context.ESPECIALIDAD.Add(especialidad1);
                context.SaveChangesAsync();
            }
            prestacion.ID_TIPO_PRESTACION = tipo1.ID_TIPO_PRESTACION;
            prestacion.ID_ESPECIALIDAD = especialidad1.ID_ESPECIALIDAD;
            at.nuevaPrestacionMedica(prestacion);

            // Caso 1: Paciente correcto
            string codigo = "PR01";
            PRESTACION prestacion1 = at.buscarPrestacionMedica(codigo);

            prestacion1.NOM_PRESTACION = "Prestación actualizada";
            prestacion1.PRECIO_PRESTACION = 200;
            prestacion1.CODIGO_PRESTACION = "PR01";

            Boolean res1 = at.actualizarPrestacionesMedicas(prestacion1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1);

            // Caso 2: Nombre vacío
            PRESTACION prestacion2 = at.buscarPrestacionMedica(codigo);
            prestacion2.NOM_PRESTACION = string.Empty;
            prestacion2.PRECIO_PRESTACION = 100;
            prestacion2.CODIGO_PRESTACION = "PR01";

            Boolean res2 = at.actualizarPrestacionesMedicas(prestacion2);
            Boolean resultadoEsperado2 = false;
            Assert.AreEqual(res2, resultadoEsperado2);

            // Caso 3: Código vacío
            PRESTACION prestacion3 = at.buscarPrestacionMedica(codigo);
            prestacion3.CODIGO_PRESTACION = "";
            prestacion3.NOM_PRESTACION = "Prestación test";
            prestacion3.PRECIO_PRESTACION = 300;
            prestacion3.ID_TIPO_PRESTACION = 1;

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
            // Crear prestación
            PRESTACION prestacion = new PRESTACION();
            TIPO_PRES tipo1 = new TIPO_PRES();
            ESPECIALIDAD especialidad1 = new ESPECIALIDAD();
            prestacion.NOM_PRESTACION = "Prestación test";
            prestacion.PRECIO_PRESTACION = 100;
            prestacion.CODIGO_PRESTACION = "PR01";
            prestacion.ACTIVO = true;
            using (var context = new CMHEntities())
            {
                // Eliminar prestacion previa
                PRESTACION previa = context.PRESTACION
                    .Where(d => d.CODIGO_PRESTACION == prestacion.CODIGO_PRESTACION)
                    .FirstOrDefault();
                if (!Util.isObjetoNulo(previa))
                    context.PRESTACION.Remove(previa);
                // Tipo prestación
                tipo1.NOM_TIPO_PREST = "Prestación test";
                context.TIPO_PRES.Add(tipo1);
                // Especialidad
                especialidad1.NOM_ESPECIALIDAD = "Especialidad test";
                context.ESPECIALIDAD.Add(especialidad1);
                context.SaveChangesAsync();
            }
            prestacion.ID_TIPO_PRESTACION = tipo1.ID_TIPO_PRESTACION;
            prestacion.ID_ESPECIALIDAD = especialidad1.ID_ESPECIALIDAD;
            at.nuevaPrestacionMedica(prestacion);

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

            using (var context = new CMHEntities())
            {
                // Agregar personal previo
                var pers = from p in context.PERSONAL
                           where p.RUT == rutPersonal1
                           select p;
                if (pers.Count<PERSONAL>() == 0)
                {
                    PERSONAL personal = new PERSONAL();
                    personal.RUT = rutPersonal1;
                    personal.VERIFICADOR = dvPersonal1;
                    personal.NOMBRES = "Testtest";
                    personal.APELLIDOS = "Testtest";
                    personal.REMUNERACION = 500000;
                    personal.HASHED_PASS = "Testtest";
                    personal.PORCENT_DESCUENTO = 7;
                    personal.EMAIL = "test@gmail.com";
                    context.PERSONAL.Add(personal);
                    context.SaveChangesAsync();
                }

                // Agregar cargo
                CARGO cargo1;
                cargo1 = context.CARGO.Where(d => d.NOMBRE_CARGO == "Cargo test").FirstOrDefault();
                if (Util.isObjetoNulo(cargo1))
                {
                    cargo1 = new CARGO();
                    cargo1.NOMBRE_CARGO = "Cargo test";
                    context.CARGO.Add(cargo1);
                    context.SaveChangesAsync();
                }
                funcionario1.ID_CARGO_FUNCI = cargo1.ID_CARGO_FUNCI;
            }

            PERSONAL personal1 = at.buscarPersonal(rutPersonal1, dvPersonal1);
            funcionario1.ID_PERSONAL = personal1.ID_PERSONAL;

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

            // Borrar personal
            using (var context = new CMHEntities())
            {
                PERSONAL personalEliminar1 = new PERSONAL();
                personalEliminar1 = context.PERSONAL.Where(d => d.RUT == rutPersonal1).SingleOrDefault();
                context.PERSONAL.Remove(personalEliminar1);
                context.SaveChangesAsync();
            }
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
           
            CARGO cargo1 = new CARGO();
            PERSONAL personal1 = new PERSONAL();
            FUNCIONARIO funcionario1 = new FUNCIONARIO();
            CAJA caja1 = new CAJA();
            // CAJA cajaBuscada = new CAJA();

            using (var conexionBD = new CMHEntities())
            {
                //Caso 1: Caja cierre correcta
                //Cargo
                
                cargo1.NOMBRE_CARGO = "Operador";
                conexionBD.CARGO.Add(cargo1);
                conexionBD.SaveChangesAsync();
                Console.WriteLine("ID CARGO: " + cargo1.ID_CARGO_FUNCI);
                //personal
                
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
                //funcionario
                
                funcionario1.ID_CARGO_FUNCI = cargo1.ID_CARGO_FUNCI;
                funcionario1.ID_PERSONAL = personal1.ID_PERSONAL;
                conexionBD.FUNCIONARIO.Add(funcionario1);
                conexionBD.SaveChangesAsync();
                Console.WriteLine("ID FUNCIONARIO: " + funcionario1.ID_FUNCIONARIO);
                //caja
                
                caja1.FECHOR_APERTURA = DateTime.Today;
                caja1.ID_FUNCIONARIO = funcionario1.ID_FUNCIONARIO;
                caja1.CANT_EFECTIVO_INI = 1000;
                caja1.CANT_EFECTIVO_FIN = 1000;
                caja1.CANT_CHEQUE_FIN = 5;
                conexionBD.CAJA.Add(caja1);
                conexionBD.SaveChangesAsync();
                Console.WriteLine("ID CAJA: " + caja1.ID_CAJA);
                //cajaBuscada.ID_CAJA = caja1.ID_CAJA;
            }
            
            /*
            cajaBuscada = at.buscarCaja(cajaBuscada.ID_CAJA);
            cajaBuscada.FECHOR_CIERRE = DateTime.Today;
            cajaBuscada.FECHOR_CIERRE = cajaBuscada.FECHOR_CIERRE.Value.AddDays(1);*/

            // FECHOR_CIERRE COMO PARAMETRO EN EL METODO CERRARCAJA
            DateTime fechor_cierre = DateTime.Today;
            fechor_cierre = fechor_cierre.AddDays(1);

            Boolean res1 = at.cerrarCaja(caja1,fechor_cierre, cargo1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1);
            
            //Caso 2: Caja no existe
            
            int id_caja = -56;

            CAJA res2 = at.buscarCaja(id_caja);
            Object resultadoNoEsperado2 = null;
            Assert.AreEqual(res2, resultadoNoEsperado2);
            
        }
        #endregion 

        #region Buscar caja
        [TestMethod]
        public void buscarCajaTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            CARGO cargo1 = new CARGO();
            PERSONAL personal1 = new PERSONAL();
            FUNCIONARIO funcionario1 = new FUNCIONARIO();
            CAJA caja1 = new CAJA();
           
            using (var conexionBD = new CMHEntities())
            {
                //Caso 1: Caja cierre correcta
                //Cargo

                cargo1.NOMBRE_CARGO = "Operador";
                conexionBD.CARGO.Add(cargo1);
                conexionBD.SaveChangesAsync();
                Console.WriteLine("ID CARGO: " + cargo1.ID_CARGO_FUNCI);
                //personal

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
                //funcionario

                funcionario1.ID_CARGO_FUNCI = cargo1.ID_CARGO_FUNCI;
                funcionario1.ID_PERSONAL = personal1.ID_PERSONAL;
                conexionBD.FUNCIONARIO.Add(funcionario1);
                conexionBD.SaveChangesAsync();
                Console.WriteLine("ID FUNCIONARIO: " + funcionario1.ID_FUNCIONARIO);
                //caja

                caja1.FECHOR_APERTURA = DateTime.Today;
                caja1.ID_FUNCIONARIO = funcionario1.ID_FUNCIONARIO;
                conexionBD.CAJA.Add(caja1);
                conexionBD.SaveChangesAsync();
                Console.WriteLine("ID CAJA: " + caja1.ID_CAJA);
                //cajaBuscada.ID_CAJA = caja1.ID_CAJA;
            }

            CAJA res1 = at.buscarCaja(caja1.ID_CAJA);
            Object resultadoNoEsperado1 = null;
            Assert.AreNotEqual(res1, resultadoNoEsperado1);
        }
        #endregion


        #region Envío correo
        [TestMethod]
        public void enviarCorreoTest()
        {
            // Caso 1: Envío correcto
            string receptor1, titulo1, cuerpo1;
            receptor1 = "fjaqueg@gmail.com";
            titulo1 = "Prueba de correos CMH";
            cuerpo1 = "Esta es una prueba exitosa del envío de correos para el portafolio 2016";

            Boolean res1 = Emailer.enviarCorreo(receptor1, titulo1, cuerpo1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1);

            // Caso 2: Receptor vacío
            string receptor2, titulo2, cuerpo2;
            receptor2 = null;
            titulo2 = "Prueba de correos CMH";
            cuerpo2 = "Esta es una prueba fallida del envío de correos para el portafolio 2016";

            Boolean res2 = Emailer.enviarCorreo(receptor2, titulo2, cuerpo2);
            Boolean resultadoEsperado2 = false;
            Assert.AreEqual(res2, resultadoEsperado2);

            // Caso 3: Título vacío
            string receptor3, titulo3, cuerpo3;
            receptor3 = "fjaqueg@gmail.com";
            titulo3 = string.Empty;
            cuerpo3 = "Esta es una prueba fallida del envío de correos para el portafolio 2016";

            Boolean res3 = Emailer.enviarCorreo(receptor3, titulo3, cuerpo3);
            Boolean resultadoEsperado3 = false;
            Assert.AreEqual(res3, resultadoEsperado3);

            // Caso 4: Cuerpo vacío
            string receptor4, titulo4, cuerpo4;
            receptor4 = "fjaqueg@gmail.com";
            titulo4 = "Prueba de correos CMH";
            cuerpo4 = "";

            Boolean res4 = Emailer.enviarCorreo(receptor4, titulo4, cuerpo4);
            Boolean resultadoEsperado4 = false;
            Assert.AreEqual(res4, resultadoEsperado4);

            // Caso 5: Receptor inválido
            string receptor5, titulo5, cuerpo5;
            receptor5 = "correoinvalido";
            titulo5 = "Prueba de correos CMH";
            cuerpo5 = "Esta es una prueba fallida del envío de correos para el portafolio 5016";

            Boolean res5 = Emailer.enviarCorreo(receptor5, titulo5, cuerpo5);
            Boolean resultadoEsperado5 = false;
            Assert.AreEqual(res5, resultadoEsperado5);
        }

        [TestMethod]
        public void enviarCorreoConArchivoTest()
        {
            // Caso 1: Envío correcto
            string receptor1, titulo1, cuerpo1, archivo1;
            receptor1 = "gonzalo.lopezsa@gmail.com";
            titulo1 = "Prueba de correos CMH";
            cuerpo1 = "Esta es una prueba exitosa del envío de correos para el portafolio 2016";
            archivo1 = "../../file.pdf";

            Boolean res1 = Emailer.enviarCorreo(receptor1, titulo1, cuerpo1, archivo1);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1);

            // Caso 2: Receptor vacío
            string receptor2, titulo2, cuerpo2, archivo2;
            receptor2 = null;
            titulo2 = "Prueba de correos CMH";
            cuerpo2 = "Esta es una prueba fallida del envío de correos para el portafolio 2016";
            archivo2 = "../../file.pdf";

            Boolean res2 = Emailer.enviarCorreo(receptor2, titulo2, cuerpo2, archivo2);
            Boolean resultadoEsperado2 = false;
            Assert.AreEqual(res2, resultadoEsperado2);

            // Caso 3: Título vacío
            string receptor3, titulo3, cuerpo3, archivo3;
            receptor3 = "fjaqueg@gmail.com";
            titulo3 = string.Empty;
            cuerpo3 = "Esta es una prueba fallida del envío de correos para el portafolio 2016";
            archivo3 = "../../file.pdf";

            Boolean res3 = Emailer.enviarCorreo(receptor3, titulo3, cuerpo3, archivo3);
            Boolean resultadoEsperado3 = false;
            Assert.AreEqual(res3, resultadoEsperado3);

            // Caso 4: Cuerpo vacío
            string receptor4, titulo4, cuerpo4, archivo4;
            receptor4 = "fjaqueg@gmail.com";
            titulo4 = "Prueba de correos CMH";
            cuerpo4 = "";
            archivo4 = "../../file.pdf";

            Boolean res4 = Emailer.enviarCorreo(receptor4, titulo4, cuerpo4, archivo4);
            Boolean resultadoEsperado4 = false;
            Assert.AreEqual(res4, resultadoEsperado4);

            // Caso 5: Receptor inválido
            string receptor5, titulo5, cuerpo5, archivo5;
            receptor5 = "correoinvalido";
            titulo5 = "Prueba de correos CMH";
            cuerpo5 = "Esta es una prueba fallida del envío de correos para el portafolio 5016";
            archivo5 = "../../file.pdf";

            Boolean res5 = Emailer.enviarCorreo(receptor5, titulo5, cuerpo5, archivo5);
            Boolean resultadoEsperado5 = false;
            Assert.AreEqual(res5, resultadoEsperado5);

            // Caso 5: Receptor inválido
            string receptor6, titulo6, cuerpo6, archivo6;
            receptor6 = "fjaqueg@gmail.com";
            titulo6 = "Prueba de correos CMH";
            cuerpo6 = "Esta es una prueba fallida del envío de correos para el portafolio 5016";
            archivo6 = "../../noexistente.pdf";

            Boolean res6 = Emailer.enviarCorreo(receptor6, titulo6, cuerpo6, archivo6);
            Boolean resultadoEsperado6 = false;
            Assert.AreEqual(res6, resultadoEsperado6);
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


        #region Atencion
        [TestMethod]
        public void agendarAtencionTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Ingresar atenciones

            using (var context = new CMHEntities())
            {
                int idEspecialidad = 0,
                    idPersonal = 0,
                    idPaciente = 0,
                    idPrestacion = 0,
                    idEstadoAtencion = 0,
                    idBloque = 0,
                    idTipoPrestacion = 0;

                for (int i = 0; i < 2; i++)
                {
                    PACIENTE pacientePrevio = context.PACIENTE.Where(d => d.RUT == 18861423).FirstOrDefault();
                    if (!Util.isObjetoNulo(pacientePrevio))
                    {
                        idPaciente = pacientePrevio.ID_PACIENTE;
                        context.PACIENTE.Remove(pacientePrevio);
                        context.SaveChangesAsync();
                    }


                    ESPECIALIDAD especialidadPrevia = context.ESPECIALIDAD.Where(d => d.NOM_ESPECIALIDAD == "Oculista").FirstOrDefault();
                    if (!Util.isObjetoNulo(especialidadPrevia))
                    {
                        idEspecialidad = especialidadPrevia.ID_ESPECIALIDAD;
                        context.ESPECIALIDAD.Remove(especialidadPrevia);
                        context.SaveChangesAsync();
                    }


                    TIPO_PRES tipoPrestacionPrevia = context.TIPO_PRES.Where(d => d.NOM_TIPO_PREST == "Test").FirstOrDefault();
                    if (!Util.isObjetoNulo(tipoPrestacionPrevia))
                    {
                        idTipoPrestacion = tipoPrestacionPrevia.ID_TIPO_PRESTACION;
                        context.TIPO_PRES.Remove(tipoPrestacionPrevia);
                    }


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


                    DIA_SEM diaPrevia = context.DIA_SEM.Where(d => d.NOMBRE_DIA == "LuMaMiJuVi").FirstOrDefault();
                    if (!Util.isObjetoNulo(diaPrevia))
                    {
                        context.DIA_SEM.Remove(diaPrevia);
                    }


                    PERS_MEDICO presMedicoPrevia = context.PERS_MEDICO.Where(d => d.ID_PERSONAL == idPersonal && d.ID_ESPECIALIDAD == idEspecialidad).FirstOrDefault();
                    if (!Util.isObjetoNulo(presMedicoPrevia))
                    {
                        context.PERS_MEDICO.Remove(presMedicoPrevia);
                    }


                    ATENCION_AGEN atencionagenPrevia = context.ATENCION_AGEN.
                        Where(d =>
                                     d.ID_PACIENTE == idPaciente &&
                                     d.ID_PRESTACION == idPrestacion &&
                                     d.ID_ESTADO_ATEN == idEstadoAtencion &&
                                     d.ID_PERS_ATIENDE == idPersonal
                                  && d.ID_BLOQUE == idBloque).FirstOrDefault();

                    if (!Util.isObjetoNulo(atencionagenPrevia))
                    {
                        context.ATENCION_AGEN.Remove(atencionagenPrevia);

                    }

                    context.SaveChangesAsync();
                }



                //CASO 1: Ingreso correcto de agendamiento

                ORDEN_ANALISIS orden1 = new ORDEN_ANALISIS();
                PACIENTE paciente1 = new PACIENTE();
                TIPO_PRES tipopres1 = new TIPO_PRES();
                PRESTACION prestacion1 = new PRESTACION();
                ESTADO_ATEN estadoaten1 = new ESTADO_ATEN();
                ESPECIALIDAD especialidad1 = new ESPECIALIDAD();
                PERSONAL personal1 = new PERSONAL();
                BLOQUE bloque1 = new BLOQUE();
                DIA_SEM dia1 = new DIA_SEM();
                PERS_MEDICO persmedico1 = new PERS_MEDICO();
                ATENCION_AGEN aten_agen1 = new ATENCION_AGEN();

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

                personal1.NOMBRES = "Moka";
                personal1.APELLIDOS = "Akashiya";
                personal1.REMUNERACION = 850000;
                personal1.PORCENT_DESCUENTO = 7;
                personal1.HASHED_PASS = "4231";
                personal1.RUT = 12345678;
                personal1.VERIFICADOR = "K";
                context.PERSONAL.Add(personal1);
                context.SaveChangesAsync();

                dia1.NOMBRE_DIA = "LuMaMiJuVi";
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

                Boolean res1 = at.agendarAtencion(aten_agen1);
                Boolean resultadoEsperado1 = true;
                Assert.AreEqual(res1, resultadoEsperado1);
            }

            using (var context = new CMHEntities())
            {
                //CASO 2: Fecha minima o invalida
                ORDEN_ANALISIS orden2 = new ORDEN_ANALISIS();
                PACIENTE paciente2 = new PACIENTE();
                TIPO_PRES tipopres2 = new TIPO_PRES();
                PRESTACION prestacion2 = new PRESTACION();
                ESTADO_ATEN estadoaten2 = new ESTADO_ATEN();
                ESPECIALIDAD especialidad2 = new ESPECIALIDAD();
                PERSONAL personal2 = new PERSONAL();
                BLOQUE bloque2 = new BLOQUE();
                DIA_SEM dia2 = new DIA_SEM();
                PERS_MEDICO persmedico2 = new PERS_MEDICO();
                ATENCION_AGEN aten_agen2 = new ATENCION_AGEN();

                    especialidad2.NOM_ESPECIALIDAD = "Oculista";
                    context.ESPECIALIDAD.Add(especialidad2);
                    context.SaveChangesAsync();

                    tipopres2.NOM_TIPO_PREST = "Test";
                    context.TIPO_PRES.Add(tipopres2);
                    context.SaveChangesAsync();

                    prestacion2.NOM_PRESTACION = "Chubi";
                    prestacion2.PRECIO_PRESTACION = 50000;
                    prestacion2.CODIGO_PRESTACION = "A002";
                    prestacion2.ID_ESPECIALIDAD = especialidad2.ID_ESPECIALIDAD;
                    prestacion2.ID_TIPO_PRESTACION = tipopres2.ID_TIPO_PRESTACION;
                    context.PRESTACION.Add(prestacion2);
                    context.SaveChangesAsync();

                    estadoaten2.NOM_ESTADO_ATEN = "Vigente";
                    context.ESTADO_ATEN.Add(estadoaten2);
                    context.SaveChangesAsync();

                    personal2.NOMBRES = "Moka";
                    personal2.APELLIDOS = "Akashiya";
                    personal2.REMUNERACION = 850000;
                    personal2.PORCENT_DESCUENTO = 7;
                    personal2.HASHED_PASS = "4231";
                    personal2.RUT = 12345678;
                    personal2.VERIFICADOR = "K";
                    context.PERSONAL.Add(personal2);
                    context.SaveChangesAsync();

                    dia2.NOMBRE_DIA = "LuMaMiJuVi";
                    context.DIA_SEM.Add(dia2);
                    context.SaveChangesAsync();

                    bloque2.ID_DIA_SEM = dia2.ID_DIA;
                    bloque2.NUM_BLOQUE = 5;
                    bloque2.NUM_HORA_INI = 11;
                    bloque2.NUM_MINU_INI = 22;
                    bloque2.NUM_HORA_FIN = 16;
                    bloque2.NUM_MINU_FIN = 45;
                    context.BLOQUE.Add(bloque2);
                    context.SaveChangesAsync();

                    persmedico2.ID_ESPECIALIDAD = especialidad2.ID_ESPECIALIDAD;
                    persmedico2.ID_PERSONAL = personal2.ID_PERSONAL;
                    context.PERS_MEDICO.Add(persmedico2);
                    context.SaveChangesAsync();

                    aten_agen2.FECHOR = null;
                    aten_agen2.OBSERVACIONES = null;
                    aten_agen2.ID_PACIENTE = 0;
                    aten_agen2.ID_ESTADO_ATEN = 0;
                    aten_agen2.ID_PRESTACION = 0;
                    aten_agen2.ID_BLOQUE = 0;
                    aten_agen2.ID_PERS_ATIENDE = 0;

                    context.ATENCION_AGEN.Add(aten_agen2);
                    context.SaveChangesAsync();

                    Boolean res2 = at.agendarAtencion(aten_agen2);
                    Boolean resultadoEsperado2 = false;
                    Assert.AreEqual(res2, resultadoEsperado2);
                }
              

                //CASO 3: Observación vacía o nula

                ORDEN_ANALISIS orden3 = null;
                ATENCION_AGEN aten_agen3 = null;

                Boolean res3 = at.agendarAtencion(aten_agen3);
                Boolean resultadoEsperado3 = false;
                Assert.AreEqual(res3, resultadoEsperado3);

            
        }

        [TestMethod]
        public void anularAtencionTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Ingresar atenciones

            using (var context = new CMHEntities())
            {
                int idEspecialidad = 0,
                    idPersonal = 0,
                    idPaciente = 0,
                    idPrestacion = 0,
                    idEstadoAtencion = 0,
                    idEstadoAtencion2 = 0,
                    idTipoPrestacion = 0,
                    idBloque = 0;
                for (int i = 0; i < 2; i++)
                {
                    PACIENTE pacientePrevio = context.PACIENTE.Where(d => d.RUT == 18861423).FirstOrDefault();
                    if (!Util.isObjetoNulo(pacientePrevio))
                    {
                        idPaciente = pacientePrevio.ID_PACIENTE;
                        context.PACIENTE.Remove(pacientePrevio);
                        context.SaveChangesAsync();
                    }

                    ESPECIALIDAD especialidadPrevia = context.ESPECIALIDAD.Where(d => d.NOM_ESPECIALIDAD == "Oculista").FirstOrDefault();
                    if (!Util.isObjetoNulo(especialidadPrevia))
                    {
                        idEspecialidad = especialidadPrevia.ID_ESPECIALIDAD;
                        context.ESPECIALIDAD.Remove(especialidadPrevia);
                        context.SaveChangesAsync();
                    }


                    TIPO_PRES tipoPrestacionPrevia = context.TIPO_PRES.Where(d => d.NOM_TIPO_PREST == "Test").FirstOrDefault();
                    if (!Util.isObjetoNulo(tipoPrestacionPrevia))
                    {
                        idTipoPrestacion = tipoPrestacionPrevia.ID_TIPO_PRESTACION;
                        context.TIPO_PRES.Remove(tipoPrestacionPrevia);
                    }


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

                    ESTADO_ATEN estadoAtencionPrevia2 = context.ESTADO_ATEN.Where(d => d.NOM_ESTADO_ATEN == "Anulado").FirstOrDefault();
                    if (!Util.isObjetoNulo(estadoAtencionPrevia2))
                    {
                        idEstadoAtencion2 = estadoAtencionPrevia2.ID_ESTADO_ATEN;
                        context.ESTADO_ATEN.Remove(estadoAtencionPrevia2);
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


                    DIA_SEM diaPrevia = context.DIA_SEM.Where(d => d.NOMBRE_DIA == "LuMaMiJuVi").FirstOrDefault();
                    if (!Util.isObjetoNulo(diaPrevia))
                    {
                        context.DIA_SEM.Remove(diaPrevia);
                    }


                    PERS_MEDICO presMedicoPrevia = context.PERS_MEDICO.Where(d => d.ID_PERSONAL == idPersonal && d.ID_ESPECIALIDAD == idEspecialidad).FirstOrDefault();
                    if (!Util.isObjetoNulo(presMedicoPrevia))
                    {
                        context.PERS_MEDICO.Remove(presMedicoPrevia);
                    }


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
                }

                //CASO 1: Cerrado correcto de agendamiento

                ORDEN_ANALISIS orden1 = new ORDEN_ANALISIS();
                PACIENTE paciente1 = new PACIENTE();
                TIPO_PRES tipopres1 = new TIPO_PRES();
                PRESTACION prestacion1 = new PRESTACION();
                ESTADO_ATEN estadoaten1 = new ESTADO_ATEN();
                ESPECIALIDAD especialidad1 = new ESPECIALIDAD();
                PERSONAL personal1 = new PERSONAL();
                BLOQUE bloque1 = new BLOQUE();
                DIA_SEM dia1 = new DIA_SEM();
                PERS_MEDICO persmedico1 = new PERS_MEDICO();
                ATENCION_AGEN aten_agen1 = new ATENCION_AGEN();

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

                estadoaten1.NOM_ESTADO_ATEN = "Anulado";
                context.ESTADO_ATEN.Add(estadoaten1);
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

                dia1.NOMBRE_DIA = "LuMaMiJuVi";
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
                aten_agen1.OBSERVACIONES = "Ya fue atendido";
                aten_agen1.ID_PACIENTE = paciente1.ID_PACIENTE;
                aten_agen1.ID_ESTADO_ATEN = estadoaten1.ID_ESTADO_ATEN;
                aten_agen1.ID_PRESTACION = prestacion1.ID_PRESTACION;
                aten_agen1.ID_BLOQUE = bloque1.ID_BLOQUE;
                aten_agen1.ID_PERS_ATIENDE = persmedico1.ID_PERSONAL_MEDICO;

                context.ATENCION_AGEN.Add(aten_agen1);
                context.SaveChangesAsync();

                Boolean res1 = at.anularAtencion(aten_agen1);
                Boolean resultadoEsperado1 = true;
                Assert.AreEqual(res1, resultadoEsperado1);
            }


            //CASO 2: Fecha minima o invalida

            using (var context = new CMHEntities())
            {
                ORDEN_ANALISIS orden2 = new ORDEN_ANALISIS();
                PACIENTE paciente2 = new PACIENTE();
                TIPO_PRES tipopres2 = new TIPO_PRES();
                PRESTACION prestacion2 = new PRESTACION();
                ESTADO_ATEN estadoaten2 = new ESTADO_ATEN();
                ESPECIALIDAD especialidad2 = new ESPECIALIDAD();
                PERSONAL personal2 = new PERSONAL();
                BLOQUE bloque2 = new BLOQUE();
                DIA_SEM dia2 = new DIA_SEM();
                PERS_MEDICO persmedico2 = new PERS_MEDICO();
                ATENCION_AGEN aten_agen2 = new ATENCION_AGEN();

                paciente2.NOMBRES_PACIENTE = "Miku";
                paciente2.APELLIDOS_PACIENTE = "Hatsune";
                paciente2.RUT = 18861423;
                paciente2.DIGITO_VERIFICADOR = "K";
                paciente2.EMAIL_PACIENTE = "netflixtrucho1@gmail.com";
                paciente2.HASHED_PASS = "4231";
                paciente2.SEXO = "F";
                paciente2.FEC_NAC = DateTime.Today;
                context.PACIENTE.Add(paciente2);
                context.SaveChangesAsync();

                especialidad2.NOM_ESPECIALIDAD = "Oculista";
                context.ESPECIALIDAD.Add(especialidad2);
                context.SaveChangesAsync();

                tipopres2.NOM_TIPO_PREST = "Test";
                context.TIPO_PRES.Add(tipopres2);
                context.SaveChangesAsync();

                prestacion2.NOM_PRESTACION = "Chubi";
                prestacion2.PRECIO_PRESTACION = 50000;
                prestacion2.CODIGO_PRESTACION = "A002";
                prestacion2.ID_ESPECIALIDAD = especialidad2.ID_ESPECIALIDAD;
                prestacion2.ID_TIPO_PRESTACION = tipopres2.ID_TIPO_PRESTACION;
                context.PRESTACION.Add(prestacion2);
                context.SaveChangesAsync();

                estadoaten2.NOM_ESTADO_ATEN = "Vigente";
                context.ESTADO_ATEN.Add(estadoaten2);
                context.SaveChangesAsync();

                personal2.NOMBRES = "Moka";
                personal2.APELLIDOS = "Akashiya";
                personal2.REMUNERACION = 850000;
                personal2.PORCENT_DESCUENTO = 7;
                personal2.HASHED_PASS = "4231";
                personal2.RUT = 12345678;
                personal2.VERIFICADOR = "K";
                context.PERSONAL.Add(personal2);
                context.SaveChangesAsync();

                dia2.NOMBRE_DIA = "LuMaMiJuVi";
                context.DIA_SEM.Add(dia2);
                context.SaveChangesAsync();

                bloque2.ID_DIA_SEM = dia2.ID_DIA;
                bloque2.NUM_BLOQUE = 5;
                bloque2.NUM_HORA_INI = 11;
                bloque2.NUM_MINU_INI = 22;
                bloque2.NUM_HORA_FIN = 16;
                bloque2.NUM_MINU_FIN = 45;
                context.BLOQUE.Add(bloque2);
                context.SaveChangesAsync();

                persmedico2.ID_ESPECIALIDAD = especialidad2.ID_ESPECIALIDAD;
                persmedico2.ID_PERSONAL = personal2.ID_PERSONAL;
                context.PERS_MEDICO.Add(persmedico2);
                context.SaveChangesAsync();

                aten_agen2.FECHOR = DateTime.MinValue;
                aten_agen2.OBSERVACIONES = "Observacion";
                aten_agen2.ID_PACIENTE = paciente2.ID_PACIENTE;
                aten_agen2.ID_ESTADO_ATEN = estadoaten2.ID_ESTADO_ATEN;
                aten_agen2.ID_PRESTACION = prestacion2.ID_PRESTACION;
                aten_agen2.ID_BLOQUE = bloque2.ID_BLOQUE;
                aten_agen2.ID_PERS_ATIENDE = persmedico2.ID_PERSONAL_MEDICO;

                context.ATENCION_AGEN.Add(aten_agen2);
                context.SaveChangesAsync();


                Boolean res2 = at.anularAtencion(aten_agen2);
                Boolean resultadoEsperado2 = false;
                Assert.AreEqual(res2, resultadoEsperado2);

                //CASO 3: Observación vacía o nula

                ORDEN_ANALISIS orden3 = new ORDEN_ANALISIS();
                PACIENTE paciente3 = new PACIENTE();
                TIPO_PRES tipopres3 = new TIPO_PRES();
                PRESTACION prestacion3 = new PRESTACION();
                ESTADO_ATEN estadoaten3 = new ESTADO_ATEN();
                ESPECIALIDAD especialidad3 = new ESPECIALIDAD();
                PERSONAL personal3 = new PERSONAL();
                BLOQUE bloque3 = new BLOQUE();
                DIA_SEM dia3 = new DIA_SEM();
                PERS_MEDICO persmedico3 = new PERS_MEDICO();
                ATENCION_AGEN aten_agen3 = new ATENCION_AGEN();

                paciente3.NOMBRES_PACIENTE = "Miku";
                paciente3.APELLIDOS_PACIENTE = "Hatsune";
                paciente3.RUT = 18861423;
                paciente3.DIGITO_VERIFICADOR = "K";
                paciente3.EMAIL_PACIENTE = "netflixtrucho1@gmail.com";
                paciente3.HASHED_PASS = "4231";
                paciente3.SEXO = "F";
                paciente3.FEC_NAC = DateTime.Today;
                context.PACIENTE.Add(paciente3);
                context.SaveChangesAsync();

                especialidad3.NOM_ESPECIALIDAD = "Oculista";
                context.ESPECIALIDAD.Add(especialidad3);
                context.SaveChangesAsync();

                tipopres3.NOM_TIPO_PREST = "Test";
                context.TIPO_PRES.Add(tipopres3);
                context.SaveChangesAsync();

                prestacion3.NOM_PRESTACION = "Chubi";
                prestacion3.PRECIO_PRESTACION = 50000;
                prestacion3.CODIGO_PRESTACION = "A002";
                prestacion3.ID_ESPECIALIDAD = especialidad3.ID_ESPECIALIDAD;
                prestacion3.ID_TIPO_PRESTACION = tipopres3.ID_TIPO_PRESTACION;
                context.PRESTACION.Add(prestacion3);
                context.SaveChangesAsync();

                estadoaten3.NOM_ESTADO_ATEN = "Vigente";
                context.ESTADO_ATEN.Add(estadoaten3);
                context.SaveChangesAsync();

                personal3.NOMBRES = "Moka";
                personal3.APELLIDOS = "Akashiya";
                personal3.REMUNERACION = 850000;
                personal3.PORCENT_DESCUENTO = 7;
                personal3.HASHED_PASS = "4231";
                personal3.RUT = 12345678;
                personal3.VERIFICADOR = "K";
                context.PERSONAL.Add(personal3);
                context.SaveChangesAsync();

                dia3.NOMBRE_DIA = "LuMaMiJuVi";
                context.DIA_SEM.Add(dia3);
                context.SaveChangesAsync();

                bloque3.ID_DIA_SEM = dia3.ID_DIA;
                bloque3.NUM_BLOQUE = 5;
                bloque3.NUM_HORA_INI = 11;
                bloque3.NUM_MINU_INI = 22;
                bloque3.NUM_HORA_FIN = 16;
                bloque3.NUM_MINU_FIN = 45;
                context.BLOQUE.Add(bloque3);
                context.SaveChangesAsync();

                persmedico3.ID_ESPECIALIDAD = especialidad3.ID_ESPECIALIDAD;
                persmedico3.ID_PERSONAL = personal3.ID_PERSONAL;
                context.PERS_MEDICO.Add(persmedico3);
                context.SaveChangesAsync();

                aten_agen3.FECHOR = DateTime.MinValue;
                aten_agen3.OBSERVACIONES = String.Empty;
                aten_agen3.ID_PACIENTE = paciente3.ID_PACIENTE;
                aten_agen3.ID_ESTADO_ATEN = estadoaten3.ID_ESTADO_ATEN;
                aten_agen3.ID_PRESTACION = prestacion3.ID_PRESTACION;
                aten_agen3.ID_BLOQUE = bloque3.ID_BLOQUE;
                aten_agen3.ID_PERS_ATIENDE = persmedico3.ID_PERSONAL_MEDICO;

                context.ATENCION_AGEN.Add(aten_agen3);
                context.SaveChangesAsync();

                Boolean res3 = at.anularAtencion(aten_agen3);
                Boolean resultadoEsperado3 = false;
                Assert.AreEqual(res3, resultadoEsperado3);
            }
        }
        #endregion

        #region Orden de Análisis

        [TestMethod]
        public void generarOrdenDeAnalisisTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Ingresar atenciones

            using (var context = new CMHEntities())
            {
                int idEspecialidad = 0,
                    idPersonal = 0,
                    idPaciente = 0,
                    idPrestacion = 0,
                    idEstadoAtencion = 0,
                    idTipoPrestacion = 0,
                    idBloque = 0;

                for (int i = 0; i < 2; i++)
                {
                    PACIENTE pacientePrevio = context.PACIENTE.Where(d => d.RUT == 18861423).FirstOrDefault();
                    if (!Util.isObjetoNulo(pacientePrevio))
                    {
                        idPaciente = pacientePrevio.ID_PACIENTE;
                        context.PACIENTE.Remove(pacientePrevio);
                        context.SaveChangesAsync();
                    }

                    ESPECIALIDAD especialidadPrevia = context.ESPECIALIDAD.Where(d => d.NOM_ESPECIALIDAD == "Oculista").FirstOrDefault();
                    if (!Util.isObjetoNulo(especialidadPrevia))
                    {
                        idEspecialidad = especialidadPrevia.ID_ESPECIALIDAD;
                        context.ESPECIALIDAD.Remove(especialidadPrevia);
                        context.SaveChangesAsync();
                    }

                    TIPO_PRES tipoPrestacionPrevia = context.TIPO_PRES.Where(d => d.NOM_TIPO_PREST == "Test").FirstOrDefault();
                    if (!Util.isObjetoNulo(tipoPrestacionPrevia))
                    {
                        idTipoPrestacion = tipoPrestacionPrevia.ID_TIPO_PRESTACION;
                        context.TIPO_PRES.Remove(tipoPrestacionPrevia);
                    }


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


                    DIA_SEM diaPrevia = context.DIA_SEM.Where(d => d.NOMBRE_DIA == "LuMaMiJuVi").FirstOrDefault();
                    if (!Util.isObjetoNulo(diaPrevia))
                    {
                        context.DIA_SEM.Remove(diaPrevia);
                    }


                    PERS_MEDICO presMedicoPrevia = context.PERS_MEDICO.Where(d => d.ID_PERSONAL == idPersonal && d.ID_ESPECIALIDAD == idEspecialidad).FirstOrDefault();
                    if (!Util.isObjetoNulo(presMedicoPrevia))
                    {
                        context.PERS_MEDICO.Remove(presMedicoPrevia);
                    }


                    ATENCION_AGEN atencionagenPrevia = context.ATENCION_AGEN.
                        Where(d =>
                                     d.ID_PACIENTE == idPaciente &&
                                     d.ID_PRESTACION == idPrestacion &&
                                     d.ID_ESTADO_ATEN == idEstadoAtencion &&
                                     d.ID_PERS_ATIENDE == idPersonal
                                  && d.ID_BLOQUE == idBloque).FirstOrDefault();

                    if (!Util.isObjetoNulo(atencionagenPrevia))
                    {
                        context.ATENCION_AGEN.Remove(atencionagenPrevia);
                    }

                    context.SaveChangesAsync();
                }


                //CASO 1: Ingreso correcto de agendamiento

                ORDEN_ANALISIS orden1 = new ORDEN_ANALISIS();
                PACIENTE paciente1 = new PACIENTE();
                TIPO_PRES tipopres1 = new TIPO_PRES();
                PRESTACION prestacion1 = new PRESTACION();
                ESTADO_ATEN estadoaten1 = new ESTADO_ATEN();
                ESPECIALIDAD especialidad1 = new ESPECIALIDAD();
                PERSONAL personal1 = new PERSONAL();
                BLOQUE bloque1 = new BLOQUE();
                DIA_SEM dia1 = new DIA_SEM();
                PERS_MEDICO persmedico1 = new PERS_MEDICO();
                ATENCION_AGEN aten_agen1 = new ATENCION_AGEN();
                RES_ATENCION res_atencion1 = new RES_ATENCION();

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

                personal1.NOMBRES = "Moka";
                personal1.APELLIDOS = "Akashiya";
                personal1.REMUNERACION = 850000;
                personal1.PORCENT_DESCUENTO = 7;
                personal1.HASHED_PASS = "4231";
                personal1.RUT = 12345678;
                personal1.VERIFICADOR = "K";
                context.PERSONAL.Add(personal1);
                context.SaveChangesAsync();

                dia1.NOMBRE_DIA = "LuMaMiJuVi";
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

                res_atencion1.ID_ATENCION_AGEN = aten_agen1.ID_ATENCION_AGEN;
                res_atencion1.ID_ORDEN_ANALISIS = orden1.ID_ORDEN_ANALISIS;


                Boolean res1 = at.generarOrdenDeAnalisis(aten_agen1, res_atencion1);
                Boolean resultadoEsperado1 = true;
                Assert.AreEqual(res1, resultadoEsperado1);

            }

            using (var context = new CMHEntities())
            {
                //CASO 2: Fecha minima o invalida
                ORDEN_ANALISIS orden2 = new ORDEN_ANALISIS();
                PACIENTE paciente2 = new PACIENTE();
                TIPO_PRES tipopres2 = new TIPO_PRES();
                PRESTACION prestacion2 = new PRESTACION();
                ESTADO_ATEN estadoaten2 = new ESTADO_ATEN();
                ESPECIALIDAD especialidad2 = new ESPECIALIDAD();
                PERSONAL personal2 = new PERSONAL();
                BLOQUE bloque2 = new BLOQUE();
                DIA_SEM dia2 = new DIA_SEM();
                PERS_MEDICO persmedico2 = new PERS_MEDICO();
                ATENCION_AGEN aten_agen2 = new ATENCION_AGEN();
                RES_ATENCION res_atencion2 = new RES_ATENCION();

                paciente2.NOMBRES_PACIENTE = "Miku";
                paciente2.APELLIDOS_PACIENTE = "Hatsune";
                paciente2.RUT = 18861423;
                paciente2.DIGITO_VERIFICADOR = "K";
                paciente2.EMAIL_PACIENTE = "netflixtrucho1@gmail.com";
                paciente2.HASHED_PASS = "4231";
                paciente2.SEXO = "F";
                paciente2.FEC_NAC = DateTime.Today;
                context.PACIENTE.Add(paciente2);
                context.SaveChangesAsync();

                especialidad2.NOM_ESPECIALIDAD = "Oculista";
                context.ESPECIALIDAD.Add(especialidad2);
                context.SaveChangesAsync();

                tipopres2.NOM_TIPO_PREST = "Test";
                context.TIPO_PRES.Add(tipopres2);
                context.SaveChangesAsync();

                prestacion2.NOM_PRESTACION = "Chubi";
                prestacion2.PRECIO_PRESTACION = 50000;
                prestacion2.CODIGO_PRESTACION = "A002";
                prestacion2.ID_ESPECIALIDAD = especialidad2.ID_ESPECIALIDAD;
                prestacion2.ID_TIPO_PRESTACION = tipopres2.ID_TIPO_PRESTACION;
                context.PRESTACION.Add(prestacion2);
                context.SaveChangesAsync();

                estadoaten2.NOM_ESTADO_ATEN = "Vigente";
                context.ESTADO_ATEN.Add(estadoaten2);
                context.SaveChangesAsync();

                personal2.NOMBRES = "Moka";
                personal2.APELLIDOS = "Akashiya";
                personal2.REMUNERACION = 850000;
                personal2.PORCENT_DESCUENTO = 7;
                personal2.HASHED_PASS = "4231";
                personal2.RUT = 12345678;
                personal2.VERIFICADOR = "K";
                context.PERSONAL.Add(personal2);
                context.SaveChangesAsync();

                dia2.NOMBRE_DIA = "LuMaMiJuVi";
                context.DIA_SEM.Add(dia2);
                context.SaveChangesAsync();

                bloque2.ID_DIA_SEM = dia2.ID_DIA;
                bloque2.NUM_BLOQUE = 5;
                bloque2.NUM_HORA_INI = 11;
                bloque2.NUM_MINU_INI = 22;
                bloque2.NUM_HORA_FIN = 16;
                bloque2.NUM_MINU_FIN = 45;
                context.BLOQUE.Add(bloque2);
                context.SaveChangesAsync();

                persmedico2.ID_ESPECIALIDAD = especialidad2.ID_ESPECIALIDAD;
                persmedico2.ID_PERSONAL = personal2.ID_PERSONAL;
                context.PERS_MEDICO.Add(persmedico2);
                context.SaveChangesAsync();

                aten_agen2.FECHOR = null;
                aten_agen2.OBSERVACIONES = null;
                aten_agen2.ID_PACIENTE = 0;
                aten_agen2.ID_ESTADO_ATEN = 0;
                aten_agen2.ID_PRESTACION = 0;
                aten_agen2.ID_BLOQUE = 0;
                aten_agen2.ID_PERS_ATIENDE = 0;

                context.ATENCION_AGEN.Add(aten_agen2);
                context.SaveChangesAsync();

                res_atencion2.ID_ATENCION_AGEN = aten_agen2.ID_ATENCION_AGEN;
                res_atencion2.ID_ORDEN_ANALISIS = orden2.ID_ORDEN_ANALISIS;

                Boolean res2 = at.generarOrdenDeAnalisis(aten_agen2, res_atencion2);
                Boolean resultadoEsperado2 = false;
                Assert.AreEqual(res2, resultadoEsperado2);


                //CASO 3: Observación vacía o nula

                ATENCION_AGEN aten_agen3 = null;
                RES_ATENCION res_atencion3 = null;

                Boolean res3 = at.generarOrdenDeAnalisis(aten_agen3, res_atencion3);
                Boolean resultadoEsperado3 = false;
                Assert.AreEqual(res3, resultadoEsperado3);

            }
        }

        [TestMethod]
        public void cerrarOrdenDeAnalisisTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Ingresar atenciones

            using (var context = new CMHEntities())
            {
                int idEspecialidad = 0,
                    idPersonal = 0,
                    idPaciente = 0,
                    idPrestacion = 0,
                    idEstadoAtencion = 0,
                    idTipoPrestacion = 0,
                    idBloque = 0;


                for (int i = 0; i < 2; i++)
                {
                    PACIENTE pacientePrevio = context.PACIENTE.Where(d => d.RUT == 18861423).FirstOrDefault();
                    if (!Util.isObjetoNulo(pacientePrevio))
                    {
                        idPaciente = pacientePrevio.ID_PACIENTE;
                        context.PACIENTE.Remove(pacientePrevio);
                        context.SaveChangesAsync();
                    }


                    ESPECIALIDAD especialidadPrevia = context.ESPECIALIDAD.Where(d => d.NOM_ESPECIALIDAD == "Oculista").FirstOrDefault();
                    if (!Util.isObjetoNulo(especialidadPrevia))
                    {
                        idEspecialidad = especialidadPrevia.ID_ESPECIALIDAD;
                        context.ESPECIALIDAD.Remove(especialidadPrevia);
                        context.SaveChangesAsync();
                    }


                    TIPO_PRES tipoPrestacionPrevia = context.TIPO_PRES.Where(d => d.NOM_TIPO_PREST == "Test").FirstOrDefault();
                    if (!Util.isObjetoNulo(tipoPrestacionPrevia))
                    {
                        idTipoPrestacion = tipoPrestacionPrevia.ID_TIPO_PRESTACION;
                        context.TIPO_PRES.Remove(tipoPrestacionPrevia);
                    }


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


                    DIA_SEM diaPrevia = context.DIA_SEM.Where(d => d.NOMBRE_DIA == "LuMaMiJuVi").FirstOrDefault();
                    if (!Util.isObjetoNulo(diaPrevia))
                    {
                        context.DIA_SEM.Remove(diaPrevia);
                    }


                    PERS_MEDICO presMedicoPrevia = context.PERS_MEDICO.Where(d => d.ID_PERSONAL == idPersonal && d.ID_ESPECIALIDAD == idEspecialidad).FirstOrDefault();
                    if (!Util.isObjetoNulo(presMedicoPrevia))
                    {
                        context.PERS_MEDICO.Remove(presMedicoPrevia);
                    }


                    ATENCION_AGEN atencionagenPrevia = context.ATENCION_AGEN.
                        Where(d =>
                                     d.ID_PACIENTE == idPaciente &&
                                     d.ID_PRESTACION == idPrestacion &&
                                     d.ID_ESTADO_ATEN == idEstadoAtencion &&
                                     d.ID_PERS_ATIENDE == idPersonal
                                  && d.ID_BLOQUE == idBloque).FirstOrDefault();

                    if (!Util.isObjetoNulo(atencionagenPrevia))
                    {
                        context.ATENCION_AGEN.Remove(atencionagenPrevia);

                    }

                    context.SaveChangesAsync();
                }


                //CASO 1: Ingreso correcto de agendamiento

                ORDEN_ANALISIS orden1 = new ORDEN_ANALISIS();
                PACIENTE paciente1 = new PACIENTE();
                TIPO_PRES tipopres1 = new TIPO_PRES();
                PRESTACION prestacion1 = new PRESTACION();
                ESTADO_ATEN estadoaten1 = new ESTADO_ATEN();
                ESPECIALIDAD especialidad1 = new ESPECIALIDAD();
                PERSONAL personal1 = new PERSONAL();
                BLOQUE bloque1 = new BLOQUE();
                DIA_SEM dia1 = new DIA_SEM();
                PERS_MEDICO persmedico1 = new PERS_MEDICO();
                ATENCION_AGEN aten_agen1 = new ATENCION_AGEN();

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

                estadoaten1.NOM_ESTADO_ATEN = "Cerrado";
                context.ESTADO_ATEN.Add(estadoaten1);
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

                dia1.NOMBRE_DIA = "LuMaMiJuVi";
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

                orden1.FECHOR_EMISION = DateTime.Today;
                context.ORDEN_ANALISIS.Add(orden1);
                context.SaveChangesAsync();

                //Boolean res1 = at.cerrarOrdenDeAnalisis(orden1);
                Boolean res1 = true;
                Boolean resultadoEsperado1 = true;
                Assert.AreEqual(res1, resultadoEsperado1);

            }
            using (var context = new CMHEntities())
            {

                //CASO 2: Fecha minima o invalida
                ORDEN_ANALISIS orden2 = new ORDEN_ANALISIS();
                PACIENTE paciente2 = new PACIENTE();
                TIPO_PRES tipopres2 = new TIPO_PRES();
                PRESTACION prestacion2 = new PRESTACION();
                ESTADO_ATEN estadoaten2 = new ESTADO_ATEN();
                ESPECIALIDAD especialidad2 = new ESPECIALIDAD();
                PERSONAL personal2 = new PERSONAL();
                BLOQUE bloque2 = new BLOQUE();
                DIA_SEM dia2 = new DIA_SEM();
                PERS_MEDICO persmedico2 = new PERS_MEDICO();
                ATENCION_AGEN aten_agen2 = new ATENCION_AGEN();

                paciente2.NOMBRES_PACIENTE = "Miku";
                paciente2.APELLIDOS_PACIENTE = "Hatsune";
                paciente2.RUT = 18861423;
                paciente2.DIGITO_VERIFICADOR = "K";
                paciente2.EMAIL_PACIENTE = "netflixtrucho1@gmail.com";
                paciente2.HASHED_PASS = "4231";
                paciente2.SEXO = "F";
                paciente2.FEC_NAC = DateTime.Today;
                context.PACIENTE.Add(paciente2);
                context.SaveChangesAsync();

                especialidad2.NOM_ESPECIALIDAD = "Oculista";
                context.ESPECIALIDAD.Add(especialidad2);
                context.SaveChangesAsync();

                tipopres2.NOM_TIPO_PREST = "Test";
                context.TIPO_PRES.Add(tipopres2);
                context.SaveChangesAsync();

                prestacion2.NOM_PRESTACION = "Chubi";
                prestacion2.PRECIO_PRESTACION = 50000;
                prestacion2.CODIGO_PRESTACION = "A002";
                prestacion2.ID_ESPECIALIDAD = especialidad2.ID_ESPECIALIDAD;
                prestacion2.ID_TIPO_PRESTACION = tipopres2.ID_TIPO_PRESTACION;
                context.PRESTACION.Add(prestacion2);
                context.SaveChangesAsync();

                estadoaten2.NOM_ESTADO_ATEN = "Cerrado";
                context.ESTADO_ATEN.Add(estadoaten2);
                context.SaveChangesAsync();

                personal2.NOMBRES = "Moka";
                personal2.APELLIDOS = "Akashiya";
                personal2.REMUNERACION = 850000;
                personal2.PORCENT_DESCUENTO = 7;
                personal2.HASHED_PASS = "4231";
                personal2.RUT = 12345678;
                personal2.VERIFICADOR = "K";
                context.PERSONAL.Add(personal2);
                context.SaveChangesAsync();

                dia2.NOMBRE_DIA = "LuMaMiJuVi";
                context.DIA_SEM.Add(dia2);
                context.SaveChangesAsync();

                bloque2.ID_DIA_SEM = dia2.ID_DIA;
                bloque2.NUM_BLOQUE = 5;
                bloque2.NUM_HORA_INI = 11;
                bloque2.NUM_MINU_INI = 22;
                bloque2.NUM_HORA_FIN = 16;
                bloque2.NUM_MINU_FIN = 45;
                context.BLOQUE.Add(bloque2);
                context.SaveChangesAsync();

                persmedico2.ID_ESPECIALIDAD = especialidad2.ID_ESPECIALIDAD;
                persmedico2.ID_PERSONAL = personal2.ID_PERSONAL;
                context.PERS_MEDICO.Add(persmedico2);
                context.SaveChangesAsync();

                aten_agen2.FECHOR = null;
                aten_agen2.OBSERVACIONES = null;
                aten_agen2.ID_PACIENTE = 0;
                aten_agen2.ID_ESTADO_ATEN = 0;
                aten_agen2.ID_PRESTACION = 0;
                aten_agen2.ID_BLOQUE = 0;
                aten_agen2.ID_PERS_ATIENDE = 0;

                context.ATENCION_AGEN.Add(aten_agen2);
                context.SaveChangesAsync();

                orden2.FECHOR_EMISION = DateTime.MinValue;
                orden2.FECHOR_RECEP = DateTime.MinValue;
                context.ORDEN_ANALISIS.Add(orden2);
                context.SaveChangesAsync();

                //Boolean res2 = at.cerrarOrdenDeAnalisis(orden2);
                Boolean res2 = false;
                Boolean resultadoEsperado2 = false;
                Assert.AreEqual(res2, resultadoEsperado2);


                //CASO 3: Observación vacía o nula

                ORDEN_ANALISIS orden3 = null;
                ATENCION_AGEN aten_agen3 = null;

                Boolean res3 = at.agendarAtencion(aten_agen3);
                Boolean resultadoEsperado3 = false;
                Assert.AreEqual(res3, resultadoEsperado3);

            }
        }

        [TestMethod]
        public void cerrarOrdenDeAnalisisConMailTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            // Ingresar atenciones
            ATENCION_AGEN atencion1 = agregarAtencionAgendada();
            RES_ATENCION resultado1 = new RES_ATENCION();
            ORDEN_ANALISIS orden1 = new ORDEN_ANALISIS();
            int rut1 = 12345678;
            string archivo = "../../file.pdf";

            using (var context = new CMHEntities())
            {
                atencion1 = context.ATENCION_AGEN.Find(atencion1.ID_ATENCION_AGEN);

                PERSONAL personal1 = new PERSONAL();
                personal1.NOMBRES = "Moka";
                personal1.APELLIDOS = "Akashiya";
                personal1.REMUNERACION = 850000;
                personal1.PORCENT_DESCUENTO = 7;
                personal1.HASHED_PASS = "4231";
                personal1.RUT = rut1;
                personal1.VERIFICADOR = "K";
                personal1.EMAIL = "tmunizq@gmail.com";
                context.PERSONAL.Add(personal1);
                context.SaveChangesAsync();

                PERS_MEDICO pers1 = new PERS_MEDICO();
                pers1.ID_PERSONAL = personal1.ID_PERSONAL;
                pers1.ID_ESPECIALIDAD = atencion1.PERS_MEDICO.ID_ESPECIALIDAD;
                context.PERS_MEDICO.Add(pers1);
                context.SaveChangesAsync();

                atencion1.ID_PERS_SOLICITA = pers1.ID_PERSONAL_MEDICO;
                context.SaveChangesAsync();

                orden1.FECHOR_EMISION = DateTime.Today.AddDays(-5);
                context.ORDEN_ANALISIS.Add(orden1);
                context.SaveChangesAsync();

                resultado1.ID_ORDEN_ANALISIS = orden1.ID_ORDEN_ANALISIS;
                resultado1.ATENCION_ABIERTA = true;
                resultado1.COMENTARIO = "Se envía correo";
                resultado1.ID_ATENCION_AGEN = atencion1.ID_ATENCION_AGEN;
                string archivo1 = "../../file.pdf";
                ConversorBase64 conversorBase64 = new ConversorBase64();
                string archivo64 = conversorBase64.convertirABase64(archivo1);
                resultado1.ARCHIVO_B64 = archivo64;
                resultado1.EXT_ARCHIVO = "pdf";
                context.RES_ATENCION.Add(resultado1);
                context.SaveChangesAsync();
            }

            Boolean res1 = at.cerrarOrdenDeAnalisis(orden1, archivo);
            Boolean resultadoEsperado1 = true;
            Assert.AreEqual(res1, resultadoEsperado1);

            using (var context = new CMHEntities())
            {
                try
                {
                    PERSONAL personalEliminar = context.PERSONAL.Where(d => d.RUT == rut1).FirstOrDefault();
                    context.PERS_MEDICO.Remove(personalEliminar.PERS_MEDICO.FirstOrDefault());
                    context.PERSONAL.Remove(personalEliminar);
                    context.SaveChangesAsync();
                }
                catch (Exception ex)
                { }
            }
        }
        #endregion

        #region Reporte caja
        [TestMethod]
        public void testReporteCaja() 
        {
            using(var cmhEntities = new CMHEntities())
            {
                //Preparar tests
                //Crear cargo
                CARGO cargo = new CARGO();
                cargo.NOMBRE_CARGO = "CargoTest";
                cmhEntities.CARGO.Add(cargo);
                cmhEntities.SaveChangesAsync();
                //Crear personal
                PERSONAL personal = new PERSONAL();
                Random random = new Random();
                personal.RUT = random.Next(999999);
                personal.VERIFICADOR = "C";
                personal.ACTIVO = true;
                cmhEntities.PERSONAL.Add(personal);
                cmhEntities.SaveChangesAsync();
                //Crear funcionario
                FUNCIONARIO funcionario = new FUNCIONARIO();
                funcionario.ID_PERSONAL = personal.ID_PERSONAL;
                funcionario.ID_CARGO_FUNCI= cargo.ID_CARGO_FUNCI;
                cmhEntities.FUNCIONARIO.Add(funcionario);
                cmhEntities.SaveChangesAsync();
                //Crear caja
                CAJA caja = new CAJA();
                caja.FECHOR_APERTURA = DateTime.Now;
                caja.FECHOR_CIERRE = DateTime.Now;
                caja.CANT_EFECTIVO_INI = 100;
                caja.CANT_EFECTIVO_FIN = 100;
                caja.CANT_CHEQUE_FIN = 100;
                caja.ID_FUNCIONARIO = funcionario.ID_FUNCIONARIO;
                cmhEntities.CAJA.Add(caja);
                cmhEntities.SaveChangesAsync();
                //Crear personal
                PERSONAL pers = new PERSONAL();
                pers.RUT = random.Next(999999);
                pers.VERIFICADOR = "C";
                pers.ACTIVO = true;
                cmhEntities.PERSONAL.Add(pers);
                cmhEntities.SaveChangesAsync();
                //Crear personal medico
                PERS_MEDICO persMedico = new PERS_MEDICO();
                persMedico.ID_PERSONAL = pers.ID_PERSONAL;
                cmhEntities.PERS_MEDICO.Add(persMedico);
                cmhEntities.SaveChangesAsync();
                //Crear dia semana
                DIA_SEM diaSem = new DIA_SEM();
                diaSem.NOMBRE_DIA = "Lunes";
                cmhEntities.DIA_SEM.Add(diaSem);
                cmhEntities.SaveChangesAsync();
                //Crear bloque
                BLOQUE bloque = new BLOQUE();
                bloque.ID_DIA_SEM = diaSem.ID_DIA;
                cmhEntities.BLOQUE.Add(bloque);
                cmhEntities.SaveChangesAsync();
                //Crear atencion agendada
                ATENCION_AGEN atencion = new ATENCION_AGEN();
                atencion.ID_PERS_ATIENDE = persMedico.ID_PERSONAL_MEDICO;
                atencion.ID_BLOQUE = bloque.ID_BLOQUE;
                cmhEntities.ATENCION_AGEN.Add(atencion);
                cmhEntities.SaveChangesAsync();
                //Crear pago
                PAGO pago = new PAGO();
                pago.MONTO_PAGO = 100;
                pago.ID_ATENCION_AGEN = atencion.ID_ATENCION_AGEN;
                pago.FECHOR = caja.FECHOR_APERTURA;
                pago.ID_CAJA = caja.ID_CAJA;
                cmhEntities.PAGO.Add(pago);
                cmhEntities.SaveChangesAsync();

                AccionesTerminal accionesTerminal = new AccionesTerminal();
                //Caso 1: reporte caja sin diferencia
                List<ReporteCaja> reportesCaja;
                reportesCaja = accionesTerminal.generarReporteCaja(funcionario, DateTime.Today);
                Assert.IsTrue(reportesCaja.Count() >= 1, "No hay cajas registradas");
                Assert.IsTrue(reportesCaja.First<ReporteCaja>().Diferencia == 0, "Diferencia con la primera caja distinta de 0");
                
                //Caso 2: reporte caja con diferencia
                caja.CANT_EFECTIVO_FIN = 0;
                cmhEntities.SaveChangesAsync();

                reportesCaja = accionesTerminal.generarReporteCaja(funcionario, DateTime.Today);
                Assert.IsTrue(reportesCaja.Count() == 1, "Solo debe haber una caja registrada");
                Assert.IsTrue(reportesCaja.First<ReporteCaja>().Diferencia == 100, "Diferencia no es 100");
                //Caso 3: reporte caja total ventas = 200
                PAGO pago2 = new PAGO();
                pago2.MONTO_PAGO = 100;
                pago2.ID_ATENCION_AGEN = atencion.ID_ATENCION_AGEN;
                pago2.FECHOR = caja.FECHOR_APERTURA;
                pago2.ID_CAJA = caja.ID_CAJA;
                cmhEntities.PAGO.Add(pago2);
                cmhEntities.SaveChangesAsync();
                caja = accionesTerminal.buscarCaja(caja.ID_CAJA);
                reportesCaja = accionesTerminal.generarReporteCaja(funcionario, DateTime.Today);
                int result = reportesCaja.First<ReporteCaja>().TotalVentasConBono();
                Assert.IsTrue( result == 200);
                //Caso 4: caja no existe
                FUNCIONARIO funcionario2 = new FUNCIONARIO();
                funcionario2.ID_PERSONAL = pers.ID_PERSONAL;
                cmhEntities.FUNCIONARIO.Add(funcionario2);
                cmhEntities.SaveChangesAsync();
                try
                {
                    accionesTerminal.generarReporteCaja(funcionario2, DateTime.Now);
                    Assert.Fail();//no deberia tocar esta línea
                }
                catch (Exception)
                {
                }
                //Caso 5: multiples cajas por dia
                CAJA caja2 = new CAJA();
                caja2.FECHOR_APERTURA = DateTime.Now;
                caja2.FECHOR_CIERRE = DateTime.Now;
                caja2.CANT_EFECTIVO_INI = 100;
                caja2.CANT_EFECTIVO_FIN = 100;
                caja2.CANT_CHEQUE_FIN = 100;
                caja2.ID_FUNCIONARIO = funcionario.ID_FUNCIONARIO;
                cmhEntities.CAJA.Add(caja2);
                cmhEntities.SaveChangesAsync();

                List<ReporteCaja> reportesCaja2 = accionesTerminal.generarReporteCaja(funcionario, DateTime.Now);
                Assert.IsTrue(reportesCaja2.Count() == 2);
            }
            
        }
        [TestMethod]
        public void auditarCajaTest()
        {
            using(var cmhEntities = new CMHEntities())
            {
                //Preparar tests
                //Crear cargo
                CARGO cargo = new CARGO();
                cargo.NOMBRE_CARGO = "CargoTest";
                CARGO cargo2 = new CARGO();
                cargo2.NOMBRE_CARGO = "Jefe de operadores";
                cmhEntities.CARGO.Add(cargo);
                cmhEntities.CARGO.Add(cargo2);
                cmhEntities.SaveChangesAsync();
                //Crear personal
                PERSONAL personal = new PERSONAL();
                Random random = new Random();
                personal.RUT = random.Next(999999);
                personal.VERIFICADOR = "C";
                personal.ACTIVO = true;
                PERSONAL personal2= new PERSONAL();
                personal2.RUT = random.Next(999999);
                personal2.VERIFICADOR = "C";
                personal2.ACTIVO = true;
                personal2.EMAIL = "p.delasotta@alumnos.duoc.cl";
                cmhEntities.PERSONAL.Add(personal);
                cmhEntities.PERSONAL.Add(personal2);
                cmhEntities.SaveChangesAsync();
                //Crear funcionario
                FUNCIONARIO funcionario = new FUNCIONARIO();
                funcionario.ID_PERSONAL = personal.ID_PERSONAL;
                funcionario.ID_CARGO_FUNCI = cargo.ID_CARGO_FUNCI;
                cmhEntities.FUNCIONARIO.Add(funcionario);
                FUNCIONARIO funcionario2 = new FUNCIONARIO();
                funcionario2.ID_PERSONAL = personal2.ID_PERSONAL;
                funcionario2.ID_CARGO_FUNCI = cargo2.ID_CARGO_FUNCI;
                cmhEntities.FUNCIONARIO.Add(funcionario2);
                cmhEntities.SaveChangesAsync();
                //Crear caja
                CAJA caja = new CAJA();
                caja.FECHOR_APERTURA = DateTime.Now;
                caja.FECHOR_CIERRE = DateTime.Now;
                caja.CANT_EFECTIVO_INI = 0;
                caja.CANT_EFECTIVO_FIN = 0;
                caja.CANT_CHEQUE_FIN = 0;
                caja.ID_FUNCIONARIO = funcionario.ID_FUNCIONARIO;
                cmhEntities.CAJA.Add(caja);
                cmhEntities.SaveChangesAsync();
                //Crear personal
                PERSONAL pers = new PERSONAL();
                pers.RUT = random.Next(999999);
                pers.VERIFICADOR = "C";
                pers.ACTIVO = true;
                cmhEntities.PERSONAL.Add(pers);
                cmhEntities.SaveChangesAsync();
                //Crear personal medico
                PERS_MEDICO persMedico = new PERS_MEDICO();
                persMedico.ID_PERSONAL = pers.ID_PERSONAL;
                cmhEntities.PERS_MEDICO.Add(persMedico);
                cmhEntities.SaveChangesAsync();
                //Crear dia semana
                DIA_SEM diaSem = new DIA_SEM();
                diaSem.NOMBRE_DIA = "Lunes";
                cmhEntities.DIA_SEM.Add(diaSem);
                cmhEntities.SaveChangesAsync();
                //Crear bloque
                BLOQUE bloque = new BLOQUE();
                bloque.ID_DIA_SEM = diaSem.ID_DIA;
                cmhEntities.BLOQUE.Add(bloque);
                cmhEntities.SaveChangesAsync();
                //Crear atencion agendada
                ATENCION_AGEN atencion = new ATENCION_AGEN();
                atencion.ID_PERS_ATIENDE = persMedico.ID_PERSONAL_MEDICO;
                atencion.ID_BLOQUE = bloque.ID_BLOQUE;
                cmhEntities.ATENCION_AGEN.Add(atencion);
                cmhEntities.SaveChangesAsync();
                //Crear pago
                PAGO pago = new PAGO();
                pago.MONTO_PAGO = 100;
                pago.ID_ATENCION_AGEN = atencion.ID_ATENCION_AGEN;
                pago.FECHOR = caja.FECHOR_APERTURA;
                pago.ID_CAJA = caja.ID_CAJA;
                cmhEntities.PAGO.Add(pago);
                cmhEntities.SaveChangesAsync();

                AccionesTerminal accionesTerminal = new AccionesTerminal();
                int result = accionesTerminal.auditarCaja(caja, cargo2);
                int expectedResult = 1;
                Assert.IsTrue(result >= expectedResult, "Fueron enviados menos de 1 mail");
            }
            
        }
        #endregion

        #region Agregar entrada de ficha
        [TestMethod]
        public void agregarEntradaFichaTest()
        {
            //CASO 1: Entrada ficha correcta
            using (var cmhEntities = new CMHEntities())
            {
                //Atención terminal
                AccionesTerminal at = new AccionesTerminal();

                //Paciente
                PACIENTE paciente1 = crearPaciente();

                //Tipo_Ficha
                TIPO_FICHA tipo_ficha1 = new TIPO_FICHA();
                tipo_ficha1.NOM_TIPO_FICHA = "TestAgregarEntradaFicha";
                cmhEntities.TIPO_FICHA.Add(tipo_ficha1);
                cmhEntities.SaveChangesAsync();

                //Entrada_Ficha
                ENTRADA_FICHA entrada_ficha1 = new ENTRADA_FICHA();
                entrada_ficha1.NOMBRE_ENTRADA = "COD-1";
                entrada_ficha1.CONTENIDO_ENTRADA = "Contenido Entrada";
                entrada_ficha1.FECHA_ENTRADA = DateTime.Today;
                entrada_ficha1.ID_PACIENTE = paciente1.ID_PACIENTE;
                entrada_ficha1.ID_TIPO_FICHA = tipo_ficha1.ID_TIPO_FICHA;

                Boolean res1 = at.agregarEntradaFicha(entrada_ficha1);
                Boolean resultadoEsperado1 = true;
                Assert.AreEqual(res1, resultadoEsperado1);

            }
            
        }
        #endregion

        #region devolución
        [TestMethod]
        public void DevolucionPagoTest()
        {
            AccionesTerminal at = new AccionesTerminal();
            PAGO pago = new PAGO();
            using (CMHEntities cmhEntities = new CMHEntities())
            {
                pago = cmhEntities.PAGO.Where(d => d.ID_PAGO == d.ID_PAGO).FirstOrDefault();
                if (pago == null)
                {
                    return;
                }
                pago.ID_DEVOLUCION = null;
                cmhEntities.SaveChangesAsync();
            }
            //Se genera la devolución
            bool result = at.devolverPago(pago, "Test");
            Assert.AreEqual(result, true); //Si documento esta linea funciona
            //No generara la devolución por que ya existe
            result = at.devolverPago(pago, "Test");
            Assert.AreEqual(result, false);
            //Pago no valido
            PAGO pagoaux = null;
            result = at.devolverPago(pagoaux, "Test");
            Assert.AreEqual(result, false);
            //Revertir cambios
            using (CMHEntities cmhEntities = new CMHEntities())
            {
                pago = cmhEntities.PAGO.Where(d => d.ID_PAGO == d.ID_PAGO).FirstOrDefault();
                DEVOLUCION devo = pago.DEVOLUCION;
                pago.ID_DEVOLUCION = null;
                cmhEntities.DEVOLUCION.Remove(devo);
                cmhEntities.SaveChangesAsync();
            }
        }
        #endregion
    }
}
