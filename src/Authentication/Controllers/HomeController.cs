using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
  public class HomeController : DefaultController
  {
    public IActionResult Index()
    {
      return RedirectToAction("Login", "Account");
    }
  }
}
