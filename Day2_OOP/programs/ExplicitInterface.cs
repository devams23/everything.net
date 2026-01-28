using System;
using System.Collections.Generic;
using System.Text;

namespace Day2_OOP.programs
{
    /*
     * general
     */
    interface ILogging
    {
        List<string> GetEvents(DateTime start, DateTime end);
    }
    interface IAuditing
    {
        List<string> GetEvents(DateTime start, DateTime end);
    }

    class ComplianceChecks : ILogging, IAuditing
    {
        List<string> ILogging.GetEvents(DateTime start, DateTime end)
        {
            Console.WriteLine("GETTING LOGS FROM: "+start + ", "+end);
            return ["LOG1", "LOG2"];
        }
        List<string> IAuditing.GetEvents(DateTime start, DateTime end)
        {
            Console.WriteLine("GETTING AUDITS FROM: " + start + ", " + end);
            return ["AUDIT1" , "AUDIT2"];
        }
    }
    internal class ExplicitInterface
    {
        static void Main()
        {

            /////------------------method1-----------
            ComplianceChecks logging = new ComplianceChecks();
            ILogging logging1 = logging;    
            List<string> logs  = logging1.GetEvents(DateTime.Today , DateTime.Today.AddDays(2));
            /////------------------method2-----------
            ((IAuditing)logging).GetEvents(DateTime.Today, DateTime.Today.AddDays(2));

        }
    }
}
