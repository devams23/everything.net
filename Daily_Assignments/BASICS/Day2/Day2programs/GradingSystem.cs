using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace Day2.Day2programs
{
    /* 
     
     A grading system using if-else and switch 
      
     */

    internal class GradingSystem
    {
        public static string GradingSystemIfElse(int marks)
        {
            // using if-else ladder 

            if (marks < 0 || marks > 100)
            {
                return "Invalid Marks";
            }
            else if (marks >= 90)
                return "AA";
            else if (marks >= 80)
                return "AB";
            else if (marks >= 70)
                return "BB";
            else if (marks >= 60)
                return "BC";
            else if (marks >= 50)
                return "C";
            else
                return "F";

        }

        public static string GradingSystemSwitch(int marks)
        {
            // traditional switch statement 
            //if (marks < 0 || marks > 100)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(marks), marks, "Enter Marks between 0 and 100.");
            //}
            //else
            //{
            //    switch (marks)
            //    {
            //        case >= 90:
            //            return "AA";                        

            //        case >= 80:
            //            return "AB";
            //        case >= 70:
            //            return "BB";
            //        case >= 60:
            //            return "BC";
            //        case >= 50:
            //            return "CC";
            //        default:
            //            return "F";
            //    }

            //}

            // ------using switch expression (modern structure)---------------
            if (marks < 0 || marks > 100)
            {
                throw new ArgumentOutOfRangeException("Enter Marks between 0 and 100.");
            }
            else
            {
                return marks switch
                {
                    // "_" is the discard pattern that matches any value
                    >= 90 => "AA",
                    >= 80 => "AB",
                    >= 70 => "BB",
                    >= 60 => "BC",
                    >= 50 => "CC",
                    _ => "F"
                };

            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Grading System using if-else:" + GradingSystemIfElse(89));
            Console.WriteLine("Grading System using if-else:" + GradingSystemSwitch(8));
        }
    }
}
