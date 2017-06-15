using System.Linq;
using System.Threading.Tasks;
using Authentication.Account;
using Authentication.Core.Requests;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.EditModels;
using Authentication.PresentationModels.Validation;
using Authentication.PresentationModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

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
    public async Task<IActionResult> Login(LoginEditModel form,
      [FromServices] IFormResultRequestAsync<LoginEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction("Logout"),
        failure: () => RedirectToAction("Login"));
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
