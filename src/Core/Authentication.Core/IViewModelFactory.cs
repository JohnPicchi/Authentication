using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Core
{
  public interface IViewModelFactory<TInput, TModel>
  {
    TModel Build(TInput input);
  }

  public interface IViewModelFactoryAsync<TContext, TModel>
  {
    Task<TModel> BuildAsync(TContext input);
  }
}