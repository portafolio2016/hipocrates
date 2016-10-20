using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASendMail;

namespace TestMail
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *  ------- REQUERIMIENTOS PREVIOS -------
             *  Definir correo que va a enviar el correo
             *  Agregar a la cuenta de Gmail Permitir el acceso a aplicaciones menos seguras
             *  Link: https://myaccount.google.com/security
             *  
             *  Nota: No se pueden enviar correos mediante la red pública del Duoc
             */

            string remitente, receptor, titulo, cuerpo;
            remitente = "CMH.Notificaciones@gmail.com";
            receptor = "fjaqueg@gmail.com";
            titulo = "Bienvenido al Centro Médico Hipócrates";
            cuerpo = "Gracias por atenderse con nosotros";

            // Configuración campos
            SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();
            oMail.From = remitente;
            oMail.To = receptor;
            oMail.Subject = titulo;
            oMail.TextBody = cuerpo;

            // Configuración Gmail
            SmtpServer oServer = new SmtpServer("smtp.gmail.com");
            oServer.Port = 465;
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

            // Usuario correo
            oServer.User = "CMH.Notificaciones@gmail.com";
            oServer.Password = "portafolio2016";

            try
            {
                Console.WriteLine("Enviando correo. . .");
                oSmtp.SendMail(oServer, oMail);
                Console.WriteLine("Correo enviado correctamente");
            }
            catch (Exception ep)
            {
                Console.WriteLine("Error al enviar el correo");
                Console.WriteLine(ep.Message);
            }
          
            Console.ReadKey();
        }
    }
}
