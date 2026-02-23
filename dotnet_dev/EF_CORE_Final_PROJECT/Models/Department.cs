using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CORE_Final_PROJECT.Models
{
    internal class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        
        public ICollection<Employee> Employees { get; set; }
    }
}
