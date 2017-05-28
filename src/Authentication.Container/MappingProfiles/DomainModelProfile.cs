using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Account.Models;
using AutoMapper;
using Authentication.PresistenceModels;


namespace Authentication.Container.MappingProfiles
{
  public class DomainModelProfile : Profile
  {
    public DomainModelProfile()
    {
      CreateMap<User.Models.User, PresistenceModels.User>();

      CreateMap<Account.Models.AccountToken, PresistenceModels.AccountToken>();
      CreateMap<Account.Models.AccountClaim, PresistenceModels.AccountClaim>();
      CreateMap<Account.Models.AccountLock, PresistenceModels.AccountLock>();
      CreateMap<Account.Models.Account, PresistenceModels.Account>();
      CreateMap<Account.Models.AccountProperties, PresistenceModels.AccountProperties>();
    }
  }
}
