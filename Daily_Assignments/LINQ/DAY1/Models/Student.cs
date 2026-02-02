using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ.DAY1.Models
{
    internal class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; } = String.Empty;
        private int _marks;

        public int Marks
        {
            get { return _marks; }
            set
            {
                if (value < 0 || value >100)
                {
                    Console.WriteLine("Marks should be between 0 and 100.");
                }
                else
                {
                    _marks = value;
                }

            }
        }

    }
}
