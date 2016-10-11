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
 
    }
}
