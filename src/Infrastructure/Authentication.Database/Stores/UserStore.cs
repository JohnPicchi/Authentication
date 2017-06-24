using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Authentication.Domain.PersistenceModels;
using Authentication.Domain.Stores;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Database.Stores
{
  public class UserStore : IUserStore
  {
    public UserStore(DatabaseContext context, IdentityErrorDescriber describer = null)
    {
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public async Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task AddLoginAsync(User user, UserLoginInfo login, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task RemoveLoginAsync(User user, string loginProvider, string providerKey, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<IList<UserLoginInfo>> GetLoginsAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<User> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<IList<Claim>> GetClaimsAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task AddClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task ReplaceClaimAsync(User user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task RemoveClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<IList<User>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task SetSecurityStampAsync(User user, string stamp, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<string> GetSecurityStampAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task SetEmailAsync(User user, string email, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<string> GetEmailAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<DateTimeOffset?> GetLockoutEndDateAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task SetLockoutEndDateAsync(User user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<int> IncrementAccessFailedCountAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task ResetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<int> GetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<bool> GetLockoutEnabledAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task SetLockoutEnabledAsync(User user, bool enabled, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task SetPhoneNumberAsync(User user, string phoneNumber, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<string> GetPhoneNumberAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<bool> GetPhoneNumberConfirmedAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task SetPhoneNumberConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public IQueryable<User> Users { get; }
    public async Task SetTwoFactorEnabledAsync(User user, bool enabled, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<bool> GetTwoFactorEnabledAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task SetTokenAsync(User user, string loginProvider, string name, string value, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task RemoveTokenAsync(User user, string loginProvider, string name, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<string> GetTokenAsync(User user, string loginProvider, string name, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
