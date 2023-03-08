using System.Net;
using System.Net.Mail;

namespace Email_ClassLibrary
{
    public static class EmailService
    {
        public static async Task SendEmailAsync(SMTPConfig smtpConfig, Email email)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            MailMessage objMailMessage = new MailMessage
            {
                From = new MailAddress(smtpConfig.From, smtpConfig.DisplayName),
                Subject = email.Subject,
                Body = email.Message,
                Priority = MailPriority.Normal,
                IsBodyHtml = true,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            };

            foreach(string mailAddress in email.To)
            {
                objMailMessage.To.Add(mailAddress);
            }

            SmtpClient smtp = new SmtpClient
            {
                Host = smtpConfig.Server,
                Port = smtpConfig.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(smtpConfig.Username, smtpConfig.Password),
            };

            await smtp.SendMailAsync(objMailMessage);
        }
    }
}
