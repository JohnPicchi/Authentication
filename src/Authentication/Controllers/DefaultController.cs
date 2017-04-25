using System;
using Authentication.Core.Contracts.HandlerContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Authentication.Controllers
{
  public abstract class DefaultController : Controller
  {
    internal IActionResult Form<TForm>(TForm form, IFormHandler<TForm> formHandler, Func<IActionResult> success, Func<IActionResult> failure)
    {
      if (!ModelState.IsValid)
        return failure();

      var formResult = formHandler.Handle(form);

      if (!formResult.Success)
      {
        ModelState.AddModelError("error", formResult.ErrorMessage);
        failure();
      }

      return success();
    }
  }
}
