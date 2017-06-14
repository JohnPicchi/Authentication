using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;

namespace Authentication.Core.Requests
{
  public class AccountLoginRequestAsync : IRequestAsync<Account.Models.Account>
  {
    private readonly IRequestHandlerAsync<AccountLoginRequestAsync, Account.Models.Account> requestHandler;

    public AccountLoginRequestAsync(
      IRequestHandlerAsync<AccountLoginRequestAsync, Account.Models.Account> requestHandler,
      IHttpContextAccessor httpContextAccessor)
    {
      this.requestHandler = requestHandler;
      AuthenticationManager = httpContextAccessor.HttpContext.Authentication;
    }

    public LoginEditModel Form { get; set; }

    public AuthenticationManager AuthenticationManager { get; }

    public Task<Account.Models.Account> HandleAsync() => requestHandler.HandleAsync(this);
  }
}
