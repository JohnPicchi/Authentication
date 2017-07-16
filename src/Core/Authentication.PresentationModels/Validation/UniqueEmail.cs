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
     var form = validationContext.ObjectInstance as AddUserEditModel;
     var userStore = validationContext.GetService(typeof(IUserStore)) as IUserStore;
     
     return userStore.AccountNameExistsAsync(form.Email).GetAwaiter().GetResult()
       ? new ValidationResult("Account already exists", new List<string> {nameof(AddUserEditModel.Email)})
       : ValidationResult.Success;
    }
  }
}