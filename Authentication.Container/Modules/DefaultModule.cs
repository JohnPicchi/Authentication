using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Authentication.Core.Contracts.HandlerContracts;
using Authentication.Core.Handlers;
using Authentication.Database;
using Autofac;
using Module = Autofac.Module;

namespace Authentication.Container.Modules
{
  public class DefaultModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      var assemblies = new[]
      {
        Assembly.Load(new AssemblyName {Name = "Authentication.Database"}),
        Assembly.Load(new AssemblyName {Name = "Authentication.Core"}),
        Assembly.Load(new AssemblyName {Name = "Authentication.Services"}),
      };
    
      //Register Application/Domain Services
      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("Service"))
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();  //NOT instancePerRequest for dotnet core 
    
      //Repository
      builder.Register(c => new Database.Repository())
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      //Form Handlers
      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("FormHandler"))
        .AsClosedTypesOf(typeof(IFormHandler<>))
        .InstancePerLifetimeScope();

      //Request Handlers
      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("RequestHandler"))
        .AsClosedTypesOf(typeof(IRequestHandler<,>))
        .InstancePerLifetimeScope();

      //Notification Handlers
      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("NotificationHandler"))
        .AsClosedTypesOf(typeof(INotificationHandler<>))
        .InstancePerLifetimeScope();

      base.Load(builder);
    }
  }
}
