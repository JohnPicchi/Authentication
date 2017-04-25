using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using Authentication.DomainModels.Models;
using IdentityModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

      services.AddOptions();
      services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

      return applicationContainer = new Container.Container(services);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime applicationLifetime)
    {
      //var log = new LoggerConfiguration()
      //  .MinimumLevel.Information()
      //  .WriteTo.LiterateConsole
      //  .CreateLogger();
      //loggerFactory.AddSerilog(log);

      loggerFactory.AddConsole();

      if (env.IsDevelopment())
      {
          app.UseDeveloperExceptionPage();
      }

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
