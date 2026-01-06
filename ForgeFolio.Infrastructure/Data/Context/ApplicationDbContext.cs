using ForgeFolio.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForgeFolio.Infrastructure.Data.Context;

/// <summary>
/// Application database context
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // DbSets
    public DbSet<About> Abouts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<ToDoList> ToDoLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply all configurations from current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        // Global query filter for soft delete
        modelBuilder.Entity<About>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Contact>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Experience>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Feature>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Message>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Portfolio>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Skill>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<SocialMedia>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Testimonial>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<ToDoList>().HasQueryFilter(e => !e.IsDeleted);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Automatically set audit fields
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.IsDeleted = false;
                    break;

                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    break;

                case EntityState.Deleted:
                    // Implement soft delete
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.DeletedAt = DateTime.UtcNow;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
