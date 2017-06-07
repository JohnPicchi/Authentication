using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.User
{
  public interface IUserRepository
  {
    void Add(Models.User user);

    Models.User Find(Guid userId);

    Models.User FindByAccountId(Guid userId);

    bool Update(Models.User user);

    bool AddOrUpdate(Models.User user);

    void Remove(Guid userId);

    void Remove(Models.User user);
  }
}
