using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Authentication.Core.Models.Contracts;
using Authentication.Database;
using Authentication.Database.Contexts;
using Authentication.User;
using AutoMapper;

namespace Authentication.Repositories
{
  public class UserRepository : Repository<PresistenceModels.Models.User>, IUserRepository
  {
    private readonly IMapper mapper;

    public UserRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext)
    {
      this.mapper = mapper;
    }

    public IUserFactory UserFactory { get; set; }

    public void Add(User.Models.User user)
    {
      if (user != null)
      {
        var persistedUser = mapper.Map(user, new PresistenceModels.Models.User());
        base.Add(persistedUser);
        if (user.IsNew)
          user.Id = persistedUser.Id;
      }
    }

    public User.Models.User Find(Guid userId)
    {
      var persistedUser = base.Find(userId);

      return persistedUser == null
        ? null
        : mapper.Map(persistedUser, UserFactory.Create());
    }

    public User.Models.User FindByAccountId(Guid accountId)
    {
      var persistedUser = Query()
        .SingleOrDefault(a => a.AccountId == accountId);

      return persistedUser == null
        ? null
        : mapper.Map(persistedUser, UserFactory.Create());
    }

    public bool Update(User.Models.User user)
    {
      if (user != null && !user.IsNew)
      {
        var persistedUser = base.Find(user.Id);
        if (persistedUser == null)
        {
          persistedUser = new PresistenceModels.Models.User();
          mapper.Map(user, persistedUser);

          base.Add(persistedUser);
        }
        else
          mapper.Map(user, persistedUser);
        return true;
      }
      return false;
    }

    public bool AddOrUpdate(User.Models.User user)
    {
      throw new NotImplementedException();
    }

    public void Remove(Guid userId) => base.Remove(new PresistenceModels.Models.User{Id = userId});

    public void Remove(User.Models.User user) => Remove(user.Id);
  }
}
