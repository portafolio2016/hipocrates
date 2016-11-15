using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheekiBreeki.CMH.Terminal.DAL;
using CheekiBreeki.CMH.Terminal.BL;
namespace CheekiBreeki.CMH.Terminal.Views
{
    public class Login
    {
        private static UsuarioLogeado usuarioLogueado;

        #region Verificar Usuario
        public static PERSONAL verificarUsuario(string usuario, string password)
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

                /*string emailBuscado = conexionBD.PERSONAL.
                    Where(d => d.EMAIL == usuario).FirstOrDefault().EMAIL;
                string passBuscada = conexionBD.PERSONAL.
                    Where(d => d.HASHED_PASS == passwordHasheada).FirstOrDefault().HASHED_PASS;*/

                PERSONAL personal = conexionBD.PERSONAL.
                    Where(d => d.EMAIL.ToUpper() == usuario.ToUpper() && d.HASHED_PASS == passwordHasheada).FirstOrDefault();

                //Validar usuario(email)
                if (Util.isObjetoNulo(personal))
                {
                    throw new Exception("Usuario y contraseña incorrecto");
                }
                else
                {
                    return personal;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        #endregion

        #region Inicio sesión
        public static UsuarioLogeado iniciarSesion(string usuario, string password)
        {
            PERSONAL personal = verificarUsuario(usuario, password);
            UsuarioLogeado usuarioIniciado = null;
            if (!Util.isObjetoNulo(personal))
            {
                usuarioIniciado = new UsuarioLogeado(personal);
            }
            return usuarioIniciado;
        }
        #endregion

        #region Cerrar sesión
        public static Boolean cerrarSesion(UsuarioLogeado usuario)
        {
            usuario = null;
            return true;
        }

        #endregion

        #region GetUsuarioLogueado
        #endregion 

        #region SetUsuarioLogueado
        #endregion

    }
}
