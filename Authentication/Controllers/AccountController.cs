using System;
using Authentication.Core.Contracts;
using Authentication.Core.Helpers;
using Authentication.Database;
using Authentication.Mediatr.Requests;
using Authentication.PresentationModels.EditModels;
using Authentication.PresentationModels.ViewModels;
using Authentication.Services;
using IdentityServer4.Services;
using MediatR;
using Microsoft.AspNetCore.Antiforgery.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
  public class AccountController : DefaultController
  {
    private IIdentityServerInteractionService interactionService;
    private IMediator mediator;
    private IPasswordService passwordService;

    public AccountController(IIdentityServerInteractionService interactionService, IMediator mediator, IPasswordService passwordService)
    {
      this.interactionService = interactionService;
      this.mediator = mediator;
      this.passwordService = passwordService;
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public IActionResult Register() => View(new RegisterViewModel());


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegisterEditModel form)
    {
      return View();
    }

   // [AcceptVerbs(Helpers.Http.Actions.Get, Helpers.Http.Actions.Post)]
   // public IActionResult VerifyEmail(string email)
   // {
   //   if (!_userRepository.VerifyEmail(email))
   //   {
   //     return Json(data: $"Email {email} is already in use.");
   //   }
   //   return Json(data: true);
   // }

    [HttpGet]
    public IActionResult Login() => View(new LoginViewModel());


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(LoginEditModel form)
    {
      return null;
    }

    [HttpGet]
    public IActionResult Logout()
    {
      return View();
    }
  }
}
