using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Authentication.PresentationModels.Admin.EditModels;
using Authentication.User.Stores;
using Microsoft.EntityFrameworkCore;

namespace Authentication.PresentationModels.Validation
{
  public class UniqueRoleName : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      var form = validationContext.ObjectInstance as EditRoleEditModel;
      var roleStore = validationContext.GetService(typeof(IRoleStore)) as IRoleStore;

      return roleStore.Roles.AnyAsync(r => r.Name == form.Name && r.Id != form.Id).GetAwaiter().GetResult()
        ? new ValidationResult("Account already exists", new List<string> { nameof(EditRoleEditModel.Name) })
        : ValidationResult.Success;
    }
  }
}
