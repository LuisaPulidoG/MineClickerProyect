using EASendMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineClicker.EmailSender {
    class EmailSenderSMTP {
        public void SendEmail(string friendName, string email) {
            string message = "Error sendind mail.";

            try {
                SmtpMail emailObject = new SmtpMail("TryIt");

                emailObject.From = "";
                emailObject.To = email;
                emailObject.Subject = "MINECLICKER INVITATION";
                emailObject.TextBody = "Hi! " + friendName + ", your friend has sent you an invitation to play MineClicker.";

                SmtpServer serverObject = new SmtpServer("smtp.gmail.com");

                serverObject.User = "mineclikerservice@gmail.com";
                serverObject.Password = "mineclicker2000";
                serverObject.Port = 587;
                serverObject.ConnectType = SmtpConnectType.ConnectSSLAuto;

                SmtpClient clientObject = new SmtpClient();
                clientObject.SendMail(serverObject, emailObject);
                message = "Mail sent successfully!.";


            } catch (Exception ex) {
                message = "Error sending mail." + ex.Message;
            }
        }
    }
}

