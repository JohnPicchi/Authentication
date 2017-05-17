using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;
using Authentication.Core.NotificationHandlers.Contracts;
using Authentication.Core.Notifications;
using Authentication.Core.Notifications.Contracts;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests;
using Authentication.Core.Requests.Contracts;
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
      // Register Services & Repositories
      ///////////////////////////////////////////////
      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("Service"))
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();  //NOT instancePerRequest for dotnet core 

      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("Repository"))
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      //builder.RegisterGeneric(typeof(Repository<>))
      //  .As(typeof(IRepository<>))
      //  .InstancePerLifetimeScope();


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
