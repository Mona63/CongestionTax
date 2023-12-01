using CongestionTax.Core;
using CongestionTax.Core.Service;
using CongestionTax.Infrastructure;
using CongestionTax.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CongestionTaxDbContext>(options =>
                                      options.UseSqlite(builder.Configuration.GetConnectionString("MainConnectionString")));

builder.Services.AddTransient<ITollRepository, TollRepository>();
builder.Services.AddTransient<ITravelRepository, TravelRepository>();
builder.Services.AddScoped<ITravelService, TravelService>();
builder.Services.AddScoped<IRuleEngine, RuleEngine>();
builder.Services.AddScoped<ICongestionTaxRule, DayFreeChargeRule>();
builder.Services.AddScoped<ICongestionTaxRule, VehicleTypeChargeRule>();
builder.Services.AddScoped<ICongestionTaxRule, TimeTableChargeRule>();
builder.Services.AddScoped<ICongestionTaxRule, HourlyMaxChargeRule>();
builder.Services.AddScoped<ICongestionTaxRule, DailyMaxChargeRule>();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

// Configure the HTTP request pipeline.

//app.UseAuthorization();

app.MapControllers();

app.Run();



