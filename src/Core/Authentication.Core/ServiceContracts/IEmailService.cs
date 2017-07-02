using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Core.ServiceContracts
{
  public interface IEmailService
  {
    Task SendPasswordResetEmailAsync(string userEmail, string passwordResetUrl);

    Task SendMultiFactorAuthEmailAsync(string userEmail, string code);
  }
}
