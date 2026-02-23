using EF_CORE_Final_PROJECT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EF_CORE_Final_PROJECT.Config
{
    internal class TrainingProgramConfiguration : IEntityTypeConfiguration<TrainingProgram>
    {
        public void Configure(EntityTypeBuilder<TrainingProgram> builder)
        {

            builder.HasKey(tr => tr.Id);
            builder.HasIndex(tr => tr.Title).IsUnique();
            builder.Property(tr => tr.Title).HasMaxLength(100);




        }
    }
}
