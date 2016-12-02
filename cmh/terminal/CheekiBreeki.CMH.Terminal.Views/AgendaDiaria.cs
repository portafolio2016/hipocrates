using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheekiBreeki.CMH.Terminal.Views
{
    public class AgendaDiaria
    {
        [DisplayName("Tipo de atención")]
        public string TipoAtencion { get; set; }
        [DisplayName("Paciente")]
        public string Paciente { get; set; }
        [DisplayName("Hora de atención")]
        public string HoraAtencion { get; set; }
        [DisplayName("Atención realizada")]
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
