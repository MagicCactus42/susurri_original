using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Susurri.Core.Entities;
using Susurri.Core.ValueObjects;

namespace Susurri.Core.DAL.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new UserId(x));
        builder.HasIndex(x => x.Username).IsUnique();
        builder.Property(x => x.Username)
            .HasConversion(x => x.Value, x => new Username(x))
            .IsRequired()
            .HasMaxLength(30);
        builder.Property(x => x.Password)
            .HasConversion(x => x.Value, x => new Password(x))
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(x => x.Role)
            .HasConversion(x => x.Value, x => new Role(x))
            .IsRequired()
            .HasMaxLength(30);
        builder.Property(x => x.CreatedAt).IsRequired();
    }
}