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
        Assembly.Load(new AssemblyName {Name = "Authentication.User"}),
        Assembly.Load(new AssemblyName {Name = "Authentication.Application"}),
      };

      //builder.Register(c => new DomainTransaction())
      //  .Named<IInterceptor>("Domain-Transaction");

      ///////////////////////////////////////////////
      // Register Services & Repositories
      ///////////////////////////////////////////////
      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("Service"))
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();  //NOT instancePerRequest for dotnet core 

      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("Store"))
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      ///////////////////////////////////////////////
      // Factories
      ///////////////////////////////////////////////
      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("Factory"))
        .AsImplementedInterfaces()
        .AsSelf()
        .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies) // Factory -> Repository -> Factory
        .InstancePerLifetimeScope();

      //builder.RegisterGeneric(typeof(Repository<>))
      //  .As(typeof(IRepository<>))
      //  .InstancePerLifetimeScope();


      //////////////////////////////////////////////
      //// AutoMapper
      //////////////////////////////////////////////
      //builder.Register(c =>
      //  {
      //    var mapperConfig = new MapperConfiguration(config =>
      //    {
      //      config.AddProfiles(typeof(PersistenceModelProfile), typeof(DomainModelProfile));
      //    });
      //
      //    return mapperConfig.CreateMapper();
      //  })
      //  .As<IMapper>()
      //  .PropertiesAutowired()
      //  .InstancePerLifetimeScope();

      ////////////////////////////////////////////
      // Requests & Notifications
      ////////////////////////////////////////////
      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("Request"))
        //.AsClosedTypesOf(typeof(IRequest<,>))
        .AsSelf()
        .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("RequestAsync"))
        //.AsClosedTypesOf(typeof(IRequestAsync<,>))
        .AsSelf()
        .InstancePerLifetimeScope();

      builder.RegisterGeneric(typeof(FormResultRequest<>))
        .As(typeof(IFormResultRequest<>))
        .InstancePerLifetimeScope();

      builder.RegisterGeneric(typeof(FormResultRequestAsync<>))
        .As(typeof(IFormResultRequestAsync<>))
        .InstancePerLifetimeScope();

      builder.RegisterGeneric(typeof(Notification<>))
        .As(typeof(INotification<>))
        .InstancePerLifetimeScope();

      builder.RegisterGeneric(typeof(NotificationAsync<>))
        .As(typeof(INotificationAsync<>))
        .InstancePerLifetimeScope();


      //////////////////////////////////////////
      // Handlers
      //////////////////////////////////////////
      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("RequestHandler"))
        .AsClosedTypesOf(typeof(IRequestHandler<,>))
        .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("RequestHandlerAsync"))
        .AsClosedTypesOf(typeof(IRequestHandlerAsync<,>))
        .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("NotificationHandler"))
        .AsClosedTypesOf(typeof(INotificationHandler<>))
        .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("NotificationHandlerAsync"))
        .AsClosedTypesOf(typeof(INotificationHandlerAsync<>))
        .InstancePerLifetimeScope();

      base.Load(builder);
    }
  }
}
