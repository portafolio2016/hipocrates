using CheekiBreeki.CMH.Terminal.DAL;
using CheekiBreeki.CMH.Terminal.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheekiBreeki.CMH.Terminal.Views
{
    public class UsuarioLogeado
    {

        #region Atributos
        private string _nombreUsuario;
        private PERSONAL _personal;
        private string _privilegio;
        #endregion

        #region Accesadores
        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }
        public PERSONAL Personal
        {
            get { return _personal; }
            set { _personal = value; }
        }
        public string Privilegio
        {
            get { return _privilegio; }
            set { _privilegio = value; }
        }
        #endregion

        #region Contructores
        public UsuarioLogeado()
        {
            Init();
        }

        public UsuarioLogeado(PERSONAL personal)
        {
            _nombreUsuario = personal.EMAIL;
            _personal = personal;
            definirPrivilegio();
        }
        #endregion

        #region Métodos
        public void Init()
        {
            _nombreUsuario = string.Empty;
            _personal = new PERSONAL();
            _privilegio = string.Empty;
        }

        public void definirPrivilegio()
        {
            if (Util.isObjetoNulo(_personal.FUNCIONARIO.FirstOrDefault().CARGO.NOMBRE_CARGO))
                _privilegio = _personal.PERS_MEDICO.FirstOrDefault().ESPECIALIDAD.NOM_ESPECIALIDAD;
            else
                _privilegio = _personal.FUNCIONARIO.FirstOrDefault().CARGO.NOMBRE_CARGO;
        }
        #endregion
    }
}
