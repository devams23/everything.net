using EF_CORE_Final_PROJECT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CORE_Final_PROJECT.Config
{
    internal class EnrolledEmployeeConfiguration : IEntityTypeConfiguration<TrainingEnrolledEmployee>
    {
        public void Configure(EntityTypeBuilder<TrainingEnrolledEmployee> builder)
        {

            /*
             * here we are making 1-M relationship between Employee and TrainingEnrolledEmploye
             *                     1- M between TrainingProgram and TrainingEnrolledEmployee
             *                  this will make the TrainingEnrolledEmployee as a junction table between Employee and TrainingProgram
             */
            builder.HasKey(enrolledEmp => new { enrolledEmp.EmployeeId, enrolledEmp.TrainingProgramId });

            builder.HasOne(enrolledEmp => enrolledEmp.Employee)
                   .WithMany(emp => emp.TrainingEnrolledEmployees)
                   .HasForeignKey(enrolledEmp => enrolledEmp.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(enrolledEmp => enrolledEmp.TrainingProgram)
                   .WithMany(tp => tp.TrainingEnrolledEmployees)
                   .HasForeignKey(enrolledEmp => enrolledEmp.TrainingProgramId) // here Training Program is the principal and TrainingEnrolledEmployee is the dependent
                   .OnDelete(DeleteBehavior.Cascade);


            builder.Property(enrolledEmp => enrolledEmp.PerformanceScore)
                   .IsRequired().HasDefaultValue(0);
        }
    }
}
