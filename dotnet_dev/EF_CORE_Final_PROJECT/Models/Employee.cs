using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CORE_Final_PROJECT.Models
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public decimal Salary { get; set; }

        public ICollection<TrainingEnrolledEmployee> TrainingEnrolledEmployees { get; set; }



    }
}
