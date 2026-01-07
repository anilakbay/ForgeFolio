using ForgeFolio.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForgeFolio.Infrastructure.Data.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.NameSurname)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Subject)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.MessageDetail)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(x => x.MessageDate)
            .HasDefaultValueSql("GETDATE()");

        builder.HasIndex(x => x.IsDeleted);
        builder.HasIndex(x => x.IsRead);
    }
}
