using Email_ClassLibrary;

Email email = new Email
{
    To = new string[] { "emailToSend@outlook.com" },
    Subject = "Subject",
    Message = "Hello World",
};

SMTPConfig smtpConfig = new SMTPConfig
{
    Server = "smtp.server.com",
    Port = 587,
    Username = "yourUsername",
    Password = "yourPassword",
    From = "yourEmail@gmail.com",
    DisplayName = "aDisplayName"
};

await EmailService.SendEmailAsync(smtpConfig, email);