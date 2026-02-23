using EF_CORE_Final_PROJECT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CORE_Final_PROJECT.Config
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure (EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(emp => emp.Id );
            builder.Property(emp => emp.Name).IsRequired().HasMaxLength(100);
            builder.Property(emp => emp.Salary).IsRequired().HasColumnType("decimal(18,2)");
                
            
               
        }
    }
}
