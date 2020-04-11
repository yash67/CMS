using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common
{
   public class SendEmail
    {
        private Constant constant = new Constant();
        public async Task<bool> SendMail(string emailList, string title, string mes)
        {
            try
            {
                var message = new MailMessage();

                message.To.Add(new MailAddress(emailList));

                message.From = new MailAddress("CMS@GMAIL");
                message.Subject = title;
                message.Body = mes;
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = constant.emailUsername,
                        Password = constant.emailPassword
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);

                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

