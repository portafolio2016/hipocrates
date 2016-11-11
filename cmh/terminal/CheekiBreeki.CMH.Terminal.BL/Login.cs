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
                
                                //en vez de traer personal traer dato propio.
                string emailBuscado = conexionBD.PERSONAL.
                    Where(d => d.EMAIL == usuario).FirstOrDefault().EMAIL;
                string passBuscada = conexionBD.PERSONAL.
                    Where(d => d.HASHED_PASS == passwordHasheada).FirstOrDefault().HASHED_PASS;
               //Validar usuario(email)
                if (emailBuscado != usuario)
                {
                    throw new Exception("Usuario incorrecto");
                }                    
               //Validar contraseña
                else if (passBuscada != passwordHasheada)
                {
                    throw new Exception("Contraseña incorrecta");
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
        #endregion

        #region Inicio sesión
        #endregion

        #region Cerrar sesión
        #endregion
    }
}
