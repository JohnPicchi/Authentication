using System;
using System.Threading.Tasks;
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

        ModelState.AddModelError("FORM_RESULT_ERROR", formResult.ErrorMessage);
      }
      return failure();
    }

    internal async Task<IActionResult> FormAsync<TForm>(
      TForm form,
      IFormResultRequestAsync<TForm> request,
      Func<IActionResult> success,
      Func<IActionResult> failure)
    {
      if (ModelState.IsValid)
      {
        var formResult = await request.HandleAsync(form);
        if (formResult.Success)
          return success();

        ModelState.AddModelError("FORM_RESULT_ERROR", formResult.ErrorMessage);
      }
      return failure();
    }
  }
}
