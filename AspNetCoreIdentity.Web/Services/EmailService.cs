
using AspNetCoreIdentity.Web.OptionsModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace AspNetCoreIdentity.Web.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendResetPasswordEmail(string resetPasswordEmailLink, string toEmail)
        {
            var smtpClient = new SmtpClient();
            smtpClient.Host = _emailSettings.Host;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential(_emailSettings.Email, _emailSettings.Password);
            smtpClient.EnableSsl = true;
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_emailSettings.Email);
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = "IdentityApp | Şifre Sıfırlama Linki";
            mailMessage.Body = @$"<h4>Şifrenizi Yenilemek için aşağıdaki linke tıklayınız</h4> <p><a href='{resetPasswordEmailLink}'>
                  Şifre Yenileme Linki  </a></p>";
            mailMessage.IsBodyHtml = true;
            await smtpClient.SendMailAsync(mailMessage);

          
        }
    }
}
