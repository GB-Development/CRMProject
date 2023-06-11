using CRMIdentity;
using CRMIdentity.Data.Models;
using Duende.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using CRMIdentity.Data;
using CRMIdentity.Services.Profile;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
                        .WriteTo.Console()
                        .CreateBootstrapLogger();

        Log.Information("Starting up");

        try
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Logger

            builder.Host.UseSerilog((ctx, lc) => lc
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
                .Enrich.FromLogContext()
                .ReadFrom.Configuration(ctx.Configuration));

            #endregion

            builder.Services.AddRazorPages();

            #region Database

            var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("IdentityUserDBConnection")));


            #endregion

            #region Identity

            builder.Services.AddIdentity<CRMUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services
                .AddIdentityServer(options =>
                {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;

                    // see https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/
                    options.EmitStaticAudienceClaim = true;
                })
                 //тестовый x509-сертификат, IdentityServer использует RS256 для подписи JWT
                 //not recommended for production - you need to store your key material somewhere secure
                .AddDeveloperSigningCredential()
                // конфигурация хранится в базе
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseNpgsql(builder.Configuration.GetConnectionString("IdentityConfigDBConnection"),
                    sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseNpgsql(builder.Configuration.GetConnectionString("IdentityConfigDBConnection"),
                    sql => sql.MigrationsAssembly(migrationsAssembly));

                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = 3600; // interval in seconds (default is 3600)
                })
                //.AddInMemoryIdentityResources(Config.IdentityResources)
                //.AddInMemoryApiScopes(Config.ApiScopes)
                //.AddInMemoryClients(Config.Clients)
                .AddAspNetIdentity<CRMUser>()
                .AddProfileService<CRMProfileService>();

            builder.Services.AddAuthentication()
                .AddGoogle("Google", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                    options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
                    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
                })
                .AddOpenIdConnect("oidc", "Demo IdentityServer", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.SignOutScheme = IdentityServerConstants.SignoutScheme;
                    options.SaveTokens = true;

                    options.Authority = "https://demo.duendesoftware.com";
                    options.ClientId = "interactive.confidential";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = "name",
                        RoleClaimType = "role"
                    };
                });

            #endregion

            var app = builder.Build();

            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            HostingExtensions.InitializeDatabase(app);

            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.MapRazorPages()
                .RequireAuthorization();

            // this seeding is only for the template to bootstrap the DB and users.
            // in production you will likely want a different approach.
            if (args.Contains("/seed"))
            {
                Log.Information("Seeding database...");
                SeedData.EnsureSeedData(app);
                Log.Information("Done seeding database. Exiting.");
                return;
            }

            app.Run();
        }
        catch (Exception ex) when (
                                    // https://github.com/dotnet/runtime/issues/60600
                                    ex.GetType().Name is not "StopTheHostException"
                                    // HostAbortedException was added in .NET 7, but since we target .NET 6 we
                                    // need to do it this way until we target .NET 8
                                    && ex.GetType().Name is not "HostAbortedException"
                                )
        {
            Log.Fatal(ex, "Unhandled exception");
        }
        finally
        {
            Log.Information("Shut down complete");
            Log.CloseAndFlush();
        }
    }
}