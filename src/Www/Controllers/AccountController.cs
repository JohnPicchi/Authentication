using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Authentication.Core.Requests;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.Account.EditModels;
using Authentication.PresentationModels.Account.ViewModels;
using Authentication.Utilities.ExtensionMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Authentication.Controllers
{
  [Authorize]
  public class AccountController : DefaultController
  {
    public const string ACCOUNT_LOCKED = "Account is locked";

    // GET: /Account
    public async Task<IActionResult> Index()
    {
      var user = await UserManager.GetUserAsync(User);
      var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);

      var claims = User.Claims
        .Select(c => new { c.Type, c.Value });

      return new JsonResult(claims);
    }

    // GET: /Account/Login
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login(string returnUrl = null) => View(new LoginEditModel { ReturnUrl = returnUrl });
    
    // POST: /Account/Login
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginEditModel form,
      [FromServices] IRequest<SignInResult, LoginEditModel> request)
    {
      var result = await request.HandleAsync(form);
      if (result.Succeeded)
      {
        if (form.ReturnUrl.HasValue())
          return Redirect(form.ReturnUrl);

        return RedirectToAction(nameof(AccountController.Index));
      }

      if (result.RequiresTwoFactor)
        return RedirectToAction(nameof(AccountController.SendCode), new { ReturnUrl = form.ReturnUrl, RememberMe = form.RememberLogin });

      if (result.IsLockedOut)
      {
        ModelState.AddModelError(String.Empty, ACCOUNT_LOCKED);
        return View(form);
      }

      ModelState.AddModelError(String.Empty, "Invalid username and/or password");
      return View(form);
    }

    // GET: /Account/Logout
    [HttpGet]
    public IActionResult Logout()
    {
      var claims = User.Claims
        .Select(c => new { c.Type, c.Value });

      return new JsonResult(claims);
    }

    // GET: /Account/SendCode
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> SendCode(string returnUrl = null, bool rememberMe = false)
    {
      var user = await SignInManager.GetTwoFactorAuthenticationUserAsync();
      if (user == null)
        return View("Error");
      
      return View(new SendLoginCodeViewModel
      {
        ReturnUrl = returnUrl,
        RememberMe = rememberMe,
        CodeProviders = await UserManager.GetValidTwoFactorProvidersAsync(user)
      });
    }

    // POST: /Account/SendCode
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> SendCode(SendLoginCodeEditModel form,
      [FromServices] IFormResultRequest<SendLoginCodeEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(
          nameof(AccountController.VerifyCode), 
          new { CodeProvider = form.CodeProvider, RememberMe = form.RememberMe, ReturnUrl = form.ReturnUrl }),
        failure: () => View(form as SendLoginCodeViewModel));
    }

    // GET: /Account/VerifyCode
    [HttpGet]
    [AllowAnonymous]
    public IActionResult VerifyCode(string codeProvider, bool rememberMe, string returnUrl = null)
    {
      return View(new VerifyLoginCodeEditModel
      {
        ReturnUrl = returnUrl,
        RememberMe = rememberMe,
        CodeProvider = codeProvider
      });
    }

    // POST: /Account/VerifyCode
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> VerifyCode(VerifyLoginCodeEditModel form,
      [FromServices] IRequest<SignInResult, VerifyLoginCodeEditModel> request)
    {
      var result = await request.HandleAsync(form);
      if (result.Succeeded)
      {
        if (form.ReturnUrl.HasValue())
          return Redirect(form.ReturnUrl);
        return RedirectToAction(nameof(AccountController.Index));
      }

      if (result.IsLockedOut)
      {
        ModelState.AddModelError(String.Empty, ACCOUNT_LOCKED);
        return View(form);
      }

      ModelState.AddModelError(String.Empty, "Invalid code");
      return View(form);
    }

    // GET: /Account/ResetPassword
    [HttpGet]
    [AllowAnonymous]
    public IActionResult ResetPassword(string email = null, string code = null)
    {
      return View(new ResetPasswordEditModel { Email = email ?? String.Empty, Code = code });
    }
    
    // POST: /Account/ResetPassword
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword(ResetPasswordEditModel form,
      [FromServices] IFormResultRequest<ResetPasswordEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AccountController.Login)),
        failure: () => View(form));
    }

    // GET: /Account/ForgotPassword
    [HttpGet]
    [AllowAnonymous]
    public IActionResult ForgotPassword() => View();

    // POST: /Account/ForgotPassword
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordEditModel form, 
      [FromServices] IFormResultRequest<ForgotPasswordEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AccountController.ForgotPasswordConfirmation)),
        failure: () => View(form));
    }

    // GET: /Account/ForgotPasswordConfirmation
    [HttpGet]
    [AllowAnonymous]
    public IActionResult ForgotPasswordConfirmation() => View();

    // GET: /Account/VerifyEmail
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> VerifyEmail(string userId = null, string code = null)
    {
      if (userId.HasValue() && code.HasValue())
      {
        var user = await UserManager.FindByIdAsync(userId);
        if (user != null)
        {
          var result = await UserManager.ConfirmEmailAsync(user, code);
          if (result.Succeeded)
            return View();
        }
      }
      return View();
    }

    // GET: /Account/ConfirmEmail
    [HttpGet]
    public async Task<IActionResult> ConfirmEmail([FromServices] ConfirmEmailRequest request)
    {
      var result = await request.HandleAsync();
      return View();
    }

    // GET: /Account/AddPhoneNumber
    [HttpGet]
    public IActionResult AddPhoneNumber() => View(new AddPhoneNumberEditModel());
    
    // POST: /Accout/AddPhoneNumber
    [HttpPost]
    public async Task<IActionResult> AddPhoneNumber(AddPhoneNumberEditModel form,
      [FromServices] IFormResultRequest<AddPhoneNumberEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AccountController.ConfirmPhoneNumber), new { PhoneNumber = form.PhoneNumber }),
        failure: () => View(form));
    }

    // GET: /Account/ConfirmPhoneNumber
    [HttpGet]
    public IActionResult ConfirmPhoneNumber(string phoneNumber = null)
    {
      return View(new ConfirmPhoneNumberViewModel {PhoneNumber = phoneNumber ?? String.Empty});
    }
    
    // POST: /Account/ConfirmPhoneNumber
    [HttpPost]
    public async Task<IActionResult> ConfirmPhoneNumber(ConfirmPhoneNumberEditModel form,
      [FromServices] IFormResultRequest<ConfirmPhoneNumberEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AccountController.Settings)),
        failure: async () =>
        {
          var user = await UserManager.GetUserAsync(User);
          var viewModel = form as ConfirmPhoneNumberViewModel ?? new ConfirmPhoneNumberViewModel();
          viewModel.PhoneNumber = user.PhoneNumber;
          return View(viewModel);
        });
    }

    // GET: /Account/Settings
    [HttpGet]
    public async Task<IActionResult> Settings()
    {
      var user = await UserManager.GetUserAsync(User);
      var viewModel = new AccountSettingsEditModel
      {
        FirstName = user.FirstName,
        LastName = user.LastName,
        PhoneNumber = user.PhoneNumber
      };
      return View(viewModel);
    }

    // POST: /Account/Settings
    [HttpPost]
    public async Task<IActionResult> Settings(AccountSettingsEditModel form,
      [FromServices] IFormResultRequest<AccountSettingsEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AccountController.Index)),
        failure: () =>
        {
          var viewModel = form;
          return View(viewModel);
        });
    }
  }
}