using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheekiBreeki.CMH.Terminal.DAL;

namespace CheekiBreeki.CMH.Terminal.BL
{
    public class Login
    {

        public static Boolean verificarUsuario(string usuario,string password)
        {
            try
            {
                //Verificar si el usuario y password es nulo.
                if (Util.isEmailValido(usuario) != true)
                {
                    throw new Exception("Email no valido");
                }
                else if (password == null || password == "")
                {
                    throw new Exception("Contraseña no valida");
                }
                //Comprobar de que el usuario y la contraseña sean iguales en la base de datos

                string passwordHasheada = Util.hashMD5(password);
                CMHEntities conexionBD = new CMHEntities();
                PERSONAL personal = null;

                personal = conexionBD.PERSONAL.
                    Where(d => d.EMAIL == usuario && d.HASHED_PASS == passwordHasheada).FirstOrDefault();
                if (Util.isObjetoNulo(personal))
                {
                    throw new Exception("Personal no existe");
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
