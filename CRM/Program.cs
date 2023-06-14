using CRM.Data;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnetion"));
});

builder.Services.AddHangfire(config => config
 .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
 .UseSimpleAssemblyNameTypeSerializer()
 .UseRecommendedSerializerSettings()
 .UsePostgreSqlStorage(builder.Configuration.GetConnectionString("DefaultConnetion")));

builder.Services.AddHangfireServer();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
