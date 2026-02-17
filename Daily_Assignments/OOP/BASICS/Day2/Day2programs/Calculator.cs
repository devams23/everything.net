using System;
using System.Collections.Generic;
using System.Text;

namespace Day2.Day2programs
{
    // A calculator class which has methods to perform basic arithmetic operations 
    internal class Calculator
    {

        //Method to add two numbers
        internal double Add(double a, double b)
        {
            //return a + b;
            return a += b; // using compound assignment operator

        }

        //Method to subtract two numbers
        internal double Subtract(double a, double b)
        {
            return a -= b;
        }

        //method to multiply two numbers
        internal double Multiply(double a, double b)
        {
            return a * b;
        }

        //method to divide two numbers
        internal double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Can't divide a number by 0.");
            }
            return a / b;
        }
        // method to find modulus of two numbers (returns remainder)
        internal int Modulus(int a, int b)
        {
            return a % b;
        }


        static void Main(string[] args)
        {
            //create an instance of the Calculator class created imported from Day2programs namespace 
            Calculator calculator = new();
            Console.WriteLine("Addition of 5.21 and 120.9 is: " + calculator.Add(5.21, 120.9));
            Console.WriteLine("Subtraction of 10.3 and 5.21 is: " + calculator.Subtract(10.3, 5.21));
            Console.WriteLine("Multiplication of 5 and 10 is: " + calculator.Multiply(5, 10));
            Console.WriteLine("Division of 432.7 and 18.0 is: " + calculator.Divide(432.7, 18.0));
            Console.WriteLine("Modulus of 38 and 3 is: " + calculator.Modulus(38, 3));


        }

    }
}
