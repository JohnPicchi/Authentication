using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Authentication.Core.Contracts.ServiceContracts;
using Authentication.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Container
{
  public interface IContainer : IDisposable, IServiceProvider
  {

  }

  public class Container : IContainer
  {
    private readonly IServiceProvider serviceProvider;
    private readonly Autofac.IContainer autofacContainer;
    private readonly Autofac.ContainerBuilder autofacContainerBuilder;

    public Container(IServiceCollection services)
    {
      // Create the container builder.
      autofacContainerBuilder = new Autofac.ContainerBuilder();

      // Register dependencies, populate the services from
      // the collection, and build the container. If you want
      // to dispose of the container at the end of the app,
      // be sure to keep a reference to it as a property or field.
      //builder.RegisterType<MyType>().As<IMyTyHippe>();

      //If nothing is using/calling a type in an assembly you are trying to load, 
      //Load(...) will fail. The compiler will optimize the code so that unused dependencies
      //are removed.
      var assemblies = new[]
      {
        Assembly.Load(new AssemblyName {Name = "Authentication.Database"}),
        Assembly.Load(new AssemblyName {Name = "Authentication.Core"}),
        Assembly.Load(new AssemblyName {Name = "Authentication.Services"}),
      };

      var assembly = Assembly.Load(new AssemblyName { Name = "Authentication.Container" });

      autofacContainerBuilder.RegisterAssemblyModules(assembly);

      autofacContainerBuilder.Populate(services);
      autofacContainer = autofacContainerBuilder.Build();

      serviceProvider = new AutofacServiceProvider(autofacContainer);

    }

    public void Dispose() => autofacContainer.Dispose();

    public object GetService(Type serviceType) => serviceProvider.GetService(serviceType);
  }
}
