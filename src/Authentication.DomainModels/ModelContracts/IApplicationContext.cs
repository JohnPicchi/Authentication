namespace Authentication.Domain.ModelContracts
{
  public interface IApplicationContext
  {
    IApplicationSettings ApplicationSettings { get; }

    IUser User { get; }
  }
}
