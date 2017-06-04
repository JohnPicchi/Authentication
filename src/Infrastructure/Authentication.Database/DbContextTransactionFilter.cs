using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Database.Contexts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Database
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

        await next();

        await databaseContext.CommitTransactionAsync();
      }
      catch (Exception)
      {
        databaseContext.RollbackTransaction();
      }
    }
  }
}
