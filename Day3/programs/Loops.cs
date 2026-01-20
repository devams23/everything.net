using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace Day3.programs
{
    internal class Loops
    {
        //----------------- Using for--loop to print prime numbers--------------------//
        internal void DisplayFirstNPrimeNumbers(int n)
        {
            for (int i = 2; i <= n; i++)
            {
                if (isNumberPrime(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        internal bool isNumberPrime(int n)
        {
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        //----------------- Using while for a guessing game--------------------//

        internal int GuessingNumber(int guessNumber)
        {
            int guessCount = 1;
            int maxGuessCount = 10;

            Console.WriteLine("----- GUESSING GAME-----");
            while (guessCount <= maxGuessCount)
            {
                Console.Write("Enter your Guess:");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int value))
                {
                    if (value == guessNumber)
                    {
                        return guessCount;
                    }
                    //if (Math.Abs(value-guessNumber) <=3)
                    //{
                    //    Console.WriteLine("The radius");
                    //}
                    else if (value < guessNumber)
                    {
                        Console.WriteLine("The value is Low!");
                    }
                    else
                    {
                        Console.WriteLine("The value is high!");
                    }
                    guessCount++;
                }
                else
                {
                    Console.WriteLine("::INVALID INPUT:: Please enter a valid integer.");
                }
            }
            return -1;
        }

        //--------------------Use foreach to iterate collections------//
        internal void DisplayCollection()
        {
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>
            {
                { 189,"devam" },
                { 2221, "raj" },
                { 2121, "vikram"}
            };
            if (keyValuePairs.Count > 0)
            {
                foreach (var item in keyValuePairs)
                {
                    Console.WriteLine("Key: " + item.Key + " Value: " + item.Value);
                }

            }
        }


        static void Main(string[] args)
        {
            Loops loops = new Loops();
            //loops.DisplayFirstNPrimeNumbers(10);

            //int guessCount = loops.GuessingNumber(23);
            //if (guessCount ==-1)
            //{
            //    Console.WriteLine("Failed at guessing! Better Luck next time");
            //}
            //else
            //{
            //    Console.WriteLine("Great Job! You guessed number in "+guessCount+ " turns");
            //}
            loops.DisplayCollection();
        }
    }

}
