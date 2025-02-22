﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace IdentityServer;

public static class Config
{
    //public static IEnumerable<IdentityResource> IdentityResources =>
    //    new IdentityResource[]
    //    {
    //        new IdentityResources.OpenId(),
    //        new IdentityResources.Profile(),
    //        new IdentityResource()
    //        {
    //            Name = "verification",
    //            UserClaims = new List<string>
    //            {
    //                JwtClaimTypes.Email,
    //                JwtClaimTypes.EmailVerified
    //            }
    //        },
    //    };

    public static IEnumerable<ApiResource> ApiResources = new List<ApiResource>
        {
            new ApiResource
            {
                Name = "verification",
                UserClaims = new List<string>
                {
                    JwtClaimTypes.Email,
                    JwtClaimTypes.EmailVerified
                }
            },
            new ApiResource
            {
                Name = "identity-server-demo-api",
                DisplayName = "Identity Server Demo API",
                Scopes = new List<string>
                {
                    "write",
                    "read"
                }
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope(name: "api1", displayName: "My API"),
            new ApiScope("openid"),
            new ApiScope("profile"),
            new ApiScope("email"),
            new ApiScope("read"),
            new ApiScope("write"),
            new ApiScope("identity-server-demo-api")
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "client",

                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.ClientCredentials,

                // secret for authentication
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },

                // scopes that client has access to
                AllowedScopes = { "api1" }
            },
            // interactive ASP.NET Core Web App
            new Client
            {
                ClientId = "web",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = false,
                // where to redirect to after login
                RedirectUris = { "https://localhost:5002/signin-oidc" },

                // where to redirect to after logout
                PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "verification"
                }

            },
              new Client
                {
                    ClientId = "identity-server-demo-web",
                    AllowedGrantTypes = new List<string> { GrantType.AuthorizationCode },
                    RequireClientSecret = false,
                    RequireConsent = false,
                    RedirectUris = new List<string> { "http://localhost:3006/signin-callback.html" },
                    PostLogoutRedirectUris = new List<string> { "http://localhost:3006/" },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "identity-server-demo-api", "write", "read", "openid", "profile", "email" },
                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:3006",
                    },
                    AccessTokenLifetime = 86400
                }
        };
}