using System;
using System.Collections.Generic;
using System.Text;

namespace Day5.programs
{
    using System.Text;
    using System;
    public class Program
    {
        /// <summary>
        /// This method print the value.
        /// </summary>
        /// <param name="data">The first number.</param>

        /// <returns>Void.</returns>
        public static void cw(StringBuilder data)
        {
            Console.WriteLine(data);
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main()
        {
            StringBuilder sb = new StringBuilder();
           
            sb.Append("initial value");
            sb.AppendLine("second value");
            sb.AppendLine("third value");
            cw(sb);
        }
    }
}
