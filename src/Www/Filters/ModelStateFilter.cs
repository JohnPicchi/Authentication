using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Authentication.Filters
{
  public class ModelStateFilter : IAsyncActionFilter
  {
    private readonly ICompositeViewEngine viewEngine;

    public ModelStateFilter(ICompositeViewEngine viewEngine)
    {
      this.viewEngine = viewEngine;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
      if (!context.ModelState.IsValid)
      {
        var controller = (Controller) context.Controller;

        controller.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;

        var actionName = controller.ControllerContext.ActionDescriptor.ActionName;
        var viewEngineResult = viewEngine.FindView(controller.Url.ActionContext, actionName, false);

        if (viewEngineResult.Success)
        {
          var viewResult = new ViewResult
          {
            ViewName = viewEngineResult.ViewName,
            ViewData = new ViewDataDictionary(controller.MetadataProvider, context.ModelState)
          };
          //Add an error message????
          //viewResult.ViewData.Add("","An Error Occurred");
          context.Result = viewResult;
        }
        else
        {
          context.Result = new BadRequestResult();
        }
      }
      else
        await next();
    }
  }
}
