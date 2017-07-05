using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Authentication.Application.DomainModels.Contracts;
using Authentication.Core.ServiceContracts;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Authentication.Services
{
  public class EmailService : IEmailService
  {
    private readonly IApplicationSettings applicationSettings;

    private readonly string smtpHost;
    private readonly int smtpPort;
    private readonly string smtpUsername;
    private readonly string smtpPassword;

    private SmtpClient smtpClient;

    public EmailService(IApplicationSettings applicationSettings)
    {
      this.applicationSettings = applicationSettings;

      smtpHost = applicationSettings.Email.SmtpHostName;
      smtpPort = applicationSettings.Email.SmtpPort;
      smtpUsername = applicationSettings.Email.SmtpUsername;
      smtpPassword = applicationSettings.Email.SmtpPassword;
    }

    private SmtpClient SmtpClient => smtpClient ?? (smtpClient = new SmtpClient
    {
      ServerCertificateValidationCallback = (sender, X509Certificate, x509Chain, sslPolicyErrors) => true
    });

    public async Task SendPasswordResetEmailAsync(string userEmail, string callbackUrl)
    {
      var messageBodyBuilder = new BodyBuilder
      {
        HtmlBody = 
          $@"<h3><a href='{callbackUrl}'>Click here to reset your password....ya' dingus!</a></h3><br/><br/>" +
          @"<3 bitbyte.io"
      };

      var message = new MimeMessage
      {
        Subject = @"bitbyte.io - Looks like some dingus forgot their password",
        Body = messageBodyBuilder.ToMessageBody(),
        Priority = MessagePriority.Urgent,
        Importance = MessageImportance.High,
        XPriority = XMessagePriority.Highest
      };

      message.From.Add(new MailboxAddress("bitbyte.io", applicationSettings.Email.NoReplyAddress));
      message.To.Add(new MailboxAddress(String.Empty, userEmail));

      await SendEmailAsync(message);
    }

    public async Task SendEmailConfirmationEmailAsync(string userEmail, string callbackUrl)
    {
      var messageBodyBuilder = new BodyBuilder
      {
        HtmlBody =
          $@"<h3><a href='{callbackUrl}'>Click here to confirm your email address.</a></h3><br/><br/>" +
          @"<3 bitbyte.io"
      };

      var message = new MimeMessage
      {
        Subject = @"bitbyte.io - Email Confirmation",
        Body = messageBodyBuilder.ToMessageBody(),
        Priority = MessagePriority.Urgent,
        Importance = MessageImportance.High,
        XPriority = XMessagePriority.Highest
      };

      message.From.Add(new MailboxAddress("bitbyte.io", applicationSettings.Email.NoReplyAddress));
      message.To.Add(new MailboxAddress(String.Empty, userEmail));

      await SendEmailAsync(message);
    }

    public async Task SendMultiFactorAuthEmailAsync(string userEmail, string code)
    {
      throw new NotImplementedException();
    }

    private async Task SendEmailAsync(MimeMessage message)
    {
      await SmtpClient.ConnectAsync(smtpHost, smtpPort, SecureSocketOptions.StartTls);
      await SmtpClient.AuthenticateAsync(smtpUsername, smtpPassword);
      await SmtpClient.SendAsync(message);
      await SmtpClient.DisconnectAsync(true);
    }
  }
}