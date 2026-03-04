using Event_management_Project.Repository.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Event_management_Project.Config;

public class EventConfig : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.EventId);

        builder.Property(e => e.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasOne(e => e.Organizer)
            .WithMany()
            .HasForeignKey(e => e.OrganizerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.StartUtc);
        builder.HasIndex(e => new { e.OrganizerId, e.StartUtc });
        builder.HasIndex(e => new { e.Status, e.StartUtc });
    }
}
