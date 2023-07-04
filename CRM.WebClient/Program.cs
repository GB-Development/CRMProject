using CRM.CRMapi.Client;
using CRM.IdentityServer.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CRM.WebClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var clientSecret = builder.Configuration.GetSection("ClientSecret").Value;

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies", options =>
                {
                    options.ExpireTimeSpan = new TimeSpan(0,0,10);
                })
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = "https://localhost:5001";

                    options.SignedOutCallbackPath = "/Account/Logout";

                    options.ClientId = "web2";
                    options.ClientSecret = clientSecret;
                    options.ResponseType = "code";

                    options.SaveTokens = true;

                    options.Scope.Clear();
                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("offline_access");
                    options.Scope.Add("crm.api");

                    options.GetClaimsFromUserInfoEndpoint = true;
                });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<RegistryClient>(x =>
            {
                return new RegistryClient("https://localhost:5001", new HttpClient());
            });

            builder.Services.AddScoped<CrmClient>(x =>
            {
                return new CrmClient("https://localhost:7255", new HttpClient());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}