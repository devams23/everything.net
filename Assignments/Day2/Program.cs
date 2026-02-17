using System;
using Day2.Day2programs;
namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create an instance of the Calculator class created imported from Day2programs namespace 
            //Calculator calculator = new();
            //Console.WriteLine("Addition of 5.21 and 120.9 is: " + calculator.Add(5.21, 120.9));
            //Console.WriteLine("Subtraction of 10.3 and 5.21 is: " + calculator.Subtract(10.3, 5.21));
            //Console.WriteLine("Multiplication of 5 and 10 is: " + calculator.Multiply(5, 10));
            //Console.WriteLine("Division of 432.7 and 18.0 is: " + calculator.Divide(432.7, 18.0));
            //Console.WriteLine("Modulus of 38 and 3 is: " + calculator.Modulus(38, 3));

            object str1 = "hellostring";
            string str2 = "hellostring";
            bool areEqualUsingOperator = (str1 == str2); // false
            bool areEqualUsingMethod = str1.Equals(str2); // true
            Console.WriteLine($"Using '==': {areEqualUsingOperator}");
            Console.WriteLine($"Using 'Equals': {areEqualUsingMethod}");
        }
    }
}