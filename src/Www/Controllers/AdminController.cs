using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Authentication.Core;
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
      [FromServices] IFormResultRequest<AddUserEditModel> request)
    {
      return await FormAsync(form, request,
        success: async () =>
        {
          var user = await UserManager.FindByEmailAsync(form.Email);
          return RedirectToAction(nameof(AdminController.EditUser), new {userId = user.Id});
        },
        failure: () => View("Error"));
    }

    // GET: /Admin/EditUser
    [HttpGet]
    public async Task<IActionResult> EditUser(Guid userId,
      [FromServices] IViewModelFactoryAsync<EditUserViewModel> factory)
    {
      var viewModel = await factory.BuildAsync(userId);
      return View(viewModel);
    }
   
    // POST: /Admin/EditUser
    [HttpPost]
    public async Task<IActionResult> EditUser(EditUserEditModel form,
      [FromServices] IFormResultRequest<EditUserEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => View(),
        failure: () => View());
    }
  }
}