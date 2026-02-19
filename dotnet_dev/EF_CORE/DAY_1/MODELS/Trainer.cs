using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF_CORE.DAY_1.MODELS
{
    // here when i say that a class has a list then , it means that class is the Parent Entity, eg. A trainner can me in multiple batches.

    public class Trainer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int ExperienceYears { get; set; }

        public ICollection<Batch> Batches { get; set; }

    }
}
