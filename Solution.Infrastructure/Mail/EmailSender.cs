using Microsoft.Extensions.Options;
using SendGrid;
using Solution.Application.Contracts.Infrastructure;
using Solution.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailSender (IOptions<EmailSettings> mailSettings)
        {
            _emailSettings = mailSettings.Value;
        }

        public async Task<bool> SendEmail (Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);

            var from = new SendGrid.Helpers.Mail.EmailAddress
                (_emailSettings.FromAddress, _emailSettings.FromName);

            var to = new SendGrid.Helpers.Mail.EmailAddress(email.To);

            var message = SendGrid.Helpers.Mail.MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);

            var response = await client.SendEmailAsync(message);

            return response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted;
        }
    }
}
