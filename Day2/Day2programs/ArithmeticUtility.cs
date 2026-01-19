using System;

namespace Day2.Day2programs
{
    internal class OutParameterClass
    {
     
        internal static void AddandMultiply( int value , out int add, out int multiply)
        {
           
            add = value +10;
            multiply = value*20;
        }
    }
    internal class ArithmeticUtility
    {
        static int value;
        internal double Power (double baseNum, double exponent)
        {
            return Math.Pow(baseNum, exponent);
        }
        internal double SquareRoot (double number)
        {
            return Math.Sqrt(number);
        }
        public static void Main(string[] args)
        {
            //ArithmeticUtility arithmeticUtility = new ArithmeticUtility();
            //Console.WriteLine("2 raised to the power 3 is: " + arithmeticUtility.Power(2, 3));
            //Console.WriteLine("5 raised to the power 4 is: " + arithmeticUtility.Power(5, 4));

            //---- here using out keyword to add and multiply-----

            int value = 5;
            OutParameterClass.AddandMultiply(value, out int add, out int multiply);
            Console.WriteLine(add+ " "+multiply);
        }
    }
}
