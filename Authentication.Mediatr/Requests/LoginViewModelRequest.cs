using System;
using System.Collections.Generic;
using System.Text;
using Authentication.PresentationModels.ViewModels;
using MediatR;

namespace Authentication.Mediatr.Requests
{
  public class LoginViewModelRequest : IRequest<LoginViewModel>
  {
  }
}
