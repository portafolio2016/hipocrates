using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

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
        /// Método para validar RUT al formato chileno
        /// </summary>
        /// <param name="rut">Parte numérica del RUT</param>
        /// <param name="digito">Dígito verificador</param>
        /// <returns>Si es RUT válido</returns>
        public static Boolean rutValido(int rut, string digito)
        {
            bool validacion = false;
            try
            {
                int rutAux = rut;
                char dv = Char.Parse(digito.ToUpper());

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
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

        /// <summary>
        /// Comprueba todos los TextBox del Form para ver si tienen algún valor
        /// </summary>
        /// <param name="formulario">Windows Form</param>
        /// <returns>true si tienen valores</returns>
        public static Boolean validarTextBoxVacios(Form formulario)
        {
            foreach (Control control in formulario.Controls)
            {
                if (control.GetType().Equals(typeof(TextBox)))
                {
                    if (control.Text.Equals(""))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

