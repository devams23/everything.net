using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CORE.DAY_1.MODELS
{
    internal class Course
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Fees { get; set; }
        public int DurationInMonths { get; set; } = 0;







    }

}
