using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Domain;

namespace Authentication.User
{

  public interface IUserFactory : IFactory<Models.User>
  {
    
  }

  public class UserFactory : IUserFactory
  {
    private Models.User.Factory userFactory;

    public UserFactory(Models.User.Factory userFactory)
    {
      this.userFactory = userFactory;
    }
    public Models.User Create()
    {
      return userFactory.Invoke();
    }
  }
}
