using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

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

        /// <summary>
        /// Genera una contraseña al azar de largo 12
        /// </summary>
        /// <returns>Contraseña</returns>
        public static string generarPass()
        {
            string password = Membership.GeneratePassword(12, 0);
            return (password);
        }

        /// <summary>
        /// Aplica algoritmo de hasheado de MD5 a una cadena
        /// </summary>
        /// <param name="pass">Contraseña a hashear</param>
        /// <returns>Contraseña hasheada</returns>
        public static string hashMD5(string pass)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder convertida = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                convertida.Append(hash[i].ToString("X2"));
            }

            return convertida.ToString();
        }
    }
}

