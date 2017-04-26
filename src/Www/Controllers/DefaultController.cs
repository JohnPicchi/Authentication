

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using System;
using Authentication.Core.Contracts.HandlerContracts;
using Authentication.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
  public abstract class DefaultController : Controller
  {
    internal IActionResult Form<TForm>(TForm form, IFormResultRequest<TForm> request, Func<IActionResult> success, Func<IActionResult> failure)
    {
      if (!ModelState.IsValid)
        return failure();

      var formResult = request.Handle(form);

      if (!formResult.Success)
      {
        ModelState.AddModelError("error", formResult.ErrorMessage);
        failure();
      }

      return success();
    }
  }
}
