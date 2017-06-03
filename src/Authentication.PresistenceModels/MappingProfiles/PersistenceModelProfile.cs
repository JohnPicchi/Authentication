﻿using Authentication.PresistenceModels.Models;
using Authentication.User;
using AutoMapper;

namespace Authentication.PresistenceModels.MappingProfiles
{

  /// <summary>
  /// Mappings from persistence models to domain models
  /// </summary>

  public class PersistenceModelProfile : Profile
  {
    public PersistenceModelProfile()
    {
      CreateMap<Models.User, User.Models.User>();

      CreateMap<Models.Account, Account.Models.Account>();

      CreateMap<AccountProperties, Account.Models.AccountProperties>();

      CreateMap<AccountClaim, Account.Models.AccountClaim>();

      CreateMap<AccountLock, Account.Models.AccountLock>();

      CreateMap<AccountToken, Account.Models.AccountToken>();
    }
  }
}