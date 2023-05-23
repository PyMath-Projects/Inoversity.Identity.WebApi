using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace InoversityIdentity.Distribution.WebApi;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource("color", new [] { "favorite_color" })
        };


    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("inoversityrecords.read", "Inoversity Records Api"),
            new ApiScope("inoversityrecords.write", "Inoversity Records Api"),
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            // machine to machine client
            new Client
            {
                ClientId = "inoversityrecordsclient",
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = {"inoversityrecords.read", "inoversityrecords.write"}
            },
                
            // interactive ASP.NET Core MVC client
            new Client
            {
                ClientId = "web",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,
                    
                RedirectUris = { "https://localhost:5002/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:5444/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
                
                AllowOfflineAccess = true,
                
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "inoversityrecords",
                    "color"
                }
            }
        };
    
    public static IEnumerable<ApiResource> ApiResources => new[]
    {
        new ApiResource("inoversityrecords")
        {
            Scopes = new List<string> {"inoversityrecords.read", "inoversityrecords.write"},
            ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
            UserClaims = new List<string> {"role"}
        }
    };
}
