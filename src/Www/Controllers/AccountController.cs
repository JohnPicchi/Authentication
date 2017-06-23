﻿using System.Linq;
using System.Threading.Tasks;
using Authentication.Account;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;
using Authentication.PresentationModels.ViewModels;
using Authentication.Utilities.ExtensionMethods;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
  public class AccountController : DefaultController
  {
    private readonly IAccountRepository accountRepository;
    private readonly IIdentityServerInteractionService interactionService;

    public AccountController(IAccountRepository accountRepository, IIdentityServerInteractionService interactionService)
    {
      this.accountRepository = accountRepository;
      this.interactionService = interactionService;
    }

    [Authorize]
    public IActionResult Index()
    {
      var claims = User.Claims
        .Select(c => new { c.Type, c.Value });

      return new JsonResult(claims);
    }

    [HttpGet]
    public IActionResult Register() => View(new RegisterViewModel());

    [HttpPost]
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
    public IActionResult Login(string returnUrl = null)
    {
      var viewModel = new LoginViewModel { ReturnUrl = returnUrl };
      return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginEditModel form,
      [FromServices] IFormResultRequestAsync<LoginEditModel> request)
    {
      return await FormAsync(form, request,
        success: () =>
        {
         // var account = accountRepository.Find(form.Email);
         // if (account.Properties.HasMultiFactorAuth)
         //   return RedirectToAction();
         //
         // if (account.Properties.PasswordResetRequired)
         //   return RedirectToAction();
         //
         // if (form.ReturnUrl.HasValue() && interactionService.IsValidReturnUrl(form.ReturnUrl))
         //   return Redirect(form.ReturnUrl);

          return RedirectToAction(nameof(AccountController.Index));
        },

        failure: () => RedirectToAction("Index"));
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
