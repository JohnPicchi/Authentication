using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Authentication.Domain.Account.Models;

namespace Authentication.Container.MappingProfiles
{
  public class DomainModelProfile : Profile
  {
    public DomainModelProfile()
    {
      CreateMap<User, PresistenceModels.User>();
      CreateMap<Token, PresistenceModels.AccountToken>();
      CreateMap<Claim, PresistenceModels.Claim>();
      CreateMap<Account, PresistenceModels.Account>();
      CreateMap<AccountProperties, PresistenceModels.AccountProperties>();
    }
  }
}
