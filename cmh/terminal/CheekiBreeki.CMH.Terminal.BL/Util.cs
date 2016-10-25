using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheekiBreeki.CMH.Terminal.BL
{
    public class Util
    {
        /// <summary>
        /// Devuelve true cuando el objeto es nulo
        /// </summary>
        /// <param name="obj">Objeto</param>
        /// <returns></returns>
        public static Boolean isObjetoNulo(Object obj)
        {
            if (obj == null)
                return true;
            return false;
        }
    }
}
