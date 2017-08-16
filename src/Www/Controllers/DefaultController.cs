using System;
using System.Threading.Tasks;
using Authentication.Application.DomainModels.Contracts;
using Authentication.Core;
using Authentication.Core.Requests.Contracts;
using Authentication.User.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
  public abstract class DefaultController : Controller
  {
    public IApplicationContext ApplicationContext { get; set; }

    public UserManager<User.Models.User> UserManager { get; set; }

    public SignInManager<User.Models.User> SignInManager { get; set; }

    internal async Task<IActionResult> FormAsync<TForm>(
      TForm form,
      IFormResultRequestAsync<TForm> request,
      Func<IActionResult> success,
      Func<IActionResult> failure)
    {
      if (ModelState.IsValid)
      {
        var formResult = await request.HandleAsync(form);
        if (formResult.Result is FormResultKind.Success)
          return success();

        ModelState.AddModelError(String.Empty, formResult.ErrorMessage);
      }
      return failure();
    }

    internal async Task<IActionResult> FormAsync<TForm>(
      TForm form,
      IFormResultRequestAsync<TForm> request,
      Func<Task<IActionResult>> success,
      Func<IActionResult> failure)
    {
      if (ModelState.IsValid)
      {
        var formResult = await request.HandleAsync(form);
        if (formResult.Result is FormResultKind.Success)
          return await success();

        ModelState.AddModelError(String.Empty, formResult.ErrorMessage);
      }
      return failure();
    }

    internal async Task<IActionResult> FormAsync<TForm>(
      TForm form,
      IFormResultRequestAsync<TForm> request,
      Func<IActionResult> success,
      Func<Task<IActionResult>> failure)
    {
      if (ModelState.IsValid)
      {
        var formResult = await request.HandleAsync(form);
        if (formResult.Result is FormResultKind.Success)
          return success();

        ModelState.AddModelError(String.Empty, formResult.ErrorMessage);
      }
      return await failure();
    }
  }
}