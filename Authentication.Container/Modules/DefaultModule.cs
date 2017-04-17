using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
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
      builder.Register(c => new Repository())
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();


      base.Load(builder);
    }
  }
}
