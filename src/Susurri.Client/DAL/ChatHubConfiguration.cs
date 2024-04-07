using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Susurri.Client.Entities;

namespace Susurri.Client.DAL;

internal sealed class ChatHubConfiguration : IEntityTypeConfiguration<ChatMessage>
{
    public void Configure(EntityTypeBuilder<ChatMessage> builder)
    {
        builder.ToTable("ChatMessages");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Content).IsRequired().HasMaxLength(500);
        builder.Property(x => x.SenderUsername).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Timestamp).IsRequired();
        builder.Property(x => x.GroupId).IsRequired();
    } 
}