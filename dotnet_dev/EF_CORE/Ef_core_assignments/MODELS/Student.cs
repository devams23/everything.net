using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF_CORE.DAY_1.MODELS
{
    public class Student
    {

        public int StudentId { get; set; }

        [Required]
        [StringLength(50 , MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }


        public DateTime Created { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
