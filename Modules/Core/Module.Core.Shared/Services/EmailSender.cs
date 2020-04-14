using Infrastructure.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Module.Core.Shared.Options;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace Module.Core.Shared
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailOptions _emailOptions;

        public EmailSender(IOptionsMonitor<EmailOptions> options)
        {
            _emailOptions = options.CurrentValue;
        }

        public async Task SendEmailAsync(string email, string subject, string body, bool isHtml = true)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emailOptions.SmtpUsername));
            message.To.Add(new MailboxAddress(email));
            message.Subject = subject;

            var textFormat = isHtml ? TextFormat.Html : TextFormat.Plain;
            message.Body = new TextPart(textFormat)
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                // Accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await client.ConnectAsync(_emailOptions.SmtpServer, _emailOptions.SmtpPort, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                await client.AuthenticateAsync(_emailOptions.SmtpUsername, _emailOptions.SmtpPassword);

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
