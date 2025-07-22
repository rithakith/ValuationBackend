using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System;

namespace ValuationBackend.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendAsync(string to, string subject, string body)
        {
            // Read from environment variables (set in .env or your deployment environment)
            var gmailAddress = Environment.GetEnvironmentVariable("GMAIL_ADDRESS");
            var gmailAppPassword = Environment.GetEnvironmentVariable("GMAIL_APP_PASSWORD");

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(gmailAddress, gmailAppPassword),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(gmailAddress, "Valuation Department"),
                Subject = subject,
                Body = body,
                IsBodyHtml = false,
            };
            mailMessage.To.Add(to);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
} 