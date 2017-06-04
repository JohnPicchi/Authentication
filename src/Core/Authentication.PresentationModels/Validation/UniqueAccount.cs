using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Account;
using Authentication.PresentationModels.EditModels;

namespace Authentication.PresentationModels.Validation
{
  public class UniqueAccount: ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      var registerEditModel = (RegisterEditModel) validationContext.ObjectInstance;
      var accountRepository = (IAccountRepository) validationContext.GetService(typeof(IAccountRepository));

      return accountRepository.AccountExistsAsync(registerEditModel.Email).Result
        ? new ValidationResult("Account already exists", new List<string> {"Email"})
        : ValidationResult.Success;
    }
  }
}