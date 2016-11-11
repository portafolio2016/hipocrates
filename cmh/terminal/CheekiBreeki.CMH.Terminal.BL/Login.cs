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

        #region Verificar Usuario
        public static Boolean verificarUsuario(string usuario,string password)
        {
            try
            {
                //Verificar si el usuario(email) valido y password es nulo.
                if (Util.isEmailValido(usuario) != true)
                {
                    throw new Exception("Formato email no valido");
                }
                else if (password == null || password == "")
                {
                    throw new Exception("Contraseña vacía");
                }

                //Comprobar de que el usuario y la contraseña sean iguales en la base de datos

                string passwordHasheada = Util.hashMD5(password);
                CMHEntities conexionBD = new CMHEntities();
                PERSONAL personal = null;

                //en vez de traer personal traer dato propio.
                personal = conexionBD.PERSONAL.
                    Where(d => d.EMAIL == usuario && d.HASHED_PASS == passwordHasheada).FirstOrDefault();
               //Validar usuario(email)
                if (personal.EMAIL != usuario)
                {
                    throw new Exception("Usuario incorrecto");
                }                    
               //Validar contraseña
                else if(personal.HASHED_PASS != passwordHasheada)
                {
                    throw new Exception("Contraseña incorrecta");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion

        #region Inicio sesión
        #endregion

        #region Cerrar sesión
        #endregion
    }
}
