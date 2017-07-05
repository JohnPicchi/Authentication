using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Core.ServiceContracts
{
  public interface IEmailService
  {
    Task SendPasswordResetEmailAsync(string userEmail, string callbackUrl);

    Task SendEmailConfirmationEmailAsync(string userEmail, string callbackUrl);

    Task SendMultiFactorAuthEmailAsync(string userEmail, string code);
  }
}
