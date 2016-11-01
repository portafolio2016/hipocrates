using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheekiBreeki.CMH.Terminal.DAL;
using CheekiBreeki.CMH.Terminal.BL.SeguroServiceReference;
namespace CheekiBreeki.CMH.Terminal.BL
{
    public class AccionesTerminal
    {
        CMHEntities conexionDB = new CMHEntities();

        //ECU-001
        public Boolean agendarAtencion(ATENCION_AGEN atencion)
        {
            
            try
            {
                if (Util.isObjetoNulo(atencion))
                {
                    throw new Exception("Atencion invalida");
                }
                else if (atencion.FECHOR == DateTime.MinValue || 
                         atencion.FECHOR == null)
                {
                    throw new Exception("Fecha vacía");
                }
                else if (atencion.OBSERVACIONES == String.Empty ||
                         atencion.OBSERVACIONES == null)
                {
                    throw new Exception("Observacion vacia");
                }
                else
                {
                    conexionDB.ATENCION_AGEN.Add(atencion);
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //ECU-005
        public List<ATENCION_AGEN> revisarAgendaDiaria(int rut, DateTime dia)
        {
            
            try
            {
                if (Util.isObjetoNulo(dia))
                {
                    throw new Exception("Día vacío");
                }
                else if (Util.isObjetoNulo(buscarPersonal(rut)))
                {
                    throw new Exception("Personal no existe");
                }
                else
                {
                    List<ATENCION_AGEN> atenciones = null;
                    atenciones = conexionDB.ATENCION_AGEN.
                        Where(d => d.PERS_MEDICO.PERSONAL.RUT == rut &&
                              d.FECHOR == dia).ToList();
                    return atenciones;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //ECU-006
        public Boolean ingresarPaciente(ATENCION_AGEN atencion)
        {
            try
            {
                if (Util.isObjetoNulo(atencion))
                {
                    throw new Exception("Atención nula");
                }
                if (atencion.ESTADO_ATEN.NOM_ESTADO_ATEN != "Vigente")
                {
                    throw new Exception("Estado no válido de la atención");
                }
                else if (Util.isObjetoNulo(conexionDB.ATENCION_AGEN.Find(atencion.ID_ATENCION_AGEN)))
                {
                    throw new Exception("Atención agendada no existe");
                }
                else
                {
                    ATENCION_AGEN atencionFinal = conexionDB.ATENCION_AGEN.Find(atencion.ID_ATENCION_AGEN);
                    atencionFinal.ID_ESTADO_ATEN = conexionDB.ESTADO_ATEN.Where(d => d.NOM_ESTADO_ATEN == "En proceso").FirstOrDefault().ID_ESTADO_ATEN;
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //ECU-007
        public ResultadoVerificacionSeguro verificarSeguro(PRESTACION prestacion, PACIENTE paciente)
        {

            int precioPrestacion = prestacion.PRECIO_PRESTACION.Value;
            int rutPaciente = paciente.RUT;
            SeguroWSClient client = new SeguroWSClient();
            SeguroRequest request = new SeguroRequest();
            request.AfiliadoRut = paciente.RUT;
            request.CodigoPrestacion = prestacion.CODIGO_PRESTACION;
            Task<SeguroResponse> tResponse = client.obtenerDescuentoAsync(request);
            tResponse.Wait();
            SeguroResponse response = tResponse.Result;
            ResultadoVerificacionSeguro resultado = new ResultadoVerificacionSeguro();
            resultado.TieneSeguro = response.AfiliadoTieneSeguro;
            resultado.Descuento = response.DescuentoPesos;
            return resultado;
        }

        //ECU-008
        public Boolean registrarPago(PAGO pago)
        {
            try
            {
                if (Util.isObjetoNulo(pago))
                {
                    throw new Exception("Pago nulo");
                }
                else if (Util.isObjetoNulo(conexionDB.BONO.Find(pago.ID_BONO)))
                {
                    throw new Exception("Bono no existe");
                }
                else if (Util.isObjetoNulo(conexionDB.CAJA.Find(pago.ID_CAJA)))
                {
                    throw new Exception("Caja no existe");
                }
                else if (Util.isObjetoNulo(conexionDB.ATENCION_AGEN.Find(pago.ID_ATENCION_AGEN)))
                {
                    throw new Exception("Atención agendada no existe");
                }
                else
                {
                    conexionDB.PAGO.Add(pago);
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //ECU-009
        //public Boolean crearFichaMedica(FICHA ficha)
        //{
        //    //TODO: implementar
        //    return false;
        //}

        //ECU-010
        public Boolean actualizarFichaMedica(PACIENTE paciente, ENTRADA_FICHA entradaFicha)
        {
            //TODO: implementar
            return false;
        }

        //ECU-011
        public Boolean cerrarConsultaMedica(RES_ATENCION resultadoAtencion)
        {
            //TODO: implementar
            return false;
        }

        //ECU-012
        public Boolean generarOrdenDeAnalisis(ATENCION_AGEN atencion, RES_ATENCION resultadoAtencion) 
        {
            try
            {
                if (Util.isObjetoNulo(atencion))
                {
                    throw new Exception("Atencion agendada nula");
                }

                else if (atencion.FECHOR == null)
                {
                    throw new Exception("Fecha nula");
                }

                else if (atencion.OBSERVACIONES == null || atencion.OBSERVACIONES == String.Empty)
                {
                    throw new Exception("Observacion nula o vacía");
                }

                else if (resultadoAtencion.ID_ATENCION_AGEN == null)
                {
                    throw new Exception("ID de atencion agendada es nulo");
                }

                else if (resultadoAtencion.ID_ORDEN_ANALISIS == null)
                {
                    throw new Exception("ID de orden de analisis es nulo");
                }
                
                else
                {
                    ORDEN_ANALISIS ordenAnalisis = new ORDEN_ANALISIS();
                    ordenAnalisis.FECHOR_EMISION = DateTime.Today;
                    conexionDB.ORDEN_ANALISIS.Add(ordenAnalisis);
                    conexionDB.SaveChangesAsync();

                    resultadoAtencion.ID_ATENCION_AGEN = atencion.ID_ATENCION_AGEN;
                    resultadoAtencion.ID_ORDEN_ANALISIS = ordenAnalisis.ID_ORDEN_ANALISIS;
                    conexionDB.RES_ATENCION.Add(resultadoAtencion);
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //ECU-013
        public Boolean cerrarOrdenDeAnalisis(ORDEN_ANALISIS ordenAnalisis)
        {
            try
            {
                if (Util.isObjetoNulo(ordenAnalisis))
                {
                    throw new Exception("Orden nula");
                }

                else if (ordenAnalisis.FECHOR_RECEP <= DateTime.Today)
                {
                    throw new Exception("Fecha invalida");
                }

                else
                {
                    ordenAnalisis = conexionDB.ORDEN_ANALISIS.Find(ordenAnalisis.ID_ORDEN_ANALISIS);
                    ordenAnalisis.FECHOR_RECEP = DateTime.Today;
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }


        }

        //ECU-014
        public List<ATENCION_AGEN> revisarNotificaciones(PERS_MEDICO personalMedico)
        {
            List<ATENCION_AGEN> atenciones = null;
            //TODO: implementar
            return atenciones;
        }

        //ECU-016
        public Boolean anularAtencion(ATENCION_AGEN atencion)
        {
            
            try
            {
                if (Util.isObjetoNulo(atencion))
                {
                    throw new Exception("Atencion invalida");
                }
                else if (atencion.FECHOR == DateTime.MinValue ||
                         atencion.FECHOR == null)
                {
                    throw new Exception("Fecha vacía");
                }
                else if (atencion.OBSERVACIONES == String.Empty ||
                         atencion.OBSERVACIONES == null)
                {
                    throw new Exception("Observacion vacia");
                }
                else
                {
                    ESTADO_ATEN estadoatencion = new ESTADO_ATEN();
                    estadoatencion.NOM_ESTADO_ATEN = "Anulado";
                    estadoatencion = conexionDB.ESTADO_ATEN.Where(d => d.NOM_ESTADO_ATEN == estadoatencion.NOM_ESTADO_ATEN).FirstOrDefault();
                    atencion.ID_ESTADO_ATEN = estadoatencion.ID_ESTADO_ATEN;
                    conexionDB.ATENCION_AGEN.Add(atencion);
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        
        //ECU-017
        /// <summary>
        /// Se registra una caja con el respectivo funcionario que la abrio.
        /// </summary>
        /// <param name="caja">La caja</param>
        /// <param name="funcionario">Funcionario que abre la caja</param>
        /// <returns>Si es true la caja fue abierta con exito</returns>
        #region  Abrir Caja
        public Boolean abrirCaja(CAJA caja, FUNCIONARIO funcionario)
        {
            try
            {
                if (Util.isObjetoNulo(caja))
                {
                    throw new Exception("Caja nula.");
                }
                else if (Util.isObjetoNulo(buscarFuncionario(funcionario.ID_CARGO_FUNCI, funcionario.ID_PERSONAL)))
                {
                    throw new Exception("Funcionario no encontrado.");
                }
                else
                {
                    conexionDB.CAJA.Add(caja);
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        #endregion

        /// <summary>
        /// Busca una caja entre las cajas existentes.
        /// </summary>
        /// <param name="idCaja">Id de la caja que se quiere buscar</param>
        /// <returns>La caja encontrada, si es null la caja no se encontro</returns>
        #region Buscar caja
        public CAJA buscarCaja(int idCaja)
        {
            try
            {
                CAJA caja = null;
                caja = conexionDB.CAJA.Where(d => d.ID_CAJA == idCaja).FirstOrDefault();
                if (Util.isObjetoNulo(caja))
                {
                    throw new Exception("Caja no existe");
                }
                return caja;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        #endregion

        //ECU-018
        /// <summary>
        /// Metodo que cierra una caja. 
        /// Este metodo utiliza el metodo de buscar caja para verificar que esta exista previamente.
        /// </summary>
        /// <param name="caja">Caja que se quiere cerrar</param>
        /// <param name="fechor_cierre">Fecha en la que se cierra la caja</param>
        /// <returns>Si es true la caja fue cerrada con exito</returns>
        #region Cerrar Caja
        public Boolean cerrarCaja(CAJA caja, DateTime fechor_cierre)
        {
            try
            {
                //Verificar si caja existe
                bool cajaNula = Util.isObjetoNulo(buscarCaja(caja.ID_CAJA));
                if (cajaNula)
                {
                    throw new Exception("Caja nulo");
                }
                    //VERIFICAR HORA DE CIERRE PARA VER SI ESTA CERRADA O NO
                else if (caja.FECHOR_APERTURA == null)
                {
                    throw new Exception("Fecha y hora apertura nula");
                }
                else 
                {
                   if (caja.FECHOR_CIERRE == null)
                   {
                       //caja.FECHOR_CIERRE = fechor_cierre;
                       CAJA cajaUpdate = null;
                       cajaUpdate = buscarCaja(caja.ID_CAJA);
                       cajaUpdate.FECHOR_CIERRE = fechor_cierre;
                       conexionDB.SaveChangesAsync();
                   }
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion

        //ECU-019
        public ReporteCaja generarReporteCaja(FUNCIONARIO funcionario, DateTime dia)
        {
            //TODO: implementar
            ReporteCaja reporteCaja = null;
            return reporteCaja;
        }
        
        public Boolean orualizarInventarioEquipo(INVENTARIO inventario)

        {
            //TODO: implementar
            return false;
        }

        //ECU-022
        #region Equipos
        public Boolean nuevoEquipo(TIPO_EQUIPO equipo)
        {
            try
            {
                if (Util.isObjetoNulo(equipo))
                {
                    throw new Exception("Personal nulo");
                }
                else if (equipo.NOMBRE_TIPO_EQUIPO == null ||
                         equipo.NOMBRE_TIPO_EQUIPO == String.Empty)
                {
                    throw new Exception("Nombre vacío");
                }
                else if (!Util.isObjetoNulo(buscarEquipo(equipo.NOMBRE_TIPO_EQUIPO)))
                {
                    throw new Exception("Equipo ya ingresado");
                }
                else
                {
                    conexionDB.TIPO_EQUIPO.Add(equipo);
                    Task<int> insercion = conexionDB.SaveChangesAsync();
                    insercion.Wait();

                    INVENTARIO inventario = new INVENTARIO();
                    inventario.CANT_BODEGA = 0;
                    inventario.ID_TIPO_EQUIPO = buscarEquipo(equipo.NOMBRE_TIPO_EQUIPO).ID_TIPO_EQUIPO;
                    conexionDB.INVENTARIO.Add(inventario);
                    conexionDB.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public TIPO_EQUIPO buscarEquipo(string nombre)
        {
            try
            {
                if (Util.isObjetoNulo(nombre))
                {
                    throw new Exception("Nombre nulo");
                }
                else
                {
                    TIPO_EQUIPO equipo = null;
                    equipo = conexionDB.TIPO_EQUIPO.Where(d => d.NOMBRE_TIPO_EQUIPO == nombre)
                                                         .FirstOrDefault();
                    if (Util.isObjetoNulo(equipo))
                    {
                        throw new Exception("Equipo no existe");
                    }
                    return equipo;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Boolean actualizarEquipoCantidad(string nombre, int cantidad)
        {
            try
            {
                if (Util.isObjetoNulo(nombre))
                {
                    throw new Exception("Nombre nulo");
                }
                else
                {
                    TIPO_EQUIPO equipo = null;
                    equipo = conexionDB.TIPO_EQUIPO.Where(d => d.NOMBRE_TIPO_EQUIPO == nombre)
                                                         .FirstOrDefault();
                    if (Util.isObjetoNulo(equipo))
                    {
                        throw new Exception("Equipo no existe");
                    }

                    INVENTARIO inventario = conexionDB.INVENTARIO.Where(d => d.ID_TIPO_EQUIPO == equipo.ID_TIPO_EQUIPO)
                                                                        .FirstOrDefault();
                    if (Util.isObjetoNulo(inventario))
                    {
                        throw new Exception("Inventario no existe");
                    }
                    inventario.CANT_BODEGA = cantidad;
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Boolean borrarEquipo(TIPO_EQUIPO equipo)
        {
            try
            {
                if (Util.isObjetoNulo(equipo))
                {
                    throw new Exception("Paciente no existe");
                }
                else
                {
                    conexionDB.TIPO_EQUIPO.Remove(equipo);
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion

        //ECU-023 y ECU-026
        #region Personal
        public Boolean nuevoPersonal(PERSONAL personal)
        {
            try
            {
                if (Util.isObjetoNulo(personal))
                {
                    throw new Exception("Personal nulo");
                }
                else if (personal.NOMBRES == null ||
                         personal.APELLIDOS == null ||
                         personal.NOMBRES == String.Empty ||
                         personal.APELLIDOS == String.Empty)
                {
                    throw new Exception("Nombre o apellido vacío");
                }
                else if (personal.RUT == null || personal.RUT == 0)
                {
                    throw new Exception("RUT vacío");
                }
                else if (!Util.isObjetoNulo(buscarPersonal(personal.RUT, personal.VERIFICADOR)))
                {
                    throw new Exception("Personal ya ingresado");
                }
                else
                {
                    conexionDB.PERSONAL.Add(personal);
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public PERSONAL buscarPersonal(int rut)
        {
            try
            {
                if (Util.isObjetoNulo(rut))
                {
                    throw new Exception("RUT o vacío");
                }
                else
                {
                    PERSONAL personal = null;
                    personal = conexionDB.PERSONAL.Where(d => d.RUT == rut).FirstOrDefault();
                    if (Util.isObjetoNulo(personal))
                    {
                        throw new Exception("Personal no existe");
                    }
                    return personal;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public PERSONAL buscarPersonal(int rut, string dv)
        {
            try
            {
                if (Util.isObjetoNulo(rut) || Util.isObjetoNulo(dv))
                {
                    throw new Exception("RUT o dígito verificador nulo");
                }
                else
                {
                    PERSONAL personal = null;
                    personal = conexionDB.PERSONAL.Where(d => d.RUT == rut
                                                         && d.VERIFICADOR == dv)
                                                         .FirstOrDefault();
                    if (Util.isObjetoNulo(personal))
                    {
                        throw new Exception("Personal no existe");
                    }
                    return personal;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Boolean actualizarPersonal(PERSONAL personal)
        {
            try
            {
                if (Util.isObjetoNulo(personal))
                {
                    throw new Exception("Personal nulo");
                }
                else if (personal.NOMBRES == null ||
                         personal.APELLIDOS == null ||
                         personal.NOMBRES == String.Empty ||
                         personal.APELLIDOS == String.Empty)
                {
                    throw new Exception("Nombre o apellido vacío");
                }
                else
                {
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Boolean borrarPersonal(PERSONAL personal)
        {
            try
            {
                if (Util.isObjetoNulo(personal))
                {
                    throw new Exception("Paciente no existe");
                }
                else
                {
                    conexionDB.PERSONAL.Remove(personal);
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion

        #region Funcionarios
        public Boolean nuevoFuncionario(FUNCIONARIO funcionario)
        {
            try
            {
                if (Util.isObjetoNulo(funcionario))
                {
                    throw new Exception("Funcionario nulo");
                }
                else if (funcionario.ID_CARGO_FUNCI == null ||
                         funcionario.ID_CARGO_FUNCI == 0 ||
                         funcionario.ID_PERSONAL == null ||
                         funcionario.ID_PERSONAL == 0)
                {
                    throw new Exception("Cargo o personal no vacío");
                }
                else if (Util.isObjetoNulo(conexionDB.CARGO.Find(funcionario.ID_CARGO_FUNCI)))
                {
                    throw new Exception("Cargo no existe");
                }
                else if (!Util.isObjetoNulo(buscarFuncionario(funcionario.ID_CARGO_FUNCI, funcionario.ID_PERSONAL)))
                {
                    throw new Exception("Funcionario ya ingresado");
                }
                else
                {
                    conexionDB.FUNCIONARIO.Add(funcionario);
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public FUNCIONARIO buscarFuncionario(int cargo, int personal)
        {
            try
            {
                if (Util.isObjetoNulo(cargo) || Util.isObjetoNulo(personal))
                {
                    throw new Exception("Cargo o personal nulo");
                }
                else
                {
                    FUNCIONARIO funcionario = null;
                    funcionario = conexionDB.FUNCIONARIO.Where(d => d.ID_CARGO_FUNCI == cargo
                                                         && d.ID_PERSONAL == personal)
                                                         .FirstOrDefault();
                    if (Util.isObjetoNulo(funcionario))
                    {
                        throw new Exception("Funcionario no existe");
                    }
                    return funcionario;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Boolean actualizarFuncionario(FUNCIONARIO funcionario)
        {
            try
            {
                if (Util.isObjetoNulo(funcionario))
                {
                    throw new Exception("Funcionario nulo");
                }
                else if (funcionario.ID_CARGO_FUNCI == null ||
                         funcionario.ID_CARGO_FUNCI == 0 ||
                         funcionario.ID_PERSONAL == null ||
                         funcionario.ID_PERSONAL == 0)
                {
                    throw new Exception("Cargo o personal no vacío");
                }
                else if (Util.isObjetoNulo(conexionDB.CARGO.Find(funcionario.ID_CARGO_FUNCI)))
                {
                    throw new Exception("Cargo no existe");
                }
                else
                {
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Boolean borrarFuncionario(FUNCIONARIO funcionario)
        {
            try
            {
                if (Util.isObjetoNulo(funcionario))
                {
                    throw new Exception("Funcionario no existe");
                }
                else
                {
                    conexionDB.FUNCIONARIO.Remove(funcionario);
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion

        //ECU-024
        #region Prestación médica
        public Boolean nuevaPrestacionMedica(PRESTACION prestacion)
        {
            try
            {
                if (Util.isObjetoNulo(prestacion))
                {
                    throw new Exception("Prestación nula");
                }
                else if (prestacion.NOM_PRESTACION == null ||
                         prestacion.NOM_PRESTACION == String.Empty ||
                         prestacion.PRECIO_PRESTACION == null)
                {
                    throw new Exception("Nombre, código o precio vacío");
                }
                else if (prestacion.CODIGO_PRESTACION == null ||
                         prestacion.CODIGO_PRESTACION == string.Empty ||
                         Util.isObjetoNulo(prestacion.CODIGO_PRESTACION))
                {
                    throw new Exception("Código vacío");
                }
                else if (prestacion.ID_TIPO_PRESTACION == null)
                {
                    throw new Exception("Tipo de prestación vacío");
                }
                else if (prestacion.ID_ESPECIALIDAD == null)
                {
                    throw new Exception("Especialidad vacío");
                }
                else if (!Util.isObjetoNulo(buscarPrestacionMedica(prestacion.CODIGO_PRESTACION)))
                {
                    throw new Exception("Prestación ya ingresada");
                }
                else
                {
                    conexionDB.PRESTACION.Add(prestacion);
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public PRESTACION buscarPrestacionMedica(string codigo)
        {
            try
            {
                if (Util.isObjetoNulo(codigo))
                {
                    throw new Exception("ID verificador nulo");
                }
                else
                {
                    PRESTACION prestacion = null;
                    prestacion = conexionDB.PRESTACION.Where(d => d.CODIGO_PRESTACION == codigo)
                                                         .FirstOrDefault();
                    if (Util.isObjetoNulo(prestacion))
                    {
                        throw new Exception("Personal no existe");
                    }
                    return prestacion;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Boolean actualizarPrestacionesMedicas(PRESTACION prestacion)
        {
            try
            {
                if (Util.isObjetoNulo(prestacion))
                {
                    throw new Exception("Prestación nula");
                }
                else if (prestacion.NOM_PRESTACION == null ||
                         prestacion.NOM_PRESTACION == String.Empty ||
                         prestacion.PRECIO_PRESTACION == null)
                {
                    throw new Exception("Nombre, código o precio vacío");
                }
                else if (prestacion.CODIGO_PRESTACION == null || prestacion.CODIGO_PRESTACION == String.Empty)
                {
                    throw new Exception("Código vacío");
                }
                else if (prestacion.ID_TIPO_PRESTACION == null)
                {
                    throw new Exception("Tipo de prestación vacío");
                }
                else
                {
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Boolean borrarPrestacionMedica(PRESTACION prestacion)
        {
            try
            {
                if (Util.isObjetoNulo(prestacion))
                {
                    throw new Exception("Prestacion no existe");
                }
                else
                {
                    conexionDB.PRESTACION.Remove(prestacion);
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion

        //ECU-025
        #region Paciente
        public Boolean nuevoPaciente(PACIENTE paciente)
        {
            try
            {
                if (Util.isObjetoNulo(paciente))
                {
                    throw new Exception("Paciente nulo");
                }
                else if (paciente.NOMBRES_PACIENTE == null ||
                         paciente.APELLIDOS_PACIENTE == null ||
                         paciente.NOMBRES_PACIENTE == String.Empty ||
                         paciente.APELLIDOS_PACIENTE == String.Empty)
                {
                    throw new Exception("Nombre o apellido vacío");
                }
                else if (paciente.EMAIL_PACIENTE == null || paciente.EMAIL_PACIENTE == String.Empty)
                {
                    throw new Exception("Email vacío");
                }
                else if (paciente.RUT == null || paciente.RUT == 0)
                {
                    throw new Exception("RUT vacío");
                }
                else if (!Util.isObjetoNulo(buscarPaciente(paciente.RUT, paciente.DIGITO_VERIFICADOR)))
                {
                    throw new Exception("Paciente ya ingresado");
                }
                else
                {
                    conexionDB.PACIENTE.Add(paciente);
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public PACIENTE buscarPaciente(int rut, string dv)
        {
            try
            {
                if (Util.isObjetoNulo(rut) || Util.isObjetoNulo(dv))
                {
                    throw new Exception("RUT o dígito verificador nulo");
                }
                else
                {
                    PACIENTE paciente = null;
                    paciente = conexionDB.PACIENTE.Where(d => d.RUT == rut
                                                         && d.DIGITO_VERIFICADOR == dv)
                                                         .FirstOrDefault();
                    if (Util.isObjetoNulo(paciente))
                    {
                        throw new Exception("Paciente no existe");
                    }
                    return paciente;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Boolean actualizarPaciente(PACIENTE paciente)
        {
            try
            {
                if (Util.isObjetoNulo(paciente))
                {
                    throw new Exception("Paciente nulo");
                }
                else if (paciente.NOMBRES_PACIENTE == null ||
                         paciente.APELLIDOS_PACIENTE == null ||
                         paciente.NOMBRES_PACIENTE == String.Empty ||
                         paciente.APELLIDOS_PACIENTE == String.Empty)
                {
                    throw new Exception("Nombre o apellido vacío");
                }
                else if (paciente.EMAIL_PACIENTE == null || paciente.EMAIL_PACIENTE == String.Empty)
                {
                    throw new Exception("Email vacío");
                }
                else if (paciente.RUT == null || paciente.RUT == 0)
                {
                    throw new Exception("RUT vacío");
                }
                else if (Util.isObjetoNulo(buscarPaciente(paciente.RUT, paciente.DIGITO_VERIFICADOR)))
                {
                    throw new Exception("Paciente no existe");
                }
                else
                {
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Boolean borrarPaciente(PACIENTE paciente)
        {
            try
            {
                if (Util.isObjetoNulo(paciente))
                {
                    throw new Exception("Paciente no existe");
                }
                else
                {
                    conexionDB.PACIENTE.Remove(paciente);
                    conexionDB.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion


     
    }
}
