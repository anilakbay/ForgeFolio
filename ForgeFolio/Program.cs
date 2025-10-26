using ForgeFolio.DAL.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Bolt Database PostgreSQL baðlantýsý
builder.Services.AddDbContext<MyPortfolioContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        npgsqlOptions =>
        {
            // Baðlantý koparsa otomatik tekrar dene
            npgsqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorCodesToAdd: null);

            // Timeout ayarlarý
            npgsqlOptions.CommandTimeout(30);
        }));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Production ortamý
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    // Local development
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ToDoList}/{action=Index}/{id?}");

app.Run();
