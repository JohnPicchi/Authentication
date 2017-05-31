using Authentication.Account;
using Authentication.Account.Repositories;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;
using Authentication.PresentationModels.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
  public class AccountController : DefaultController
  {
    private readonly IAccountRepository accountRepository;

    public AccountController(IAccountRepository accountRepository)
    {
      this.accountRepository = accountRepository;
    }

    [HttpGet]
    public IActionResult Register() => View(new RegisterViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegisterEditModel form, 
      [FromServices] IFormResultRequest<RegisterEditModel> request)
    {
      return Form(form, request,
        success: () => View(form as RegisterViewModel),
        failure: () => View(form as RegisterViewModel));
    }

    [AcceptVerbs("GET", "POST")]
    [ValidateAntiForgeryToken]
    public IActionResult CheckAccountId(string email)
    {
      return accountRepository.AccountExists(email) 
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
          //TODO
          return accountRepository.Find(form.Email).Properties.HasMultiFactorAuth 
          ? RedirectToAction(nameof(Logout))
          : RedirectToAction(nameof(Register));
        },
        failure: () => View(form as LoginViewModel));
    }

    [HttpGet]
    public IActionResult Logout()
    {
      return Json("Congrats you logged out");
    }
  }
}
