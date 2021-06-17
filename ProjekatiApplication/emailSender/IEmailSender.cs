using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatiApplication.emailSender
{
    public interface IEmailSender
    {
        void Send(SendEmail sendEmail);
    }

    public class SendEmail
    {
        public string Subject { get; set; }

        public string Content { get; set; }

        public string Adress { get; set; }


    }
}
