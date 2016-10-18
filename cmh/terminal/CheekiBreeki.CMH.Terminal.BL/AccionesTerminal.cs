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
        public Boolean actualizarPersonal(PERS_MEDICO personalMedico)
        {
            //TODO: Implementar
            return false;
        }

        public Boolean actualizarPersonal(FUNCIONARIO funcionario)
        {
            //TODO: implementar
            return false;
        }

        public Boolean nuevoPersonal(FUNCIONARIO funcionario)
        {
            //TODO: Implementar
            return false;
        }
        public Boolean nuevoPersonal(PERS_MEDICO personalMedico)
        {
            //TODO: Implementar
            return false;
        }

        public Boolean borrarPersonal(FUNCIONARIO funcionario)
        {
            //TODO: Implementar
            return false;
        }

        public Boolean borrarPersonal(PERS_MEDICO personalMedico)
        {
            //TODO: Implementar
            return false;
        }

        //ECU-024
        public Boolean actualizarPrestacionesMedicas(PRESTACION prestacion)
        {
            //TODO: implementar
            return false;
        }

        public Boolean nuevaPrestacionMedica(PRESTACION prestacion)
        {
            //TODO: implementar
            return false;
        }

        public Boolean borrarPrestacionMedica(PRESTACION prestacion)
        {
            //TODO: implementar
            return false;
        }

        //ECU-025
        public Boolean actualizarPacientes(PACIENTE paciente)
        {
            //TODO: implementar
            return false;
        }

        public Boolean nuevoPaciente(PACIENTE paciente)
        {
            //TODO: implementar
            return false;
        }

        public Boolean borrarPaciente(PACIENTE paciente)
        {
            //TODO: implementar
            return false;
        }

        
    }
}
