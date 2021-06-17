using ProjekatiApplication.emailSender;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ProjekatImplementation.Email
{
    public class SMTPEmailSender : IEmailSender
    {
        public void Send(SendEmail sendEmail)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("jdoe88005@gmail.com", "'_e8$.vn@!2}fSN7")
            };

            var message = new MailMessage("jdoe88005@gmail.com", sendEmail.Adress);
            message.Subject = sendEmail.Subject;
            message.Body = sendEmail.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);


        }
    }
}
