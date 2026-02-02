using System;
using System.Collections.Generic;
using System.Text;

namespace Day2.Day2programs
{
    internal class OptionalParam
    {
           public void DisplayName(string value , int count = 1 , string delimiter="")
           {
            for (int i = 0; i < count; i++)
            {
                
                Console.Write(delimiter + value);
            }
            Console.WriteLine();
        } 
        public static void Main(string[] args)
        {
            OptionalParam optionalParam = new OptionalParam();

            //  the default delimiter is "" ,
            optionalParam.DisplayName("devam", 3 );
            optionalParam.DisplayName("devam" ,10, delimiter:"#");
        }
    }
}
