using ForgeFolio.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForgeFolio.DAL.Context
{
    public class MyPortfolioContext : DbContext
    {
        public MyPortfolioContext(DbContextOptions<MyPortfolioContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // PostgreSQL için Bolt Database bağlantısı
                optionsBuilder.UseNpgsql("YOUR_Bolt Database_CONNECTION_STRING");
            }
        }

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
    }
}
