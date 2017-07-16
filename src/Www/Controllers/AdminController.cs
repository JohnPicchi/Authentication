using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.Admin.EditModels;
using Authentication.PresentationModels.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
    public async Task<IActionResult> VerifyAccountName(string email)
    {
      return await UserStore.AccountNameExistsAsync(email)
        ? Json(data: "Account already exists")
        : Json(data: true);
    }

    // GET & POST: /Admin/VerifyRoleName
    [AcceptVerbs("GET", "POST")]
    [AllowAnonymous]
    public async Task<IActionResult> VerifyRoleName(string roleName)
    {
      return await RoleStore.RoleNameExistsAsync(roleName)
        ? Json(data: "Role already exists")
        : Json(data: true);
    }

    // POST: /Admin/Role
    [HttpPost]
    public async Task<IActionResult> AddRole(AddRoleEditModel form,
      [FromServices] IFormResultRequestAsync<AddRoleEditModel> request)
    {
      return await FormAsync(form, request,
        success: () =>
        {
          var roleId = RoleStore.Roles
          .Where(r => r.Name == form.RoleName)
          .Select(r => r.Id);
          return RedirectToAction(nameof(AdminController.EditRole), new {roleId = roleId});
        },
        failure: () => View("Error"));
    }

    // GET: /Admin/EditRole
    [HttpGet]
    public async Task<IActionResult> EditRole(Guid? roleId = null)
    {
      if (roleId != null)
      {
        var role = await RoleStore.FindByIdAsync(roleId.ToString(), CancellationToken.None);
        var viewModel = new EditRoleViewModel
        {
          RoleId = role.Id,
          DateCreated = role.DateCreated,
          DateUpdated = role.DateUpdated 
        };
        return View(viewModel);
      }
      return RedirectToAction(nameof(AdminController.Index));
    }

    // POST: /Admin/EditRole
    public async Task<IActionResult> EditRole(EditRoleEditModel form,
      [FromServices] IFormResultRequestAsync<EditRoleEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(EditRole), new { roleId = form.Id}),
        failure: () => View("Error"));
    }

    // POST: /Admin/AddRoleClaim
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> AddRoleClaim(AddRoleClaimEditModel form,
      [FromServices] IFormResultRequestAsync<AddRoleClaimEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AdminController.EditRole), new {roleId = form.RoleId}),
        failure: () => View("Error"));
    }

    // GET: /Admin/EditRoleClaim
    [HttpGet]
    [AllowAnonymous]
    public IActionResult EditRoleClaim()
    {
      return View("Error");
    }

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