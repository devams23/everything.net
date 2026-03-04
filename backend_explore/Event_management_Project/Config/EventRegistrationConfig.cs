using Event_management_Project.Repository.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Event_management_Project.Config;

public class EventRegistrationConfig : IEntityTypeConfiguration<EventRegistration>
{
    public void Configure(EntityTypeBuilder<EventRegistration> builder)
    {
        builder.HasKey(er => new { er.EventId, er.UserId });

        builder.Property(er => er.RegistrationStatus)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasOne(er => er.Event)
            .WithMany(e => e.Registrations)
            .HasForeignKey(er => er.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(er => er.User)
            .WithMany()
            .HasForeignKey(er => er.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(er => new { er.UserId, er.RegisteredUtc });
        builder.HasIndex(er => new { er.EventId, er.RegistrationStatus, er.WaitlistPosition });
    }
}
