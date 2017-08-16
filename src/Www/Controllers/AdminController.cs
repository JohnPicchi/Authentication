using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.Admin.EditModels;
using Authentication.PresentationModels.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Controllers
{
  //[Authorize]
  public class AdminController : DefaultController
  {
    public IActionResult Index()
    {
      return View(new AdminViewModel());
    }

    // GET & POST: /Admin/VerifyAccountName
    [AcceptVerbs("GET", "POST")]
    public async Task<IActionResult> VerifyAccountName(string email)
    {
      return await UserManager.Users.AnyAsync(u => u.Email == email)
        ? Json(data: "Account already exists")
        : Json(data: true);
    }

    // POST: /Admin/AddUser
    [HttpPost]
    public async Task<IActionResult> AddUser(AddUserEditModel form,
      [FromServices] IFormResultRequestAsync<AddUserEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AdminController.EditUser), new {userEmail = form.Email}),
        failure: () => View("Error"));
    }

    // GET: /Admin/EditUser
    [HttpGet]
    public async Task<IActionResult> EditUser(string userEmail = null)
    {
      return View();
    }
   
    // POST: /Admin/EditUser
    [HttpPost]
    public async Task<IActionResult> EditUser(EditUserEditModel form,
      [FromServices] IFormResultRequestAsync<EditUserEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => View(),
        failure: () => View());
    }

    // GET: /Admin/Search
    [HttpGet]
    public async Task<IActionResult> Search(AdminSearchEditModel form,
      [FromServices] IFormResultRequestAsync<AdminSearchViewModel> request)
    {
      if (form.Query == null || form.Kind == null)
        return View(new AdminSearchViewModel());

      var viewModel = form as AdminSearchViewModel;
      return await FormAsync(viewModel, request,
        success: () => View(viewModel),
        failure: () => View());
    }
  }
}