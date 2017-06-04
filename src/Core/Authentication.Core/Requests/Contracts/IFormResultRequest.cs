using System.Threading.Tasks;

namespace Authentication.Core.Requests.Contracts
{
  public interface IFormResultRequest<TRequest> : IRequest<IFormResult, TRequest>
  {
  }

  public interface IFormResultRequestAsync<TRequest> : IRequestAsync<IFormResult, TRequest>
  {
  }
}
