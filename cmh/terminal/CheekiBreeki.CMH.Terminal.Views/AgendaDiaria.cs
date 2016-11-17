using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheekiBreeki.CMH.Terminal.Views
{
    public class AgendaDiaria
    {
        public string TipoAtencion { get; set; }
        public string Paciente { get; set; }
        public string HoraAtencion { get; set; }
        public bool Realizado { get; set; }

        public AgendaDiaria(string tipoAtencion, string paciente, string horaAtencion, bool realizado)
        {
            this.TipoAtencion = tipoAtencion;
            this.Paciente = paciente;
            this.HoraAtencion = horaAtencion;
            this.Realizado = realizado;
        }
    }
}
