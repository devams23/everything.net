using System;
using System.Collections.Generic;
using System.Text;

namespace Day4.programs
{
    internal class DataRepository<T>
    {
        List<T> list;
        internal DataRepository()
        {
            list = new List<T>();
        }

        internal void Add(T item)
        {
            list.Add(item);
        }
        internal T Get(int index)
        {
            return list[index];
        }
        internal IEnumerable<T> GetAll()
        {
            return list;
        }
    }
    internal class Generics
    {
        // a generic method to swap two values
        static void Swap<T>(ref T  valuea , ref T valueb)
        {
            T temp = valuea;
            valuea = valueb;
            valueb = temp;

        }


        static void Main(string[] args)  {

            //float valuea = 1232.4f;
            //float valueb = 433.45f;
            //Console.WriteLine("Before Swaping");
            //Console.WriteLine("valuea:"+valuea + " valueb: "+ valueb);
            //Swap<float>(ref valuea, ref valueb);
            //Console.WriteLine("After Swaping");
            //Console.WriteLine("valuea:" + valuea + "valueb: " + valueb);
            
            DataRepository<string> stringRepo = new DataRepository<string>();
            stringRepo.Add("data1");
            stringRepo.Add("data2");

            // explicitly converting IEnumerable to List
            List<string> allStrings = stringRepo.GetAll().ToList();
            foreach (var item in allStrings)
            {
                Console.WriteLine(item);
            }
        }
    }
}
