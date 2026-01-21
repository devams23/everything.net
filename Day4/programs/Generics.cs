using System;
using System.Collections.Generic;
using System.Text;

namespace Day4.programs
{
    internal class DataRepository<T>
    {
        
    }
    internal class Generics
    {
        // 
        static void Swap<T>(ref T  valuea , ref T valueb)
        {
            T temp = valuea;
            valuea = valueb;
            valueb = temp;
        }


        static void Main(string[] args)  {

            float valuea = 1232.4f;
            float valueb = 433.45f;
            Console.WriteLine("Before Swaping");
            Console.WriteLine("valuea:"+valuea + " valueb: "+ valueb);
            Swap<float>(ref valuea, ref valueb);
            Console.WriteLine("After Swaping");
            Console.WriteLine("valuea:" + valuea + "valueb: " + valueb);
            
        }
    }
}
