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
      return await UserStore.AccountNameExistsAsync(email)
        ? Json(data: "Account already exists")
        : Json(data: true);
    }

    // GET & POST: /Admin/VerifyRoleName
    [AcceptVerbs("GET", "POST")]
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
        if (role != null)
        {
          var viewModel = new EditRoleViewModel
          {
            RoleId = role.Id,
            DateCreated = role.DateCreated,
            DateUpdated = role.DateUpdated,
            RoleClaims = role.Claims.Select(c => new RoleClaimViewModel
            {
              Id = c.Id,
              ClaimValue = c.ClaimValue,
              ClaimType = c.ClaimType
            })
          };
          return View(viewModel);
        }
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
    public async Task<IActionResult> AddRoleClaim(AddRoleClaimEditModel form,
      [FromServices] IFormResultRequestAsync<AddRoleClaimEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AdminController.EditRole), new {roleId = form.RoleId}),
        failure: () => View("Error"));
    }

    // GET: /Admin/EditRoleClaim
    [HttpGet]
    public IActionResult EditRoleClaim(int? roleClaimId = null)
    {
      if (roleClaimId.HasValue)
      {
        
      }

      return View("Error");
    }

    // POST: /Admin/EditRoleClaim
    [HttpGet]
    public async Task<IActionResult> EditRoleClaim(EditRoleClaimEditModel form,
      [FromServices] IFormResultRequestAsync<EditRoleClaimEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AdminController.EditRole), new {roleId = form}),
        failure: () => View("Error"));
    }

    // POST: /Admin/DeleteRoleClaim
    [HttpPost]
    public async Task<IActionResult> DeleteRoleClaim(DeleteRoleClaimEditModel form)
    {
      var role = await RoleStore.Roles
        .SingleAsync(r => r.Id == form.RoleId);

      var roleClaim = role.Claims
        .Single(r => r.Id == form.Id)
        .ToClaim();

      await RoleStore.RemoveClaimAsync(role, roleClaim, CancellationToken.None);
      return RedirectToAction(nameof(AdminController.EditRole), new {roleId = form.RoleId});
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