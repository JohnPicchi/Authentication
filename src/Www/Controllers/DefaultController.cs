using System;
using Authentication.Core.Requests.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
  public abstract class DefaultController : Controller
  {
    internal IActionResult Form<TForm>(
      TForm form, 
      IFormResultRequest<TForm> request, 
      Func<IActionResult> success, 
      Func<IActionResult> failure)
    {
      if (ModelState.IsValid)
      {
        var formResult = request.Handle(form);
        if (formResult.Success)
          return success();

        ModelState.AddModelError("error", formResult.ErrorMessage);
      }
      return failure();
    }
  }
}
