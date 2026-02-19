using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CORE.DAY_1.MODELS
{
    public class Batch
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int CourseId { get; set; }
        public int TrainerId { get; set; }

        public virtual Trainer Trainer { get; set; }
        public virtual Course Course { get; set; }



    }
}
