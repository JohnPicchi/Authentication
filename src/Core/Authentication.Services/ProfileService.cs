
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Authentication.Account;
using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace Authentication.Services
{
  public class ProfileService  : IProfileService
  {
    private readonly IAccountRepository accountRepository;

    public ProfileService(IAccountRepository accountRepository)
    {
      this.accountRepository = accountRepository;
    }

    public Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
      var subjectId = context.Subject.GetSubjectId();
      var claims = new List<Claim>
      {
        new Claim(JwtClaimTypes.Role, "Administrator"),
        new Claim(JwtClaimTypes.GivenName, "John")
      };
      context.AddFilteredClaims(claims);
      return Task.FromResult(0);
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
      var subjectId = context.Subject.GetSubjectId();
      context.IsActive = true;
      return Task.FromResult(0);
    }
  }
}
