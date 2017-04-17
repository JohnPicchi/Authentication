using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Features.Variance;
using MediatR;
using Module = Autofac.Module;

namespace Authentication.Container.Modules
{
  public class MediatrModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      var assembly = Assembly.Load(new AssemblyName { Name = "Authentication.Mediatr" });

      builder.RegisterSource(new ContravariantRegistrationSource());

      builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
        .AsImplementedInterfaces();

      builder.RegisterAssemblyTypes(assembly)
        .Where(t => t.Name.EndsWith("RequestHandler"))
        .AsClosedTypesOf(typeof(IRequestHandler<,>));

      builder.RegisterAssemblyTypes(assembly)
        .Where(t => t.Name.EndsWith("NotificationHandler"))
        .AsClosedTypesOf(typeof(INotificationHandler<>));

      builder.RegisterAssemblyTypes(assembly)
        .Where(t => t.Name.StartsWith("Async") && t.Name.EndsWith("RequestHandler"))
        .AsClosedTypesOf(typeof(IAsyncRequestHandler<,>));

      builder.RegisterAssemblyTypes(assembly)
        .Where(t => t.Name.StartsWith("Async") && t.Name.EndsWith("NotificationHandler"))
        .AsClosedTypesOf(typeof(IAsyncNotificationHandler<>));

      builder.RegisterAssemblyTypes(typeof(IRequest<>).GetTypeInfo().Assembly)
        .AsClosedTypesOf(typeof(IRequest<>));

      builder.Register<SingleInstanceFactory>(ctx =>
      {
        var c = ctx.Resolve<IComponentContext>();
        return t => c.Resolve(t);
      });

      builder.Register<MultiInstanceFactory>(ctx =>
      {
        var c = ctx.Resolve<IComponentContext>();
        return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
      });
    }
  }
}
