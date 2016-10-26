using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheekiBreeki.CMH.Terminal.DAL;
namespace CheekiBreeki.CMH.Terminal.BL
{
    public class AccionesTerminal
    {
        CMHEntities conexionDB = new CMHEntities();

        //ECU-001
        public Boolean agendarAtencion(ATENCION_AGEN atencion)
        {
            //Al generar una orden de análisis, tiene que ir relacionada con una atencion
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

        //ECU-003
        public Boolean registrarPaciente(PACIENTE paciente)
        {
            //TODO: implementar
            return false;
        }

        //ECU-005
        public List<ATENCION_AGEN> revisarAgendaDiaria(PERS_MEDICO personalMedico, DateTime dia)
        {
            List<ATENCION_AGEN> atenciones = null;
            //TODO: implementar
            return atenciones;
        }

        //ECU-006
        public Boolean ingresarPaciente(ATENCION_AGEN atencion)
        {
            //TODO: implementar
            return false;
        }

        //ECU-007
        public ResultadoVerificacionSeguro verificarSeguro(ATENCION_AGEN atencion)
        {
            ResultadoVerificacionSeguro resultadoVerificacionSeguro = null;
            //TODO: implementar
            return resultadoVerificacionSeguro;
        }

        //ECU-008
        public Boolean registrarPago(PAGO pago, CAJA caja)
        {
            //TODO: implementar
            return false;
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
        public Boolean generarOrdenDeAnalisis(ATENCION_AGEN atencion, ORDEN_ANALISIS ordenAnalisis)
        {
            //TODO: implementar
            return false;
        }

        //ECU-013
        public Boolean cerrarOrdenDeAnalisis(ORDEN_ANALISIS ordenAnalisis)
        {
            //TODO: implementar
            return false;
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
        public Boolean abrirCaja(CAJA caja, FUNCIONARIO funcionario)
        {
            //TODO: implementar
            return false;
        }

        //ECU-018
        public Boolean cerrarCaja(CAJA caja, FUNCIONARIO funcionario)
        {
            //TODO: implementar
            return false;
        }

        //ECU-019
        public ReporteCaja generarReporteCaja(FUNCIONARIO funcionario, DateTime dia)
        {
            //TODO: implementar
            ReporteCaja reporteCaja = null;
            return reporteCaja;
        }
        
        public Boolean actualizarInventarioEquipo(INVENTARIO inventario)
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
                else if (prestacion.CODIGO_PRESTACION == null || prestacion.CODIGO_PRESTACION == "")
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
