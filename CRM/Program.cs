using CRM;
using CRM.Data;
using CRM.Services;
using CRM.Services.DTO;
using CRM.Services.Entities;
using CRM.Services.Interfaces;
using CRM.Services.Repositories;
using CRM.Services.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region ApplicationDbContext

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    //options.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRESQL_CONNECTION_STRING"));
});

#endregion

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

#region Services

builder.Services.AddAutoMapper(typeof(MappingConfig));
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

app.MapControllers();

app.Run();
