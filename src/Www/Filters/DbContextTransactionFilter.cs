using System;
using System.Threading.Tasks;
using Authentication.Database;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Authentication.Filters
{
  public class DatabaseContextTransactionFilter : IAsyncActionFilter
  {
    private readonly DatabaseContext databaseContext;

    public DatabaseContextTransactionFilter(DatabaseContext databaseContext)
    {
      this.databaseContext = databaseContext;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
      try
      {
        databaseContext.BeginTransaction();

        var result = await next();
        if(!result.ExceptionHandled)
          throw new Exception();

        await databaseContext.CommitTransactionAsync();
      }
      catch (Exception)
      {
        databaseContext.RollbackTransaction();
      }
    }
  }
}
