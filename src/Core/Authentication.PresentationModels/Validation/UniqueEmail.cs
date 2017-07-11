using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.PresentationModels.Admin.EditModels;
using Authentication.User.Stores;

namespace Authentication.PresentationModels.Validation
{
  public class UniqueEmail: ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
     var registerEditModel = (AddUserEditModel) validationContext.ObjectInstance;
     var userStore = (IUserStore) validationContext.GetService(typeof(IUserStore));
     
     return userStore.AccountExistsAsync(registerEditModel.Email).Result
       ? new ValidationResult("Account already exists", new List<string> {"Email"})
       : ValidationResult.Success;
    }
  }
}