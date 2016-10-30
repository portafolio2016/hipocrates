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

        /// <summary>
        /// Devuelve true cuando el correo es válido
        /// </summary>
        /// <param name="obj">Email</param>
        /// <returns></returns>
        public static Boolean isEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}

