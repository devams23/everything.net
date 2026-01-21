using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day4.programs
{
    internal class LambdaExpressions
    {
        public static void Main()
        {
            List<int> numbers = new List<int> { 11, 2, 31, 4, 5, 6, 27, 8, 9, 10 };

            // filtering the even numbers, making a lambda expression , which returns true or false
            Func<int, bool> checkEven = (x) => { return x % 2 == 0; };
            IEnumerable<int> filterList =  numbers.Where(checkEven);

            //calculating the max value using the Aggregate Method, 
            int max = numbers.Aggregate((x,y) =>
            {
                if (x > y)
                {
                    return x;
                }
                return y;
                
            });
            Console.WriteLine("max value: "+max);

            // sorting the list using Order
            numbers = numbers.OrderBy(x => x).ToList();
            numbers.ForEach(x => Console.WriteLine(x));
         
            
        }
    }
}
