using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
  public class AdminController : DefaultController
  {
    public IActionResult Index()
    {
        return View();
    }
  }
}
