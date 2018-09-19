using System;
using System.Net;
using System.Net.Mail;

namespace Xm.Trial.Service
{
    public class Email
    {
        private const string hostFrom = "smtp.yandex.ru";
        private const int    portFrom = 25;
        private const string emailFrom = "xmonetize-test@yandex.ru";
        private const string emailPasswordFrom = "slidersm44";
        private const string emailTo = "aleynikov.oleg@yandex.ru";

        public string Send(string messageText)
        {
            SmtpClient client = new SmtpClient();
            client.Host = hostFrom;
            client.Port = portFrom;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(emailFrom, emailPasswordFrom);

            MailAddress from = new MailAddress(emailFrom, "xMonetize");
            MailAddress to = new MailAddress(emailTo);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Сообщение от пользователя с сайта";
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.Body = messageText;
            message.BodyEncoding = System.Text.Encoding.UTF8;

            string sendMessageResult = String.Empty;
            try
            {
                client.Send(message);
                message.Dispose();
                return "The message has been successfully delivered";
            }
            catch (Exception e)
            {
                return "The message delivery failed";
            }
        }
    }
}