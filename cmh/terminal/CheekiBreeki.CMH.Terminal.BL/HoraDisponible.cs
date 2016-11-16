using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheekiBreeki.CMH.Terminal.DAL;

namespace CheekiBreeki.CMH.Terminal.BL
{
    public class HoraDisponible
    {
        private DateTime date;
        private BLOQUE bloque;
        private int horaIni;
        private int horaFin;
        private int minuIni;
        private int minuFin;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        
        public BLOQUE Bloque
        {
            get { return bloque; }
            set { bloque = value; }
        }
        
        public int HoraIni
        {
            get { return horaIni; }
            set { horaIni = value; }
        }
        
        public int HoraFin
        {
            get { return horaFin; }
            set { horaFin = value; }
        }
        public int MinuIni
        {
            get { return minuIni; }
            set { minuIni = value; }
        }
        

        public int MinuFin
        {
            get { return minuFin; }
            set { minuFin = value; }
        }

        public HoraDisponible()
        {
        }

        public HoraDisponible(DateTime date, BLOQUE bloque)
        {
            this.horaIni = bloque.NUM_HORA_INI;
            this.horaFin = bloque.NUM_HORA_FIN;
            this.minuIni = bloque.NUM_MINU_INI;
            this.minuFin = bloque.NUM_MINU_FIN;
            this.bloque = bloque;
        }
    }
}
