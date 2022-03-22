using BlogSite.Entities.Dtos.ContactDtos;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace BlogSite.Business.Services.Mail
{
    public class MailHelper
    {
        private static string smtpServer = "mail.deuxsoft.com";
        private static int smtpPort = 587;
        private static string from = "bugrahansaygici@deuxsoft.com";
        private static string fromPassword = "0A:Xw58@z-.ZYxu3";
        private static bool isBodyHtml = true;
        private static NetworkCredential networkCredential = new NetworkCredential(from, fromPassword);
        public static void SendMail(List<string> tos, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(smtpServer, smtpPort);

            mail.From = new MailAddress(from);
            foreach (string to in tos)
            {
                mail.To.Add(to);
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = isBodyHtml;

            //SmtpServer.UseDefaultCredentials = true;
            if (networkCredential != null)
                SmtpServer.Credentials = networkCredential;

            SmtpServer.Send(mail);
        }
        public static void SendMail(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(smtpServer, smtpPort);

            mail.From = new MailAddress(from);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = isBodyHtml;

            //SmtpServer.UseDefaultCredentials = true;
            if (networkCredential != null)
                SmtpServer.Credentials = networkCredential;

            SmtpServer.Send(mail);

        }
        public static void SendMailForContact(ContactAddDto contactAddDto)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(smtpServer, smtpPort);
            mail.From = new MailAddress(from);
            mail.To.Add("bsaygici@hotmail.com");
            mail.Subject = contactAddDto.Subject;
            mail.Body = contactAddDto.Message;
            mail.IsBodyHtml = isBodyHtml;

            if (networkCredential != null)
                SmtpServer.Credentials = networkCredential;

            SmtpServer.Send(mail);
        }
    }
}
