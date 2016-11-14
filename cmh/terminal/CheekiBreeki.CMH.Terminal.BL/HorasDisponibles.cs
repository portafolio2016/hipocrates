using CheekiBreeki.CMH.Terminal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheekiBreeki.CMH.Terminal.BL
{
    public class HorasDisponibles
    {
        private List<HoraDisponible> horas;

        public HorasDisponibles()
        {
            this.horas = new List<HoraDisponible>();
        }

        public bool bloqueDisponible(BLOQUE bloque)
        {
            foreach (HoraDisponible hora in this.horas)
            {
                if (hora.Bloque.ID_BLOQUE == bloque.ID_BLOQUE)
                {
                    return true;
                }
            }
            return false;
        }

        public HorasDisponibles(DateTime date, List<BLOQUE> bloques)
        {
            this.horas = new List<HoraDisponible>();
            foreach (BLOQUE bloque in bloques)
            {
                this.horas.Add(new HoraDisponible(date, bloque));
            }
        }

        public List<HoraDisponible> getHoras()
        {
            return horas;
        }

        public void setHoras(List<HoraDisponible> horas)
        {
            this.horas = horas;
        }
    }
}
