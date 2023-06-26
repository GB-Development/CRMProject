using AutoMapper;
using CRM.Data;
using CRM.Mapper;
using CRM.Services;
using CRM.Services.DTO;
using CRM.Services.Entities;
using CRM.Services.Interfaces;
using CRM.Services.Repositories;
using CRM.Services.Repositories.Implementation;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Text;
using static Castle.MicroKernel.ModelBuilder.Descriptors.InterceptorDescriptor;

var builder = WebApplication.CreateBuilder(args);

#region Configure Automapper

var mapperConfiguration = new MapperConfiguration(mapper => mapper.AddProfile(new MapperProfiler()));
var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion

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

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.UseHangfireDashboard("/CrmJobsDashboard");
app.UseEndpoints(e => e.MapHangfireDashboard());

app.MapControllers();

app.Run();
