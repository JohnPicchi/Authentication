using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Application.DomainModels.Contracts;
using Authentication.Controllers;
using Authentication.User.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Authentication.Filters
{
  public class DefaultControllerPropertiesFilter : IAsyncActionFilter
  {
    private readonly IApplicationContext applicationContext;
    private readonly UserManager<User.Models.User> userManager;
    private readonly SignInManager<User.Models.User> signInManager;

    public DefaultControllerPropertiesFilter(
      IApplicationContext applicationContext,
      UserManager<User.Models.User> userManager,
      SignInManager<User.Models.User> signInManager)
    {
      this.applicationContext = applicationContext;
      this.userManager = userManager;
      this.signInManager = signInManager;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
      var controller = context.Controller as DefaultController;
      if (controller != null)
      {
        controller.ApplicationContext = applicationContext;
        controller.UserManager = userManager;
        controller.SignInManager = signInManager;;
      }
      await next();
    }
  }
}
