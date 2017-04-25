using System;
using System.Collections.Generic;
using System.Text;
using Authentication.DomainModels.Contracts;
using Authentication.DomainModels.Models;
using Autofac;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using AppContext = Authentication.DomainModels.Models.AppContext;

namespace Authentication.Container.Modules
{
  public class AppContextModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.Register(t => t.Resolve<IOptionsSnapshot<AppSettings>>().Value)
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
