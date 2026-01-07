using ForgeFolio.Core.Entities;
using ForgeFolio.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ForgeFolio.Infrastructure.Data.Seed;

public class DataSeeder
{
    public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

        // 1. Seed Roles
        string[] roleNames = { "Admin", "User" };
        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole<int>(roleName));
            }
        }

        // 2. Seed Admin User
        var adminEmail = "admin@forgefolio.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            var newAdmin = new AppUser
            {
                UserName = "admin",
                Email = adminEmail,
                FirstName = "System",
                LastName = "Admin",
                EmailConfirmed = true
            };

            var createPowerUser = await userManager.CreateAsync(newAdmin, "Admin123!");
            if (createPowerUser.Succeeded)
            {
                await userManager.AddToRoleAsync(newAdmin, "Admin");
            }
        }

        // 3. Seed Sample Content
        await SeedContentAsync(context);
    }

    private static async Task SeedContentAsync(ApplicationDbContext context)
    {
        // Feature
        if (!await context.Features.AnyAsync())
        {
            await context.Features.AddAsync(new Feature
            {
                Header = "Hello I'm",
                NameSurname = "Anıl Akbay",
                Title = "Full Stack Developer",
                Description = "I build modern, scalable, and secure web applications using .NET and React technologies.",
                Icon = "fas fa-code"
            });
        }

        // About
        if (!await context.Abouts.AnyAsync())
        {
            await context.Abouts.AddAsync(new About
            {
                Title = "About Me",
                SubDescription = "Passion for coding",
                Details = "I am a dedicated developer with expertise in C# and .NET ecosystem. I enjoy solving complex problems and delivering high-quality software solutions."
            });
        }

        // Skills
        if (!await context.Skills.AnyAsync())
        {
            await context.Skills.AddRangeAsync(
                new Skill { Title = "C# / .NET Core", Value = 95 },
                new Skill { Title = "SQL Server", Value = 90 },
                new Skill { Title = "JavaScript / jQuery", Value = 85 },
                new Skill { Title = "HTML / CSS / Bootstrap", Value = 90 }
            );
        }

        // Experience
        if (!await context.Experiences.AnyAsync())
        {
            await context.Experiences.AddRangeAsync(
                new Experience 
                { 
                    Head = "Senior Developer", 
                    Title = "Tech Solutions Inc.", 
                    Date = "2023 - Present", 
                    Description = "Leading the backend development team." 
                },
                new Experience 
                { 
                    Head = "Junior Developer", 
                    Title = "Software House", 
                    Date = "2021 - 2023", 
                    Description = "Developed web applications using ASP.NET Core." 
                }
            );
        }

        // Portfolio
        if (!await context.Portfolios.AnyAsync())
        {
            await context.Portfolios.AddRangeAsync(
                new Portfolio
                {
                    Title = "E-Commerce Platform",
                    SubTitle = "Full Stack .NET Project",
                    ImageUrl = "/user-assets/project1.png",
                    Url = "https://github.com/anilakbay",
                    Description = "A comprehensive e-commerce solution."
                },
                new Portfolio
                {
                    Title = "Portfolio Site",
                    SubTitle = "Personal Branding",
                    ImageUrl = "/user-assets/project2.png",
                    Url = "https://github.com/anilakbay/ForgeFolio",
                    Description = "This portfolio management system."
                }
            );
        }

         // Services (ToDoList as sample tasks)
         if (!await context.ToDoLists.AnyAsync())
         {
             await context.ToDoLists.AddRangeAsync(
                 new ToDoList { Title = "Complete Profile", Description = "Fill in about section", Status = false },
                 new ToDoList { Title = "Upload Resume", Description = "Add latest CV to site", Status = true }
             );
         }

        await context.SaveChangesAsync();
    }
}
