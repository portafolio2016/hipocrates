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
        CMHEntities conexionDB = new CMHEntities();

        public static Boolean verificarUsuario(string usuario,string password)
        {
            string passwordHasheada = Util.hashMD5(password);
            if( )
            return true;
        } 
    }
}
