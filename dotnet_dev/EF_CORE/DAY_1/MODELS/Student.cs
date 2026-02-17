using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CORE.DAY_1.MODELS
{
    internal class Student
    {
        // this will be an Identity , by default
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;

    }
}
