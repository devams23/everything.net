using EF_CORE_Final_PROJECT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EF_CORE_Final_PROJECT.Config
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(dep => dep.Id);
            builder.Property(dep => dep.Name).IsRequired().HasMaxLength(100);
            builder.Property(dep => dep.Location).IsRequired().HasMaxLength(100);

            builder.HasMany(dep => dep.Employees)     // Defines one side of the relationship
                   .WithOne(emp => emp.Department)   // Defines the other side (collection)
                   .HasForeignKey(emp => emp.DepartmentId)     // Specifies the foreign key property in the dependent entity
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
