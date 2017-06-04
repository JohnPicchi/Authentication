using AutoMapper;
using AccountClaim = Authentication.PresistenceModels.Models.AccountClaim;
using AccountLock = Authentication.PresistenceModels.Models.AccountLock;
using AccountProperties = Authentication.PresistenceModels.Models.AccountProperties;
using AccountToken = Authentication.PresistenceModels.Models.AccountToken;

namespace Authentication.PresistenceModels.MappingProfiles
{
  public class DomainModelProfile : Profile
  {
    public DomainModelProfile()
    {
      CreateMap<User.Models.User, Models.User>();

      CreateMap<Account.Models.Account, Models.Account>();
      CreateMap<Account.Models.AccountProperties, AccountProperties>();
      CreateMap<Account.Models.AccountClaim, AccountClaim>();
      CreateMap<Account.Models.AccountLock, AccountLock>();
      CreateMap<Account.Models.AccountToken, AccountToken>();
      }
  }
}
