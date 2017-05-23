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
using AutoMapper;
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
        Assembly.Load(new AssemblyName {Name = "Authentication.Repositories"}),
        Assembly.Load(new AssemblyName {Name = "Authentication.Account"}),
        Assembly.Load(new AssemblyName {Name = "Authentication.User"}),
      };
    
      ///////////////////////////////////////////////
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

      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("Factory"))
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      //builder.RegisterGeneric(typeof(Repository<>))
      //  .As(typeof(IRepository<>))
      //  .InstancePerLifetimeScope();

      ////////////////////////////////////////////
      // AutoMapper
      ////////////////////////////////////////////
      builder.Register(c =>
        {
          var mapperConfig = new MapperConfiguration(config =>
          {
            config.AddProfiles(ThisAssembly);
          });

          return new Mapper(mapperConfig);
        })
        .As<IMapper>()
        .SingleInstance();

      ////////////////////////////////////////////
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


      //////////////////////////////////////////
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
