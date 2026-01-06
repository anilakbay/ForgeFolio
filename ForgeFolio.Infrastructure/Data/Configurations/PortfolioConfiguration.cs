using ForgeFolio.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForgeFolio.Infrastructure.Data.Configurations;

public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
{
    public void Configure(EntityTypeBuilder<Portfolio> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.SubTitle)
            .HasMaxLength(300);

        builder.Property(x => x.ImageUrl)
            .HasMaxLength(500);
            
        builder.Property(x => x.Url)
            .HasMaxLength(500);

        builder.Property(x => x.Description)
            .HasMaxLength(2000);
            
        // Configure Soft Delete filter is handled in DbContext, but here we can add index if needed
        builder.HasIndex(x => x.IsDeleted);
    }
}
