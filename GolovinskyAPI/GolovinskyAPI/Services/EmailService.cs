using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using MailKit.Security;
using System;

namespace GolovinskyAPI.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "admin@golovinskiy.bostil.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("Plain")
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    await client.ConnectAsync("mail.bostil.ru", 25, SecureSocketOptions.Auto);
                    await client.AuthenticateAsync("golovinskiy@bostil.ru", "bostil123");
                    await client.SendAsync(emailMessage);
                }
                catch (Exception ex)
                {

                }
                await client.DisconnectAsync(true);
            }
        }
    }
}