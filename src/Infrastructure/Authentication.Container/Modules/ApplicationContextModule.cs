using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Application.DomainModels;
using Authentication.Application.DomainModels.Contracts;
using Autofac;
using Microsoft.Extensions.Options;

namespace Authentication.Container.Modules
{
  public class ApplicationContextModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.Register(t => t.Resolve<IOptionsSnapshot<ApplicationSettings>>().Value)
        .AsSelf()
        .As<IApplicationSettings>()
        .InstancePerLifetimeScope();
    
     // builder.RegisterType<User>()o
     //   .AsSelf()
     //   .As<IUser>()
     //   .InstancePerLifetimeScope();

      base.Load(builder);
    }
  }
}
