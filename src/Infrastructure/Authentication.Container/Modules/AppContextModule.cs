using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Domain.ModelContracts;
using Authentication.Domain.Models;
using Autofac;
using Microsoft.Extensions.Options;
using ApplicationContext = Authentication.Domain.Models.ApplicationContext;

namespace Authentication.Container.Modules
{
  public class AppContextModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.Register(t => t.Resolve<IOptionsSnapshot<ApplicationSettings>>().Value)
        .AsSelf()
        .As<IApplicationSettings>()
        .InstancePerLifetimeScope();
    
      builder.RegisterType<User>()
        .AsSelf()
        .As<IUser>()
        .InstancePerLifetimeScope();

      builder.RegisterType<ApplicationContext>()
        .AsSelf()
        .As<IApplicationContext>()
        .InstancePerLifetimeScope();

      base.Load(builder);
    }
  }
}
