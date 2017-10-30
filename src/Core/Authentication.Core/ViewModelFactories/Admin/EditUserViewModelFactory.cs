using System;
using System.Threading.Tasks;
using Authentication.PresentationModels.Admin.ViewModels;
using Microsoft.AspNetCore.Http;
using User = Authentication.User.Models.User;


namespace Authentication.Core.ViewModelFactories.Admin
{
  public class EditUserViewModelFactory: IViewModelFactoryAsync<Guid, EditUserViewModel>
  {
    public Task<EditUserViewModel> BuildAsync(Guid input)
    {
      throw new NotImplementedException();
    }
  }
}