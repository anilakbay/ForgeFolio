using ForgeFolio.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForgeFolio.Infrastructure.Data.Configurations;

public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
{
    public void Configure(EntityTypeBuilder<SocialMedia> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Url)
            .HasMaxLength(500);

        builder.Property(x => x.Icon)
            .HasMaxLength(50);

        builder.HasIndex(x => x.IsDeleted);
    }
}
