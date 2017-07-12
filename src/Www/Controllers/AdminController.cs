using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.Admin.EditModels;
using Authentication.PresentationModels.Admin.ViewModels;
using Authentication.User.Stores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
  [Authorize]
  public class AdminController : DefaultController
  {
    private readonly IRoleStore roleStore;

    public AdminController(IRoleStore roleStore)
    {
      this.roleStore = roleStore;
    }

    public IActionResult Index()
    {
      return View(new AdminViewModel());
    }
   
    // POST: /Admin/Role
    [HttpPost]
    public async Task<IActionResult> AddRole(AddRoleEditModel form,
      [FromServices] IFormResultRequestAsync<AddRoleEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AdminController.EditRole), new {roleName = form.RoleName}),
        failure: () => View("Error"));
    }

    // GET: /Admin/EditRole
    [HttpGet]
    public async Task<IActionResult> EditRole(string roleName = null)
    {
      var role = await roleStore.FindByNameAsync(roleName, new CancellationToken());
      var viewModel = new EditRoleViewModel
      {
        RoleId = role.Id,
        RoleName = role.Name
      };
      return View(viewModel);
    }

    // POST: /Admin/EditRole
    public async Task<IActionResult> EditRole(EditRoleEditModel form,
      [FromServices] IFormResultRequestAsync<EditRoleEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => View(),
        failure: () => View());
    }

    // GET: /Account/AddUser
    [HttpGet]
    [AllowAnonymous]
    public IActionResult AddUser() => View(new AddUserViewModel());

    // POST: /Admin/AddUser
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> AddUser(AddUserEditModel form,
      [FromServices] IFormResultRequestAsync<AddUserEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AdminController.EditUser), new {userEmail = form.Email}),
        failure: () => View(form as AddUserViewModel));
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