using EASendMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineClicker.EmailSender
{
    class EmailSenderSMTP
    {
        public void SendEmail(string nombreAmigo, string correoAmigo)
        {
            string mensaje = "Error al enviar correo.";

            try
            {
                SmtpMail emailObject = new SmtpMail("TryIt");

                emailObject.From = "";
                emailObject.To = correoAmigo;
                emailObject.Subject = "INVITACIÓN";
                emailObject.TextBody = "Hola! ESTO NO ES SPAM"+ nombreAmigo +", tu amigo te ha enviado una invitación para jugar MineClicker.";

                SmtpServer serverObject = new SmtpServer("smtp.gmail.com");

                serverObject.User = "mineclikerservice@gmail.com";
                serverObject.Password = "mineclicker2000";
                serverObject.Port = 587;
                serverObject.ConnectType = SmtpConnectType.ConnectSSLAuto;

                SmtpClient clientObject = new SmtpClient();
                clientObject.SendMail(serverObject, emailObject);
                mensaje = "Correo Enviado Correctamente.";


            }
            catch (Exception ex)
            {
                mensaje = "Error al enviar correo." + ex.Message;
            }
        }
    }
}

