using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Account.Models;
using AutoMapper;
using Authentication.PresistenceModels;
using Properties = Authentication.Account.Models.Properties;
using Claim = Authentication.Account.Models.Claim;

namespace Authentication.Container.MappingProfiles
{
  public class DomainModelProfile : Profile
  {
    public DomainModelProfile()
    {
      CreateMap<User.Models.User, PresistenceModels.User>();
      CreateMap<Account.Models.Token, PresistenceModels.AccountToken>();
      CreateMap<Account.Models.Claim, PresistenceModels.Claim>();
      CreateMap<Account.Models.Account, PresistenceModels.Account>();
      CreateMap<Account.Models.Properties, PresistenceModels.AccountProperties>();
    }
  }
}
