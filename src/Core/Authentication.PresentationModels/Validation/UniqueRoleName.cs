using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Authentication.PresentationModels.Admin.EditModels;
using Authentication.User.Models;
using Authentication.Utilities.ExtensionMethods;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Authentication.PresentationModels.Validation
{
  public class UniqueRoleName : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      var form = validationContext.ObjectInstance as BaseRoleEditModel;
      var roleManager= validationContext.GetService(typeof(RoleManager<Role>)) as RoleManager<Role>;
      if(form?.RoleName?.HasValue() ?? false)
        return roleManager.Roles.AnyAsync(r => r.Name == form.RoleName && r.Id != form.RoleId).GetAwaiter().GetResult()
          ? new ValidationResult("Account already exists", new List<string> {nameof(BaseRoleEditModel.RoleName)})
          : ValidationResult.Success;

      return new ValidationResult(
        "Unable to verify if role already exists", 
        new List<string> {nameof(BaseRoleEditModel.RoleName)});
    }
  }
}
