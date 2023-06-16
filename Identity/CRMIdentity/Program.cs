using Serilog;
using System.Reflection;
using CRMIdentity;
using CRMIdentity.Repository;
using CRMIdentity.Services.Profile;
using CRMIdentity.Data;
using CRMIdentity.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;
using IdentityModel;
using Duende.IdentityServer.Services;

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

            #region Получение параметров подключения к базе данных

            //
            // При запуске в "ASPNETCORE_ENVIRONMENT": "Production"
            // нужно создать переменные окружения:
            // DB_POSTGRESS_IDENTITY_USERS - для подключения к базе данных пользователей
            // DB_POSTGRESS_IDENTITY_CONFIG - для подключения к базе данных конфигурации Identity Server
            //

            var dbConnectionIdentityUsers = builder.Environment.IsDevelopment() ?
                     builder.Configuration.GetConnectionString("DbConnectionIdentityUsers") :
                     builder.Configuration.GetSection("DB_POSTGRESS_IDENTITY_USERS").Value;

            var dbConnectionIdentityConfig = builder.Environment.IsDevelopment() ?
                     builder.Configuration.GetConnectionString("DBConnectionIdentityConfig") :
                     builder.Configuration.GetSection("DB_POSTGRESS_IDENTITY_CONFIG").Value;

            #endregion

            #region Database

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(dbConnectionIdentityUsers));

            #endregion

            #region Настройки Identity Server

            var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

            builder.Services.AddIdentity<CRMUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddScoped<IProfileService, CRMProfileService>();

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

                // Конфигурация сервера хранится в базе
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseNpgsql(dbConnectionIdentityConfig,
                    sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseNpgsql(dbConnectionIdentityConfig,
                    sql => sql.MigrationsAssembly(migrationsAssembly));

                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = 3600; // interval in seconds (default is 3600)
                })
                //// Конфигурация сервера хранится в памяти
                //.AddInMemoryIdentityResources(Config.IdentityResources)
                //.AddInMemoryApiScopes(Config.ApiScopes)
                //.AddInMemoryClients(Config.Clients)
                .AddAspNetIdentity<CRMUser>()
                .AddProfileService<CRMProfileService>();

            #endregion

            builder.Services.AddRazorPages();
            builder.Services.AddAuthentication();
            builder.Services.AddControllers();

            #region Add UI Admin Section

            // this adds the necessary config for the simple admin/config pages

            builder.Services.AddAuthorization(options =>
                options.AddPolicy("admin",
                    policy => policy.RequireClaim(JwtClaimTypes.Role, Roles.Admin))
            );

            builder.Services.Configure<RazorPagesOptions>(options =>
                options.Conventions.AuthorizeFolder("/Admin", "admin"));

            builder.Services.AddTransient<ClientRepository>();
            builder.Services.AddTransient<IdentityScopeRepository>();
            builder.Services.AddTransient<ApiScopeRepository>();

            #endregion


            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRM User Register", Version = "v1" });

                    // Поддержка TimeSpan
                    c.MapType<TimeSpan>(() => new OpenApiSchema
                    {
                        Type = "string",
                        Example = new OpenApiString("00:00:00")
                    });
                });
            }

            var app = builder.Build();

            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseIdentityServer();

            app.MapRazorPages()
                .RequireAuthorization();

            app.MapControllers();


            // this seeding is only for the template to bootstrap the DB and users.
            // in production you will likely want a different approach.
            if (args.Contains("/seed"))
            {
                Log.Information("Seeding database...");
                SeedData.EnsureSeedData(app);
                Log.Information("Done seeding database.");
                Log.Information("Seeding identity server config database(clients, resources, scopes)");
                SeedData.InitializeDatabase(app);
                Log.Information("Done seeding identity server config database. Exiting.");
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