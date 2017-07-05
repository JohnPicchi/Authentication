using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Authentication.Core.Requests;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;
using Authentication.PresentationModels.ViewModels;
using Authentication.User.Stores;
using Authentication.Utilities.ExtensionMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
  [Authorize]
  public class AccountController : DefaultController
  {
    public const string ACCOUNT_LOCKED = "Account is locked";

    private readonly SignInManager<User.Models.User> signInManager;
    private readonly UserManager<User.Models.User> userManager;
    private readonly IUserStore userStore;

    public AccountController(
      SignInManager<User.Models.User> signInManager,
      UserManager<User.Models.User> userManager,
      IUserStore userStore)
    {
      this.signInManager = signInManager;
      this.userManager = userManager;
      this.userStore = userStore;
    }

    // GET: /Account
    public async Task<IActionResult> Index()
    {
      var user = await userManager.GetUserAsync(User);
      var code = await userManager.GenerateEmailConfirmationTokenAsync(user);

      var claims = User.Claims
        .Select(c => new { c.Type, c.Value });

      return new JsonResult(claims);
    }

    // GET: /Account/Register
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register() => View(new RegisterViewModel());

    // POST: /Account/Register
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterEditModel form,
      [FromServices] IFormResultRequestAsync<RegisterEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AccountController.Login)),
        failure: () => View(form as RegisterViewModel));
    }

    // GET & POST: /Account/CheckAccountId
    [AcceptVerbs("GET", "POST")]
    [AllowAnonymous]
    public async Task<IActionResult> CheckAccountId(string email)
    {
      var userExists = await userStore.AccountExistsAsync(email);
      return userExists
        ? Json(data: "Account already exists")
        : Json(data: true);
    }

    // GET: /Account/Login
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login(string returnUrl = null) => View(new LoginViewModel { ReturnUrl = returnUrl });
    
    // POST: /Account/Login
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginEditModel form,
      [FromServices] LoginRequestAsync request)
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
        return View(form as LoginViewModel);
      }

      ModelState.AddModelError(String.Empty, "Invalid username and/or password");
      return View(form as LoginViewModel);
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
      var user = await signInManager.GetTwoFactorAuthenticationUserAsync();
      
      if (user == null)
        return View("Error");
      
      return View(new SendLoginCodeViewModel
      {
        ReturnUrl = returnUrl,
        RememberMe = rememberMe,
        CodeProviders = await userManager.GetValidTwoFactorProvidersAsync(user)
      });
    }

    // POST: /Account/SendCode
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> SendCode(SendLoginCodeEditModel form,
      [FromServices] IFormResultRequestAsync<SendLoginCodeEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AccountController.VerifyCode), new { CodeProvider = form.CodeProvider, RememberMe = form.RememberMe, ReturnUrl = form.ReturnUrl }),
        failure: () => View(form as SendLoginCodeViewModel));
    }

    // GET: /Account/VerifyCode
    [HttpGet]
    [AllowAnonymous]
    public IActionResult VerifyCode(string codeProvider, bool rememberMe, string returnUrl = null)
    {
      return View(new VerifyLoginCodeViewModel
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
      [FromServices] VerifyLoginCodeRequestAsync request)
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
        return View(form as VerifyLoginCodeViewModel);
      }

      ModelState.AddModelError(String.Empty, "Invalid code");
      return View(form as VerifyLoginCodeViewModel);
    }

    // GET: /Account/ResetPassword
    [HttpGet]
    [AllowAnonymous]
    public IActionResult ResetPassword(string email = null, string code = null)
    {
      return View(new ResetPasswordViewModel { Email = email ?? String.Empty, Code = code });
    }
    
    // POST: /Account/ResetPassword
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword(ResetPasswordEditModel form,
      [FromServices] IFormResultRequestAsync<ResetPasswordEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AccountController.Login)),
        failure: () => View(form as ResetPasswordViewModel));
    }

    // GET: /Account/ForgotPassword
    [HttpGet]
    [AllowAnonymous]
    public IActionResult ForgotPassword() => View();

    // POST: /Account/ForgotPassword
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordEditModel form, 
      [FromServices] IFormResultRequestAsync<ForgotPasswordEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AccountController.ForgotPasswordConfirmation)),
        failure: () => View(form as ForgotPasswordViewModel));
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
        var user = await userManager.FindByIdAsync(userId);
        if (user != null)
        {
          var result = await userManager.ConfirmEmailAsync(user, code);
          if (result.Succeeded)
            return View();
        }
      }
      return View();
    }

    // GET: /Account/ConfirmEmail
    [HttpGet]
    public async Task<IActionResult> ConfirmEmail([FromServices] ConfirmEmailRequestAsync request)
    {
      var result = await request.HandleAsync();
      return View();
    }

    // POST: /Accout/AddPhoneNumber
    [HttpPost]
    public async Task<IActionResult> AddPhoneNumber(AddPhoneNumberEditModel form,
      [FromServices] IFormResultRequestAsync<AddPhoneNumberEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AccountController.ConfirmPhoneNumber), new { PhoneNumber = form.PhoneNumber }),
        failure: () => View(form as AddPhoneNumberViewModel));
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
      [FromServices] IFormResultRequestAsync<ConfirmPhoneNumberEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AccountController.Settings)),
        failure: async () =>
        {
          var user = await userManager.GetUserAsync(User);
          var viewModel = form as ConfirmPhoneNumberViewModel ?? new ConfirmPhoneNumberViewModel();
          viewModel.PhoneNumber = user.PhoneNumber;
          return View(viewModel);
        });
    }

    // GET: /Account/Settings
    [HttpGet]
    public async Task<IActionResult> Settings()
    {
      var user = await userManager.GetUserAsync(User);
      var viewModel = new AccountSettingsViewModel
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
      [FromServices] IFormResultRequestAsync<AccountSettingsEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AccountController.Index)),
        failure: () =>
        {
          var viewModel = form as AccountSettingsViewModel;
          return View(viewModel);
        });
    }
  }
}