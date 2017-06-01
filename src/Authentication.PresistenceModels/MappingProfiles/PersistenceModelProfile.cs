using Authentication.Account.Factories;
using Authentication.PresistenceModels.Models;
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
      CreateMap<Models.User, User.Models.User>()
        .ConstructUsing(c => UserFactory.Create());

      CreateMap<Models.Account, Account.Models.Account>()
        .ConstructUsing(c => AccountFactory.Create());

      CreateMap<AccountProperties, Account.Models.AccountProperties>()
        .ConstructUsing(c => AccountPropertiesFactory.Create());

      CreateMap<AccountClaim, Account.Models.AccountClaim>()
        .ConstructUsing(c => AccountClaimFactory.Create());

      CreateMap<AccountLock, Account.Models.AccountLock>()
        .ConstructUsing(c => AccountLockFactory.Create());

      CreateMap<AccountToken, Account.Models.AccountToken>()
        .ConstructUsing(c => AccountTokenFactory.Create());
    }

    public IUserFactory UserFactory { get; set; }

    public IAccountFactory AccountFactory { get; set; }

    public IAccountPropertiesFactory AccountPropertiesFactory { get; set; }

    public IAccountClaimFactory AccountClaimFactory { get; set; }

    public IAccountLockFactory AccountLockFactory { get; set; }

    public IAccountTokenFactory AccountTokenFactory { get; set; }
  }
}