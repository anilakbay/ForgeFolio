using ForgeFolio.Core.Interfaces;
using ForgeFolio.Core.Interfaces.Services;
using ForgeFolio.Infrastructure.Data;
using ForgeFolio.Infrastructure.Data.Context;
using ForgeFolio.Infrastructure.Data.Repositories;
using ForgeFolio.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Serilog Configuration
builder.Host.UseSerilog((context, configuration) => 
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllersWithViews();

// Database Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository Pattern
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Business Services
builder.Services.AddScoped<IPortfolioService, PortfolioService>();
builder.Services.AddScoped<IExperienceService, ExperienceService>();

builder.Services.AddScoped<IToDoListService, ToDoListService>();
builder.Services.AddScoped<IStatisticService, StatisticService>();

var app = builder.Build();

// if (!app.Environment.IsDevelopment())
// {
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
// }
app.UseMiddleware<ForgeFolio.Middleware.GlobalExceptionMiddleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
