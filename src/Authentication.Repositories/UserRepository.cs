using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Core.Models.Contracts;
using Authentication.Database;
using Authentication.User;

namespace Authentication.Repositories
{
  public class UserRepository : Repository<PresistenceModels.User>, IUserRepository
  {
    public UserRepository(IApplicationSettings applicationSettings) : base(applicationSettings)
    {
    }
  }
}
