using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CORE_Final_PROJECT.Models
{
    /*
     * this is the join table betweeen Employees and Training Programs , 
     * 
     * Many => Many Relation between Employees and Training Programs
     * --One Employee can be in multiple  Training Programs
     * --One Training-Program can have multiple Employees
     * 
     */
    internal class TrainingEnrolledEmployee
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
  
        public int TrainingProgramId { get; set; }
        public TrainingProgram TrainingProgram { get; set; }

        public int PerformanceScore { get; set; }


    }
}
