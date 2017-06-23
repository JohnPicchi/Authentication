using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;

namespace Authentication
{
  public class Config
  {

    //public static List<TestUser> GetTestUsers()
    //{
    //  return new List<TestUser>
    //  {
    //    new TestUser
    //    {
    //      SubjectId = "D361A7A9-2675-4500-C415-08D4B11524D2", Username = "0xdante@gmail.com", Password = "1",
    //      Claims = new List<Claim>
    //      {
    //        new Claim("name", "John Picchi"),
    //        new Claim("email", "0xdante@gmail.com"),
    //        new Claim(JwtClaimTypes.Role, "Administrator"),
    //        new Claim("location", "USA")
    //      }
    //    }
    //  };
    //}

    public static IEnumerable<Client> GetClients()
    {

      return new List<Client>
      {
        // other clients omitted...

        // OpenID Connect implicit flow client (MVC)
        new Client
        {
          ClientId = "mvc.AuthenticationServer",
          ClientName = "Authentication Server",
          AllowedGrantTypes = GrantTypes.Hybrid,
          //AlwaysIncludeUserClaimsInIdToken = true,
          //AlwaysSendClientClaims = true,
          //AllowAccessTokensViaBrowser = true,
          ClientSecrets = new List<Secret>{ new Secret("secret".Sha256()) },
          // where to redirect to after login
          RedirectUris = { "http://localhost:5000/signin-oidc" },
          // where to redirect to after logout
          //PostLogoutRedirectUris = { "http://localhost:5000/signout-callback-oidc" },
          RequireConsent = false,
          AllowedScopes = new List<string>
          {
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile
          }
        },
        new Client
        {
          ClientId = "mvc.Test",
          ClientName = "Test",
          AllowedGrantTypes = GrantTypes.Hybrid,
          ClientSecrets = new List<Secret>{ new Secret("secret".Sha256()) },
          // where to redirect to after login
          RedirectUris = { "http://localhost:5001/signin-oidc" },
          // where to redirect to after logout
          //PostLogoutRedirectUris = { "http://localhost:5001/signout-callback-oidc" },
          RequireConsent = false,

          AllowedScopes = new List<string>
          {
            "test",
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile
          }
        }
      };
    }

    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
      var test = new IdentityResource
      {
        Name = "test",
        DisplayName = "test",
        Enabled = true,
        UserClaims = {"role"}
      };

      return new List<IdentityResource>
      {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        test,
        new IdentityResource("custom", new[] {"location", "status"})
      };
    }

    public static IEnumerable<ApiResource> GetApiResources()
    {
      return new List<ApiResource>
      {
        new ApiResource("api1", "My API"),
        //new ApiResource
        //{
        //  Name = "complicated_api",
        //  DisplayName = "Complicated API",
        //  UserClaims = {"name", "email"}, //Both, full_access and read_only, will have these claims
        //  Scopes =
        //  {
        //    new Scope("full_access")  //full_access scope gets the claims: name, email, and role
        //    {
        //      UserClaims = {"role"}
        //    },
        //    new Scope("read_only")
        //  }
        //}
      };
    }
  }
}
