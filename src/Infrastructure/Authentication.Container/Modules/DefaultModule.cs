using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.RequestHandlers.FormHandlers.Contracts;
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
        Assembly.Load(new AssemblyName {Name = "Authentication.Services"})
      };


      ///////////////////////////////////////////////
      // Register Services & Repositories
      ///////////////////////////////////////////////
      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("Service"))
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();  //NOT instancePerRequest for dotnet core 

      //builder.RegisterAssemblyTypes(assemblies)
      //  .Where(t => t.Name.EndsWith("Store"))
      //  .AsImplementedInterfaces()
      //  .InstancePerLifetimeScope();



      ////////////////////////////////////////////
      // Requests & Notifications
      ////////////////////////////////////////////
      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("Request") && t.IsClass && !t.IsAbstract)
        .AsImplementedInterfaces()
        .AsSelf()
        .InstancePerLifetimeScope();

      builder.RegisterGeneric(typeof(FormResultRequest<>))
        .As(typeof(IFormResultRequest<>))
        .InstancePerLifetimeScope();

      //builder.RegisterGeneric(typeof(RequestAsync<>))
      //  .As(typeof(IRequestAsync<>))
      //  .InstancePerLifetimeScope();
      //
      //builder.RegisterGeneric(typeof(RequestAsync<,>))
      //  .As(typeof(IRequestAsync<,>))
      //  .InstancePerLifetimeScope();


      //////////////////////////////////////////
      // Handlers
      //////////////////////////////////////////
      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("FormHandler") && t.IsClass && !t.IsAbstract)
        .AsImplementedInterfaces()
        //.AsClosedTypesOf(typeof(IFormHandlerAsync<>))
        .AsSelf()
        .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.Name.EndsWith("RequestHandler") && t.IsClass && !t.IsAbstract)
        .AsImplementedInterfaces();
        //.Where(t =>
        //{
        //  var @interface = t.GetInterfaces().FirstOrDefault(i => i.Name.StartsWith("IRequestHandlerAsync"));
        //  return @interface != null && @interface.GenericTypeArguments.Length == 2;
        //})
        //.AsClosedTypesOf(typeof(IRequestHandlerAsync<,>))
        //.AsSelf()
        //.InstancePerLifetimeScope();
        //
        //builder.RegisterAssemblyTypes(assemblies)
        //.Where(t => t.Name.EndsWith("RequestHandlerAsync"))
        //.Where(t =>
        //{
        //  var @interface = t.GetInterfaces().FirstOrDefault(i => i.Name.StartsWith("IRequestHandlerAsync"));
        //  return @interface != null && @interface.GenericTypeArguments.Length == 1;
        //})
        //.AsClosedTypesOf(typeof(IRequestHandlerAsync<>))
        //.AsSelf()
        //.InstancePerLifetimeScope();

      base.Load(builder);
    }
  }
}
