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
        await new ViewResult().ExecuteResultAsync(controller.Url.ActionContext);
      }
      else
        await next();
    }
  }
}
