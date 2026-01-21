using System;
using System.Collections.Generic;
using System.Text;
using Day4.programs.Data;
using Day4.programs.Payment;
//using DataService = Day4.programs.Data.Service;
//using PaymentService = Day4.programs.Payment.Service;

namespace Day4.programs
{
    internal class NamingConflicts
    {
        public static void Main()
        {

            /*
             so mainly there are two way to resolve naming conflicts in C#:

             * 1. using fully qualified names:
                Data.Service dataService = new Data.Service();
                Payment.Service paymentService = new Payment.Service();
                dataService.DisplayServiceName();
                paymentService.DisplayServiceName();

             * 2. using alias directives:
                 using DataService = Day4.programs.Data.Service;
                 using PaymentService = Day4.programs.Payment.Service;
                DataService dataService = new DataService();
                PaymentService paymentService = new PaymentService();
             */



        }


    }
}
