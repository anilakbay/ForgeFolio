using ForgeFolio.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForgeFolio.Infrastructure.Data.Configurations;

public class TestimonialConfiguration : IEntityTypeConfiguration<Testimonial>
{
    public void Configure(EntityTypeBuilder<Testimonial> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ClientName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Comment)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(x => x.CompanyName)
            .HasMaxLength(200);

        builder.Property(x => x.ImageUrl)
            .HasMaxLength(500);

        builder.HasIndex(x => x.IsDeleted);
    }
}
