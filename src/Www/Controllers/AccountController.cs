using Authentication.Core.Contracts.HandlerContracts;
using Authentication.PresentationModels.EditModels;
using Authentication.PresentationModels.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
  public class AccountController : DefaultController
  {
    public IActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public IActionResult Register() => View(new RegisterViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegisterEditModel form, 
      [FromServices] IFormHandler<RegisterEditModel> formHandler)
    {
      return Form(form, formHandler,
        success: () => View(form as RegisterViewModel),
        failure: () => View(form as RegisterViewModel));
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
    public IActionResult Login(LoginEditModel form, 
      [FromServices] IFormHandler<LoginEditModel> formHandler)
    {
      return Form(form, formHandler,
        success: () => RedirectToAction("Logout"),
        failure: () => View(form as LoginViewModel));
    }

    [HttpGet]
    public IActionResult Logout()
    {
      return Json("Congrats you logged in");
    }
  }
}
