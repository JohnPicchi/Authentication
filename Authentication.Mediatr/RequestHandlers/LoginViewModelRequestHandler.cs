using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Mediatr.Requests;
using Authentication.PresentationModels.ViewModels;
using MediatR;

namespace Authentication.Mediatr.RequestHandlers
{
  public class LoginViewModelRequestHandler : IRequestHandler<LoginViewModelRequest, LoginViewModel>
  {
    public LoginViewModel Handle(LoginViewModelRequest message)
    {
      return new LoginViewModel();
    }
  }
}
