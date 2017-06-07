﻿using System.Linq;
using System.Threading.Tasks;
using Authentication.Account;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;
using Authentication.PresentationModels.ViewModels;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
  public class AccountController : DefaultController
  {
    private readonly IIdentityServerInteractionService interactionService;
    private readonly IAccountRepository accountRepository;

    public AccountController(
      IIdentityServerInteractionService interactionService, 
      IAccountRepository accountRepository)
    {
      this.interactionService = interactionService;
      this.accountRepository = accountRepository;
    }

    [HttpGet]
    public IActionResult Register() => View(new RegisterViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterEditModel form, 
      [FromServices] IFormResultRequestAsync<RegisterEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => View(form as RegisterViewModel),
        failure: () => View(form as RegisterViewModel));
    }

    [AcceptVerbs("GET", "POST")]
    public async Task<IActionResult> CheckAccountId(string email)
    {
      return await accountRepository.AccountExistsAsync(email) 
        ? Json(data: "Account already exists")
        : Json(data: true);
    }

    [HttpGet]
    public IActionResult Login() => View(new LoginViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(LoginEditModel form, 
      [FromServices] IFormResultRequest<LoginEditModel> request)
    {
      return Form(form, request,
        success: () =>
        {
          var account = accountRepository.Find(form.Email);
          if (account.Properties.HasMultiFactorAuth) ;
          //TODO

          if (account.Properties.PasswordResetRequired) ;
          //TODO

          return RedirectToAction(nameof(AccountController.Logout));
        },
        failure: () => View(form as LoginViewModel));
    }

    [HttpGet]
    [Authorize]
    public IActionResult Logout()
    {
      var claims = User.Claims
        .Select(c => new {c.Type, c.Value});

      return new JsonResult(claims);
    }
  }
}
