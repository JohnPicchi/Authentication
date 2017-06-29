using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
  public class AdminController : DefaultController
  {
    public async Task<IActionResult> Index()
    {
        return View();
    }
  }
}