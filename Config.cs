// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace QuickstartIdentityServer
{
    public class Config
    {
        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource("roles","角色", new List<string>{"role"}),
                new IdentityResource("nationality","国籍", new List<string>(){"nationality"})
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("https://quickstarts/api", "My API",
                    new List<string>()
                    {
                        "role",
                        "given_name",
                        "gender",
                        "nationality"
                    })
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                
                
                // OpenID Connect implicit flow client (MVC)
                new Client
                {
                    ClientId = "ZnwqE8j-H6kmHeQBM3NH2WbdikUjPrNV",
                    ClientName = "合同认证系统",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets =
                    {
                        new Secret("jecyL0PrTIxjNf4GUbz0oa_ssRLiJBG8OXfIMzLDjGCEoTV48HHqvK2pasPodPyN".Sha256())
                    },
                    FrontChannelLogoutUri = "http://192.168.0.158:8091/account/logout",
                    FrontChannelLogoutSessionRequired = false,
                    RedirectUris = { "http://192.168.0.158:8091/callback" ,"http://localhost:5000/callback"},
                    PostLogoutRedirectUris = { "http://localhost:3000/" },

                    AllowedScopes =
                    {
                        "https://quickstarts/api",
                        IdentityServerConstants.StandardScopes.Profile,
                        "nationality",
                        "https://quickstarts/api",
                        IdentityServerConstants.StandardScopes.OpenId,
                    }
                },
                //new Client
                //{
                //    ClientId = "SYGtG8b4HcWBICHxkw63173ohARZoaO8",
                //    ClientName = "MVC Client2",
                //    AllowedGrantTypes = GrantTypes.Code,
                //    ClientSecrets =
                //    {
                //        new Secret("BPptSgcAhYxUYIIPSbr5SDHG4-Gq8TrP2qsVc44j4YmNqmm-nuc2Ld3heyJQoMmB".Sha256())
                //    },

                //    RedirectUris = { "http://localhost:3000/callback" },
                //    PostLogoutRedirectUris = { "http://localhost:3000/" },

                //    AllowedScopes =
                //    {
                //        "https://quickstarts/api",
                //        IdentityServerConstants.StandardScopes.Profile,
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        "nationality"
                //    }
                //},
                new Client
                {
                    ClientId = "ThirdWebAppId",
                    ClientName = "OA应用",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets =
                    {
                        new Secret("ThirdWebAppPsd".Sha256())
                    },
                    FrontChannelLogoutUri = "http://192.168.0.158:10112/account/logout",
                    FrontChannelLogoutSessionRequired = false,
                    RedirectUris = { "http://localhost:7001/callback","http://127.0.0.1:7001/callback" },
                    PostLogoutRedirectUris = { "http://localhost:3000/" },

                    AllowedScopes =
                    {
                        "https://quickstarts/api",
                        "java/api",
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OpenId,
                        "nationality"
                    }
                },
                new Client
                {
                    ClientId = "123",
                    ClientName = "456",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets =
                    {
                        new Secret("456".Sha256())
                    },

                    RedirectUris = { "http://192.168.0.158:8091/callback" },
                    PostLogoutRedirectUris = { "http://192.168.0.158:8196" },

                    AllowedScopes =
                    {
                        "https://quickstarts/api",
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OpenId,
                        "nationality"
                    }
                },
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice1",
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "Alice"),
                        new Claim("website", "https://alice.com")
                    }
                },
                new TestUser
                {
                    SubjectId = "3",
                    Username = "bob1",
                    Password = "bob",

                    Claims = new List<Claim>
                    {
                        new Claim("ID","123"),
                        new Claim("name", "Bob1"),
                        new Claim("website", "https://bob.com"),
                        new Claim("综上所述","fuck"),
                        new Claim("nationality","美国")
                    }
                }
            };
        }
    }
}