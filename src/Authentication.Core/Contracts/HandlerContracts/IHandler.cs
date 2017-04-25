namespace Authentication.Core.Contracts.HandlerContracts
{
  public interface IHandler<TParam>
  {
    void Handle(TParam param);
  }

  public interface IHandler<TParam, TReturn>
  {
    TReturn Handle(TParam param);
  }
}
