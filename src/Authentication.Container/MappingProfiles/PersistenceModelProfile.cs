using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Account.Models;
using AutoMapper;

namespace Authentication.Container.MappingProfiles
{

  /// <summary>
  /// Mappings from persistence models to domain models
  /// </summary>

  public class PersistenceModelProfile : Profile
  {
    public PersistenceModelProfile()
    {
      CreateMap<PresistenceModels.User, User.Models.User>();

      CreateMap<PresistenceModels.AccountToken, Account.Models.AccountToken>();
      CreateMap<PresistenceModels.AccountClaim, Account.Models.AccountClaim>();
      CreateMap<PresistenceModels.AccountLock, Account.Models.AccountLock>();
      CreateMap<PresistenceModels.Account, Account.Models.Account>();
      CreateMap<PresistenceModels.AccountProperties, Account.Models.AccountProperties>();
    }
  }
}