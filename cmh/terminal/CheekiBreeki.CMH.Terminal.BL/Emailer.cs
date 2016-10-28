using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASendMail;
namespace CheekiBreeki.CMH.Terminal.BL
{
    public class Emailer
    {
        #region Envío correo
        /// <summary>
        /// Envía un correo personalizado a nombre de CMH Notificaciones
        /// Nota: No se pueden enviar correos mediante la red pública del Duoc
        /// </summary>
        /// <param name="receptor">Correo del receptor</param>
        /// <param name="titulo">Título del correo</param>
        /// <param name="cuerpo">Mensaje del correo</param>
        /// <returns></returns>
        public Boolean enviarCorreo(string receptor, string titulo, string cuerpo)
        {
            try
            {
                if (Util.isObjetoNulo(receptor) || receptor == string.Empty)
                    throw new Exception("Receptor vacío");
                else if (Util.isObjetoNulo(titulo) || titulo == string.Empty)
                    throw new Exception("Título vacío");
                else if (Util.isObjetoNulo(cuerpo) || cuerpo == string.Empty)
                    throw new Exception("Cuerpo vacío");
                else if (!Util.isEmailValido(receptor))
                    throw new Exception("Correo inválido");
                else
                {
                    string remitente, usuario, pass;
                    remitente = "CMH Notificaciones";
                    usuario = "CMH.Notificaciones@gmail.com";
                    pass = "portafolio2016";

                    // Configuración campos
                    SmtpMail oMail = new SmtpMail("TryIt");
                    SmtpClient oSmtp = new SmtpClient();
                    oMail.From = new MailAddress(remitente, usuario);
                    oMail.To = receptor;
                    oMail.Subject = titulo;
                    oMail.TextBody = cuerpo;

                    // Configuración Gmail
                    SmtpServer oServer = new SmtpServer("smtp.gmail.com");
                    oServer.Port = 465;
                    oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
                    oServer.User = usuario;
                    oServer.Password = pass;

                    oSmtp.SendMail(oServer, oMail);
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
    }
}
