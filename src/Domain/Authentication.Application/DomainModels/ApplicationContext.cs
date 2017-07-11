using System;
using System.Threading.Tasks;
using Authentication.Application.DomainModels.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using IApplicationSettings = Authentication.Application.DomainModels.Contracts.IApplicationSettings;

namespace Authentication.Application.DomainModels
{
  public class ApplicationContext : IApplicationContext
  {
    private UserManager<User.Models.User> userManager;
    private readonly HttpContext httpContext;

    private User.Models.User user;

    //Denies writes when true. Is set to true
    //after first access to 'User' property
    private bool userWriteGuard;

    public ApplicationContext(
      IApplicationSettings applicationSettings,
      UserManager<User.Models.User> userManager,
      IHttpContextAccessor httpContextAccessor)
    {
      ApplicationSettings = applicationSettings;
      this.httpContext = httpContextAccessor.HttpContext;
      this.userManager = userManager;
    }

    public IApplicationSettings ApplicationSettings { get; private set; }

    public User.Models.User User => GetUser();

    private User.Models.User GetUser()
    {
      if (user == null && !userWriteGuard)
      {
        userWriteGuard = true;
        return user = userManager.GetUserAsync(httpContext.User).GetAwaiter().GetResult();
      }
      return user;
    }
  }
}