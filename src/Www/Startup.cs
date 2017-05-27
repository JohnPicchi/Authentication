using System;
using System.Linq;
using Authentication.Core.Models;
using Authentication.Database;
using Authentication.Database.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IContainer = Authentication.Container.IContainer;

namespace Authentication
{
  public class Startup
  {
    private IContainer applicationContainer;

    public IConfigurationRoot Configuration { get; }

    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        .AddEnvironmentVariables();

      Configuration = builder.Build();
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
      services.AddIdentityServer()
        //.AddSigningCredential()
        .AddTemporarySigningCredential()
        .AddInMemoryClients(Config.GetClients())
        .AddInMemoryApiResources(Config.GetApiResources())
        .AddTestUsers(Config.GetTestUsers());

      services.AddLogging();
      services.AddOptions();
      services.Configure<ApplicationSettings>(Configuration.GetSection("AppSettings"));

      services.AddDbContext<DatabaseContext>();

      return applicationContainer = new Container.Container(services);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime applicationLifetime)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        //loggerFactory.AddConsole(LogLevel.Information);
      }
      loggerFactory.AddProvider(new DatabaseLoggerProvider());

      app.UseIdentityServer();
      app.UseStaticFiles();
      app.UseMvc(routes =>
      {
        routes.MapRoute(
          name: "default",
          template: "{controller}/{action}/{id?}",
          defaults: new { controller = "Home", action = "Index" });
      });

      // If you want to dispose of resources that have been resolved in the
      // application container, register for the "ApplicationStopped" event.
      applicationLifetime.ApplicationStopped.Register(() => applicationContainer.Dispose());
    }
  }
}
