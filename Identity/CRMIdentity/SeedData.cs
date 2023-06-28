using CRMIdentity.Data;
using CRMIdentity.Data.Models;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Security.Claims;

namespace CRMIdentity
{
    public class SeedData
    {
        /// <summary>
        /// Создание пользователей и добавление их в базу данных 
        /// </summary>
        /// <param name="app"></param>
        /// <exception cref="Exception"></exception>
        public static void EnsureSeedData(WebApplication app)
        {
            using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.Migrate();

                var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<CRMUser>>();
                var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (roleMgr.FindByNameAsync(Roles.Admin).Result == null)
                {
                    roleMgr.CreateAsync(new IdentityRole(Roles.Admin)).GetAwaiter().GetResult();
                    roleMgr.CreateAsync(new IdentityRole(Roles.User)).GetAwaiter().GetResult();
                }
                else return;


                var admin = userMgr.FindByNameAsync("admin").Result;

                if (admin != null)
                {
                    var deleteResult = userMgr.DeleteAsync(admin);

                    if (deleteResult.IsCompletedSuccessfully)
                    {
                        Log.Debug("Admin user deleted successfully");
                    }
                    else
                    {
                        Log.Debug("Admin user delete fail.");
                    }
                }

                admin = new CRMUser
                {
                    Name = "admin",
                    UserName = "admin",
                    Email = "admin@gbcrm.com",
                    EmailConfirmed = true,
                };

                var result = userMgr.CreateAsync(admin, "Pass123$").Result;

                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(admin, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "admin"),
                            //new Claim(JwtClaimTypes.Role, Roles.Admin),
                            //new Claim(JwtClaimTypes.GivenName, "admin"),
                            //new Claim(JwtClaimTypes.FamilyName, "admin"),
                            //new Claim(JwtClaimTypes.WebSite, "http://somesite.com"),
                        }).Result;

                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddToRoleAsync(admin, Roles.Admin).Result; 
                if (!result.Succeeded) 
                {
                    throw new Exception(result.Errors.First().Description);
                }

                Log.Debug("Admin created");
            }
        }


        /// <summary>
        /// Добавление в базу данных настроек Identity сервера клиентов, ресурсов и областей доступа
        /// </summary>
        /// <param name="app"></param>
        public static void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

                context.Database.Migrate();

                if (!context.Clients.Any())
                {
                    foreach (var client in Config.Clients)
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in Config.IdentityResources)
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiScopes.Any())
                {
                    foreach (var resource in Config.ApiScopes)
                    {
                        context.ApiScopes.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}