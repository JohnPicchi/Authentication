using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Account.Models;
using AutoMapper;

namespace Authentication.Container.MappingProfiles
{
  public class PersistenceModelProfile : Profile
  {
    public PersistenceModelProfile()
    {
      CreateMap<PresistenceModels.User, User.Models.User>();
      CreateMap<PresistenceModels.AccountToken, Account.Models.Token>();
      CreateMap<PresistenceModels.Claim, Account.Models.Claim>();
      CreateMap<PresistenceModels.Account, Account.Models.Account>();
      CreateMap<PresistenceModels.AccountProperties, Account.Models.Properties>();
    }
  }
}
