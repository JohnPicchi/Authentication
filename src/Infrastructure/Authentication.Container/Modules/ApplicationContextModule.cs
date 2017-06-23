using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Domain.Models;
using Authentication.Domain.Models.Contracts;
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

      builder.RegisterType<ApplicationContext>()
        .AsSelf()
        .As<IApplicationContext>()
        .InstancePerLifetimeScope();

      base.Load(builder);
    }
  }
}
