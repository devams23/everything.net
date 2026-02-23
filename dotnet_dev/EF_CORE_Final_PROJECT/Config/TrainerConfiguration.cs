using EF_CORE_Final_PROJECT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EF_CORE_Final_PROJECT.Config
{
    internal class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.HasKey(tr => tr.Id);
            builder.Property(tr => tr.Name).IsRequired().HasMaxLength(100);

            builder.HasMany(tr => tr.TrainingPrograms)     // Defines one side of the relationship
                   .WithOne(tp => tp.Trainer)              // Defines the other side (collection) it sets the one-many relationship
                   .HasForeignKey(tp => tp.TrainerId)     // Specifies the foreign key property in the dependent entity
                   .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
