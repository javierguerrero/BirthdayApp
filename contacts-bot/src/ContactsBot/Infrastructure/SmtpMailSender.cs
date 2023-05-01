using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Threading.Tasks;

namespace ContactsBot.Infrastructure
{
    public class SmtpMailSender : IMailSender
    {
        private readonly IConfiguration _configuration;

        public SmtpMailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Send(string textBody)
        {

            var emailConfig = _configuration.GetSection("Email").Get<EmailConfiguration>();
            var smtpConfig = _configuration.GetSection("Smtp").Get<SmtpConfiguration>();


            // Crear el mensaje de correo electrónico
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("Remitente", emailConfig.From));
            mimeMessage.To.Add(new MailboxAddress("Destinatario", emailConfig.To));
            mimeMessage.Subject = emailConfig.Subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = textBody;

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            
            // Configurar el cliente SMTP
            using (var smtpClient = new SmtpClient())
            {
                await smtpClient.ConnectAsync(smtpConfig.Server, smtpConfig.Port, smtpConfig.UseSsl);

                // Autenticarse con la cuenta de Gmail
                await smtpClient.AuthenticateAsync(smtpConfig.Username, smtpConfig.Password);

                // Enviar el mensaje de correo electrónico
                await smtpClient.SendAsync(mimeMessage);

                // Desconectar del servidor SMTP
                await smtpClient.DisconnectAsync(true);
            }
        }
    }
}