using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Core.Models.Contracts;
using Autofac;
using Microsoft.Extensions.Options;

namespace Authentication.Container.Modules
{
  public class ApplicationContextModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.Register(t => t.Resolve<IOptionsSnapshot<Application.Models.ApplicationSettings>>().Value)
        .AsSelf()
        .As<IApplicationSettings>()
        .InstancePerLifetimeScope();
    
     // builder.RegisterType<User>()
     //   .AsSelf()
     //   .As<IUser>()
     //   .InstancePerLifetimeScope();

      builder.RegisterType<Application.Models.ApplicationContext>()
        .AsSelf()
        .As<IApplicationContext>()
        .InstancePerLifetimeScope();

      base.Load(builder);
    }
  }
}
