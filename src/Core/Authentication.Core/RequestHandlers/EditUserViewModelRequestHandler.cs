using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.PresentationModels.Admin.ViewModels;

namespace Authentication.Core.RequestHandlers
{
  public class EditUserViewModelRequestHandler : IRequestHandler<Guid, EditUserViewModel>
  {
 
    public async Task<EditUserViewModel> HandleAsync(Guid request)
    {
      return new EditUserViewModel();
    }
  }
}