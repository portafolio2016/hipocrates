using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheekiBreeki.CMH.Terminal.DAL;
using System.Collections.Generic;
namespace CheekiBreeki.CMH.Terminal.BL
{
    public class AccionesTerminal
    {
        Entities conexionDB = new Entities();

        //ECU-001
        public Boolean agendarAtencion(ATENCION_AGEN atencion)
        {
            //TODO: implementar
            return false;
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
        public Boolean crearFichaMedica(FICHA ficha)
        {
            //TODO: implementar
            return false;
        }

        //ECU-010
        public Boolean actualizarFichaMedica(FICHA ficha)
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
            //TODO: implementar
            return false;
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

        //ECU-022
        public Boolean actualizarInventarioEquipo(INVENTARIO inventario)
        {
            //TODO: implementar
            return false;
        }

        public Boolean nuevoEquipo(TIPO_EQUIPO tipoEquipo)
        {
            //TODO: implementar
            return false;
        }

        public Boolean borrarEquipo(TIPO_EQUIPO tipoEquipo)
        {
            //TODO: implementar
            return false;
        }

        //ECU-023 y ECU-026
        #region Funcionarios
        public Boolean nuevoPersonal(FUNCIONARIO funcionario)
        {
            //TODO: Implementar
            return false;
        }

        public FUNCIONARIO buscarPersonal(Object id)
        {
            //TODO: Implementar
            return null;
        }

        public Boolean actualizarPersonal(FUNCIONARIO funcionario)
        {
            //TODO: implementar
            return false;
        }

        public Boolean borrarPersonal(FUNCIONARIO funcionario)
        {
            //TODO: Implementar
            return false;
        }
        
        #endregion

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

        public PERSONAL buscarPersonal(int id)
        {
            try
            {
                if (Util.isObjetoNulo(id))
                {
                    throw new Exception("ID verificador nulo");
                }
                else
                {
                    PERSONAL personal = null;
                    personal = conexionDB.PERSONAL.Find(id);
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


        //ECU-024
        #region TODO: Prestación médica
        public Boolean nuevaPrestacionMedica(PRESTACION prestacion)
        {
            //TODO: implementar
            return false;
        }

        public PRESTACION buscarPrestacionMedica(int id)
        {
            //TODO: implementar
            return null;
        }

        public Boolean actualizarPrestacionesMedicas(PRESTACION prestacion)
        {
            //TODO: implementar
            return false;
        }

        public Boolean borrarPrestacionMedica(PRESTACION prestacion)
        {
            //TODO: implementar
            return false;
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
