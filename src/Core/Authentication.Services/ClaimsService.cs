using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;

namespace Authentication.Services
{
  public class ClaimsService : IClaimsService
  {
    private readonly DefaultClaimsService defaultClaimsService;

    public ClaimsService(DefaultClaimsService defaultClaimsService)
    {
      this.defaultClaimsService = defaultClaimsService;
    }

    public Task<IEnumerable<Claim>> GetIdentityTokenClaimsAsync(
      ClaimsPrincipal subject, 
      Client client, 
      Resources resources, 
      bool includeAllIdentityClaims, 
      ValidatedRequest request)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<Claim>> GetAccessTokenClaimsAsync(
      ClaimsPrincipal subject, 
      Client client, 
      Resources resources, 
      ValidatedRequest request)
    {
      throw new NotImplementedException();
    }
  }
}
