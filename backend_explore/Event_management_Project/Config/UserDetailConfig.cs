using Event_management_Project.Repository.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Event_management_Project.Config;

public class UserDetailConfig : IEntityTypeConfiguration<UserAuthDetail>
{
    public void Configure(EntityTypeBuilder<UserAuthDetail> builder)
    {
        builder.HasKey(user => user.Id);

        builder.HasIndex(user => user.Username)
            .IsUnique();

        builder.HasIndex(user => user.Email)
            .IsUnique();

        builder.Property(user => user.Role)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasOne(user => user.UserDetail)
            .WithOne(detail => detail.UserAuthDetail)
            .HasForeignKey<UserDetail>(detail => detail.UserDetailId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
