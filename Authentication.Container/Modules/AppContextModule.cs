using System;
using System.Collections.Generic;
using System.Text;
using Authentication.DomainModels.Contracts;
using Authentication.DomainModels.Models;
using Autofac;
using Microsoft.Extensions.Configuration;
using AppContext = Authentication.DomainModels.Models.AppContext;

namespace Authentication.Container.Modules
{
  public class AppContextModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<AppSettings>()
        .AsSelf()
        .As<IAppSettings>()
        .InstancePerLifetimeScope();

      builder.RegisterType<AppUser>()
        .AsSelf()
        .As<IAppUser>()
        .InstancePerLifetimeScope();

      builder.RegisterType<AppContext>()
        .AsSelf()
        .As<IAppContext>()
        .InstancePerLifetimeScope();

      base.Load(builder);
    }
  }
}
