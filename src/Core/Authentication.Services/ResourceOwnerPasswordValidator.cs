using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IdentityServer4.Validation;

namespace Authentication.Services
{
  public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
  {
    public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
      throw new NotImplementedException();
    }
  }
}
