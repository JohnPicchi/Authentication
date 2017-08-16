using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.PresentationModels.Admin.EditModels;
using Authentication.Utilities.ExtensionMethods;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Authentication.PresentationModels.Validation
{
  public class UniqueEmail: ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
     var form = validationContext.ObjectInstance as AddUserEditModel;
     var userManager = validationContext.GetService(typeof(UserManager<User.Models.User>)) as UserManager<User.Models.User>;
      if ((form?.Email?.HasValue() ?? false) && (userManager != null))
        return userManager.Users.AnyAsync(u => u.Email == form.Email).GetAwaiter().GetResult()
       ? new ValidationResult("Account already exists", new List<string> {nameof(AddUserEditModel.Email)})
       : ValidationResult.Success;

      return new ValidationResult(
        "Unable to verify if account already exists",
        new List<string> {nameof(AddUserEditModel.Email)});
    }
  }
}