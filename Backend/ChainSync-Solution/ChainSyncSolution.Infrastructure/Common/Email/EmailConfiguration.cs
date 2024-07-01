using ChainSyncSolution.Infrastructure.Common.Email.Common;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace ChainSyncSolution.Infrastructure.Common.Email;

public class EmailConfiguration
{
    public static async Task SendEmailAsync(
        string email,
        string subject,
        string message,
        IConfiguration configuration)
    {
        var emailSettings = configuration.GetSection(EmailOptions.EmailSettings);
        var mimeMessage = new MimeMessage();
        mimeMessage.From.Add(new MailboxAddress(emailSettings[EmailOptions.SenderName], emailSettings[EmailOptions.Sender]));
        mimeMessage.To.Add(MailboxAddress.Parse(email));
        mimeMessage.Subject = subject;

        mimeMessage.Body = new TextPart(EmailOptions.html) { Text = message };

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(emailSettings[EmailOptions.MailServer], int.Parse(emailSettings[EmailOptions.MailPort]), false);
            client.AuthenticationMechanisms.Remove(EmailOptions.XOAUTH2);
            await client.AuthenticateAsync(emailSettings[EmailOptions.Sender], emailSettings[EmailOptions.Password]);
            await client.SendAsync(mimeMessage);
            await client.DisconnectAsync(true);
        }
    }
}
