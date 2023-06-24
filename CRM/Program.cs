using CRM.Data;
using CRM.Services;
using CRM.Services.DTO;
using CRM.Services.Entities;
using CRM.Services.Interfaces;
using CRM.Services.Repositories;
using CRM.Services.Repositories.Implementation;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region ApplicationDbContext

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRESQL_CONNECTION_STRING"));
});

#endregion

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

#region Hangfire Service

builder.Services.AddHangfire(config => config
 .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
 .UseSimpleAssemblyNameTypeSerializer()
 .UseRecommendedSerializerSettings()
 .UsePostgreSqlStorage(Environment.GetEnvironmentVariable("POSTGRESQL_CONNECTION_STRING")));

builder.Services.AddHangfireServer();

#endregion

#region Services

builder.Services.AddScoped<IExcelService, ExcelService>();
builder.Services.AddScoped<ICompanyExcelDTOService, CompanyExcelDTOService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IDealRepository, DealRepository>();

#endregion

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
