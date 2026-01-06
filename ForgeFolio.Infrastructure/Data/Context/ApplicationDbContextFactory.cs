using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ForgeFolio.Infrastructure.Data.Context;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        // Adjust path to find appsettings.json in the Web project (sibling directory)
        var basePath = Directory.GetCurrentDirectory();
        var webProjectPath = Path.Combine(basePath, "..", "ForgeFolio");
        
        if (Directory.Exists(webProjectPath) && File.Exists(Path.Combine(webProjectPath, "appsettings.json")))
        {
            basePath = webProjectPath;
        }
        else if (File.Exists(Path.Combine(basePath, "ForgeFolio", "appsettings.json")))
        {
             basePath = Path.Combine(basePath, "ForgeFolio");
        }

        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddUserSecrets("a36c62fe-5d2c-42ec-8a34-e5413728bc0d"); // Hardcoded ID from Web project

        IConfigurationRoot configuration = builder.Build();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("ForgeFolio.Infrastructure"));

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
