﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Authentication.Core.Models;
using Authentication.Database;
using Authentication.Database.Contexts;
using Microsoft.AspNetCore.Authorization;
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
      services.AddMvc(opt =>
      {
        var policy = new AuthorizationPolicyBuilder()
          .RequireAuthenticatedUser()
          .Build();
       
        //opt.Filters.Add(new AuthorizeFilter(policy));
        opt.Filters.Add(typeof(DatabaseContextTransactionFilter));
      });

      services.AddIdentityServer(opts =>
        {
          //opts.Discovery.ShowEndpoints = true;
        })
        //.AddSigningCredential()
        .AddTemporarySigningCredential()
        .AddInMemoryClients(Config.GetClients())
        .AddInMemoryApiResources(Config.GetApiResources())
        .AddInMemoryIdentityResources(Config.GetIdentityResources())
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
        loggerFactory.AddConsole(LogLevel.Information);
      }
      loggerFactory.AddProvider(new DatabaseLoggerProvider());

      app.UseStaticFiles();

      //Takes care of the local sign-in part
      app.UseCookieAuthentication(new CookieAuthenticationOptions
      {
        AuthenticationScheme = "Cookies"
      });

      //Gets the claims exactly how the issuer gave it to you. 
      //If left out, the claim type gets fucked up and turned into a url
      //(eg: http://schemas.microsoft.com/identity/claims/identityprovider)
      JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();   

      //Takes care of the OpenIdConnect part
      app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
      {
        AuthenticationScheme = "oidc",
        SignInScheme = "Cookies",   //tells the application which authentication middleware does the local sign-in part (the very last part)
        Authority = "http://localhost:5000",
        RequireHttpsMetadata = false,
        ClientId = "mvc",
        ClientSecret = "secret",    //needed to authenticate on the back-channel to get the actual access token
        ResponseType = "code id_token",  //what we want to get back from the token service
        Scope = { "openid", "profile", "api1"},     //openid is mandatory...openid = userid
        SaveTokens = true   //takes the access token and stores it in the cookie
      });

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
