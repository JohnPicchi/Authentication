using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Application.DomainModels.Contracts;

namespace Authentication.Application.DomainModels
{
  public class ApplicationEmailSettings : IApplicationEmailSettings
  {
    public string SmtpHostName { get; set; }

    public int SmtpPort { get; set; }

    public string SmtpUsername { get; set; }

    public string SmtpPassword { get; set; }

    public string NoReplyAddress { get; set; }

    public string SupportAddress { get; set; }
  }
}
