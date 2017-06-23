using System;
using Authentication.Controllers;
using Authentication.Database;
using Authentication.Database.Contexts;
using Authentication.Domain.Models;
using Authentication.Filters;
using Authentication.Utilities.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
      var configuration  = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        .AddEnvironmentVariables()
        .Build();

      //var connectionString = builder.Build();
      //var configuration = builder
      //  // Add the EF configuration provider, which will override any
      //  // config made with the JSON provider.
      //  .AddEntityFrameworkConfig(opts =>
      //  {
      //    opts.UseSqlServer(connectionString.GetConnectionString("DefaultConnection"));
      //  })
      //  .Build();

      Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
      services.AddMvc(opts =>
      {
        opts.Filters.Add(typeof(AutoValidateAntiforgeryTokenAttribute));
        opts.Filters.Add(typeof(DatabaseContextTransactionFilter));
        opts.Filters.Add(typeof(SecurityHeadersFilter));
      });


      services.AddDbContext<DatabaseContext>(opts =>
      {
        //opts.UseLoggerFactory()
        opts.UseSqlServer(Configuration.GetConnectionString("Default"));
      });

      services.AddIdentity<ApplicationUser, Role>()
        .AddEntityFrameworkStores<DatabaseContext, Guid>()
        .AddDefaultTokenProviders();

      services.AddIdentityServer(opts =>
        {
          opts.Endpoints.EnableUserInfoEndpoint = true;
          opts.UserInteraction.LoginUrl = Helper.LocalPath<AccountController>(nameof(AccountController.Login));
        })
        //.AddSigningCredential()
        .AddDeveloperSigningCredential()
        .AddInMemoryClients(Config.GetClients())
        .AddInMemoryApiResources(Config.GetApiResources())
        .AddInMemoryIdentityResources(Config.GetIdentityResources())
        .AddAspNetIdentity<ApplicationUser>();
      //.AddProfileService<ProfileService>();

      //services.AddTransient<IClaimsService, ClaimsService>();
      //services.AddTransient<IProfileService, ProfileService>();

      services.AddLogging();
      services.AddOptions();

      services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

      return applicationContainer = new Container.Container(services);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime applicationLifetime)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        loggerFactory.AddConsole(LogLevel.Information);
      }
      loggerFactory.AddProvider(new DatabaseLoggerProvider());

      app.UseStaticFiles();

      app.UseIdentity();
      app.UseIdentityServer();

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
