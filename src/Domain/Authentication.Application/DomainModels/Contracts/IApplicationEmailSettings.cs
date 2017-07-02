using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.DomainModels.Contracts
{
  public interface IApplicationEmailSettings
  {
    string SmtpHostName { get; }

    int SmtpPort { get; }

    string SmtpUsername { get; }

    string SmtpPassword { get; }

    string NoReplyAddress { get; }

    string SupportAddress { get; }
  }
}
