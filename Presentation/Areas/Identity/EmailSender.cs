﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Presentation.Areas.Identity
{
    public class EmailSender : IEmailSender
    {
        private readonly string _apiKey;
        private readonly string _fromEmail;
        private readonly string _fromName;

        public EmailSender(IConfiguration config)
        {
            _apiKey = config["SendGrid:ApiKey"];
            _fromName = config["SendGrid:FromName"];
            _fromEmail = config["SendGrid:FromEmail"];
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var msg = new SendGridMessage
            {
                From = new EmailAddress(_fromEmail, _fromName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            var client = new SendGridClient(_apiKey);

            await client.SendEmailAsync(msg);
        }
    }
}