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
      if(form?.Name?.HasValue() ?? false)
        return roleManager.Roles.AnyAsync(r => r.Name == form.Name && r.Id != form.Id).GetAwaiter().GetResult()
          ? new ValidationResult("Account already exists", new List<string> {nameof(BaseRoleEditModel.Name)})
          : ValidationResult.Success;

      return new ValidationResult(
        "Unable to verify if role already exists due to invalid form values", 
        new List<string> {nameof(BaseRoleEditModel.Name)});
    }
  }
}
