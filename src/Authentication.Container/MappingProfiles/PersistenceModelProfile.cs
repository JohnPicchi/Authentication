using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Domain.Account.Models;
using AutoMapper;

namespace Authentication.Container.MappingProfiles
{
  public class PersistenceModelProfile : Profile
  {
    public PersistenceModelProfile()
    {
      CreateMap<PresistenceModels.User, User>();
      CreateMap<PresistenceModels.AccountToken, Token>();
      CreateMap<PresistenceModels.Claim, Claim>();
      CreateMap<PresistenceModels.Account, Claim>();
      CreateMap<PresistenceModels.AccountProperties, AccountProperties>();
    }
  }
}
