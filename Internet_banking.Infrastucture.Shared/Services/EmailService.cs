using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Internet_banking.Core.Application.Dtos.Email;
using Internet_banking.Core.Application.Interfaces.Services;
using Internet_banking.Core.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Infrastucture.Shared.Services
{
    public class EmailService : IEmailService
    {
        private MailSettings _mailSettings { get; }

        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendAsync(EmailRequest request)
        {

            try
            {
                MimeMessage mail = new();
                
                mail.Sender = MailboxAddress.Parse(_mailSettings.EmailFrom);
                mail.To.Add(MailboxAddress.Parse(request.To));
                mail.Subject = request.Subject;
                BodyBuilder builder = new();
                builder.HtmlBody= request.Body;
                mail.Body = builder.ToMessageBody();
                
                SmtpClient smtp = new();
                smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort,SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
                await smtp.SendAsync(mail);
                smtp.Disconnect(true);
            }
            catch(Exception ex)
            {

            }

        }
    }
}
