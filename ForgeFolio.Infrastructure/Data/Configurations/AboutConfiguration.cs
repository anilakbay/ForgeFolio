using ForgeFolio.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForgeFolio.Infrastructure.Data.Configurations;

public class AboutConfiguration : IEntityTypeConfiguration<About>
{
    public void Configure(EntityTypeBuilder<About> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.SubDescription)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Details)
            .IsRequired()
            .HasMaxLength(2000);

        builder.HasIndex(x => x.IsDeleted);
    }
}
