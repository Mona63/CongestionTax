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
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ITollRepository, TollRepository>();
builder.Services.AddScoped<ITravelService, TravelService>();
builder.Services.AddScoped<IRuleEngine, RuleEngine>();
builder.Services.AddScoped<IFreeChargeRule, DaysRule>();
builder.Services.AddScoped<IFreeChargeRule, TimeFreeChargeRule>();
builder.Services.AddScoped<IFreeChargeRule, VehichleTypeRule>();
builder.Services.AddScoped<ICaculationTollRule, TimeTableChargeRule>();

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseAuthorization();

app.MapControllers();

app.Run();



