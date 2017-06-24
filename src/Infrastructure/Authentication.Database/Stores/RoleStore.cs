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
  public class RoleStore : IRoleStore
  {
    public RoleStore(DatabaseContext databaseContext)
    {
      
    }
    public IQueryable<Role> Roles { get; }

    public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<IList<Claim>> GetClaimsAsync(Role role, CancellationToken cancellationToken = new CancellationToken())
    {
      throw new NotImplementedException();
    }

    public async Task AddClaimAsync(Role role, Claim claim, CancellationToken cancellationToken = new CancellationToken())
    {
      throw new NotImplementedException();
    }

    public async Task RemoveClaimAsync(Role role, Claim claim, CancellationToken cancellationToken = new CancellationToken())
    {
      throw new NotImplementedException();
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }
  }
}
