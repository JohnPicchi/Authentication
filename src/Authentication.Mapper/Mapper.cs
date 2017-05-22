using System;
using Authentication.Domain.Account.Models;
using AutoMapper;

namespace Authentication.Mapper
{
  public class Mapper
  {
    public static MapperConfiguration Configuration()
    {
      return new MapperConfiguration(cfg =>
      {
        cfg.AddProfile<DomainProfile>();
        cfg.AddProfile<PersistenceProfile>();
      });
    }
  }

  public class DomainProfile : Profile
  {
    public DomainProfile()
    {
      CreateMap<User, PresistenceModels.User>();
      CreateMap<Token, PresistenceModels.AccountToken>();
      CreateMap<Claim, PresistenceModels.Claim>();
      CreateMap<Account, PresistenceModels.Account>();
      CreateMap<AccountProperties, PresistenceModels.AccountProperties>();
    }
  }

  public class PersistenceProfile : Profile
  {
    public PersistenceProfile()
    {
      CreateMap<PresistenceModels.User, User>();
      CreateMap<PresistenceModels.AccountToken, Token>();
      CreateMap<PresistenceModels.Claim, Claim>();
      CreateMap<PresistenceModels.Account, Claim>();
      CreateMap<PresistenceModels.AccountProperties, AccountProperties>();
    }
  }
}
