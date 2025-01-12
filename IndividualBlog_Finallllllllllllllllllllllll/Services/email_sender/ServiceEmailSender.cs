﻿using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace IndividualBlog.Services.NewFolder
{
    public class ServiceEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(email, email));
                message.Subject = subject;
                message.Body = htmlMessage;
                message.From = new MailAddress("dugkhoxnke@gmail.com", "demo senmail");
                message.IsBodyHtml = true;

                using (var client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.Port = 587;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("dugkhoxnke@gmail.com", "*******");
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }
            return Task.CompletedTask;

        }
    }
}
