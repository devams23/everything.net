using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CORE_Final_PROJECT.Models
{
    internal class TrainingProgram
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int TrainerId { get; set; }

        public Trainer Trainer { get; set; }    
        public int DurationinDays { get; set; }
        public DateTime StartDate { get; set; }

        public ICollection<TrainingEnrolledEmployee> TrainingEnrolledEmployees { get; set; }

    }
}
