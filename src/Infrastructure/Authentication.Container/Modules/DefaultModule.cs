using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;
using Authentication.Core.Contracts.Handlers;
using Authentication.Core.Contracts.Notifications;
using Authentication.Core.Contracts.Requests;
using Authentication.Core.Notifications;
using Authentication.Core.Requests;
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
    
      ////////////////////////////////////////////////
      // Register Services, Stores, & Repository
      ///////////////////////////////////////////////
      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("Service"))
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();  //NOT instancePerRequest for dotnet core 
    
      builder.Register(c => new Database.Repository())
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();


      /////////////////////////////////////////////
      // Requests & Notifications
      ////////////////////////////////////////////
      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("Request"))
        .AsClosedTypesOf(typeof(IRequest<,>))
        .InstancePerLifetimeScope();

      builder.RegisterGeneric(typeof(FormResultRequest<>))
        .As(typeof(IFormResultRequest<>))
        .InstancePerLifetimeScope();

      builder.RegisterGeneric(typeof(Notification<>))
        .As(typeof(INotification<>))
        .InstancePerLifetimeScope();


      ///////////////////////////////////////////
      // Handlers
      //////////////////////////////////////////
      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("RequestHandler"))
        .AsClosedTypesOf(typeof(IRequestHandler<,>))
        .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("NotificationHandler"))
        .AsClosedTypesOf(typeof(INotificationHandler<>))
        .InstancePerLifetimeScope();

      base.Load(builder);
    }
  }
}
