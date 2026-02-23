using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CORE_Final_PROJECT.Models
{
    internal class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearsOfExperience { get; set; }

        public ICollection <TrainingProgram> TrainingPrograms { get; set; }


    }
}
