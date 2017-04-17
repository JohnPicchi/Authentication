using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Authentication
{
  public class Config
  {

    public static List<TestUser> GetTestUsers()
    {
      return new List<TestUser>
      {
        new TestUser
        {
          SubjectId = "123", Username = "john", Password = "john",
          Claims = new List<Claim>
          {
            new Claim("name", "John Picchi"),
            new Claim("email", "0xdante@gmail.com"),
            new Claim("location", "USA")
          }
        }
      };
    }

    public static IEnumerable<Client> GetClients()
    {
      return new List<Client>
      {
        // other clients omitted...

        // OpenID Connect implicit flow client (MVC)
        new Client
        {
          ClientId = "mvc",
          ClientName = "MVC Client",
          AllowedGrantTypes = GrantTypes.Implicit,
          ClientSecrets = new List<Secret>{ new Secret("secret".Sha256()) },
          // where to redirect to after login
          //RedirectUris = { "http://localhost:5002/signin-oidc" },

          // where to redirect to after logout
          //PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

          AllowedScopes = new List<string>
          {
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile
          }
        }
      };
    }

    public static IEnumerable<ApiResource> GetApiResources()
    {
      return new List<ApiResource>
      {
        new ApiResource("api", "My API"),
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
