using CRM.Data;
using Hangfire;
using Hangfire.PostgreSql;
using CRM.Services;
using CRM.Services.Repositories;
using CRM.Services.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRESQL_CONNECTION_STRING"));
});

builder.Services.AddHangfire(config => config
 .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
 .UseSimpleAssemblyNameTypeSerializer()
 .UseRecommendedSerializerSettings()
 .UsePostgreSqlStorage(builder.Configuration.GetConnectionString("DefaultConnetion")));

builder.Services.AddHangfireServer();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

builder.Services.AddScoped<IExcelService, ExcelService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



















var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.UseHangfireDashboard("/CrmJobsDashboard");
app.UseEndpoints(e => e.MapHangfireDashboard());

app.MapControllers();

app.Run();
