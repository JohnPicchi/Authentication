using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Authentication.Core.Requests.Contracts;
using Authentication.PresentationModels.Admin.EditModels;
using Authentication.PresentationModels.Admin.ViewModels;
using Authentication.Utilities.ExtensionMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Controllers
{
  //[Authorize]
  [Authorize(Policy = "UserManagement")]
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
      return email.HasValue() && await UserManager.Users.AnyAsync(u => u.Email == email)
        ? Json(data: "Account already exists")
        : Json(data: true);
    }

    // GET & POST: /Admin/VerifyRoleName
    [AcceptVerbs("GET", "POST")]
    public async Task<IActionResult> VerifyRoleName(string name)
    {
      return name.HasValue() && await RoleManager.RoleExistsAsync(name)
        ? Json(data: "Role already exists")
        : Json(data: true);
    }

    // POST: /Admin/AddRole
    [HttpPost]
    public async Task<IActionResult> AddRole(AddRoleEditModel form,
      [FromServices] IFormResultRequestAsync<AddRoleEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AdminController.EditRole), new {roleId = form.RoleId}),
        failure: () => View("Error"));
    }

    // GET: /Admin/EditRole
    [HttpGet]
    public async Task<IActionResult> EditRole(Guid? roleId = null)
    {
      if (roleId != null && roleId != Guid.Empty)
      {
        var role = await RoleManager.Roles
          .Where(r => r.Id == roleId)
          .Include(r => r.Claims)   //Lazy loading still not implemented?....what the fuck
          .SingleAsync();

        if (role != null)
        {
          var viewModel = new EditRoleViewModel
          {
            DateCreated = role.DateCreated,
            DateUpdated = role.DateUpdated,
            RoleClaims = role.Claims.OrderBy(c => c.ClaimValue).Select(c => new RoleClaimViewModel
            {
              Id = c.Id,
              ClaimValue = c.ClaimValue,
              ClaimType = c.ClaimType
            }).ToList(),
            Role = new EditRoleEditModel{ RoleId = role.Id, RoleName = role.Name },
            RoleClaim = new AddRoleClaimEditModel { RoleId = role.Id}
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
        success: () => RedirectToAction(nameof(EditRole), new { roleId = form.RoleId}),
        failure: () => View("Error"));
    }

    //POST: /Admin/DeleteRole
    public async Task<IActionResult> DeleteRole(DeleteRoleEditModel form,
      [FromServices] IFormResultRequestAsync<DeleteRoleEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AdminController.Index)),
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
    public async Task<IActionResult> DeleteRoleClaim(DeleteRoleClaimEditModel form,
      [FromServices] IFormResultRequestAsync<DeleteRoleClaimEditModel> request)
    {
      return await FormAsync(form, request,
        success: () => RedirectToAction(nameof(AdminController.EditRole), new {roleId = form.RoleId}),
        failure: () => View("Error"));
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
    public async Task<IActionResult> EditUser(Guid? userId = null)
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