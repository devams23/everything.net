using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Day3.programs
{
    
    internal class IncufficientBalanceException: Exception
    {
        internal IncufficientBalanceException() { }
        internal IncufficientBalanceException(string message) : base(message)
        {

        }
    }
    internal class ApnaBank
    {
         
        int balance = 0;

        internal ApnaBank(int balance) {
            this.balance = balance;
        }
        internal int AddBalance(int amount)
        {
            try
            {
                if (amount < 0)
                {
                    throw new ArgumentOutOfRangeException("Amount should be greater then zero");
                }
                else
                {
                    balance += amount;
                    return balance;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {

                Console.WriteLine(ex.Message);
            }


            return balance;

        }
        internal int WithdrawBalance(int amount)
        {
            Console.WriteLine("Your Current Balance"+ balance);
            try
            {
                if (balance >= amount)
                {
                    balance -= amount;
                    Console.WriteLine("Balance Deducted"+ amount);
                    return balance;
                }
                else
                {
                    throw new IncufficientBalanceException("Please Check Your Balance!");
                }
            }
            catch (IncufficientBalanceException ex) {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Remaining Balance!"+ balance);
            }

            return balance;
        }

        internal int GetBalance()
        {
            return balance;
        }
    }
    internal class CustomExceptions
    {
        static void Main(string[] args)
        {
            // initializing bank accout with Rs.1
            ApnaBank bankAccount1 = new ApnaBank(1);
            Console.WriteLine(bankAccount1.GetBalance());
            Console.WriteLine(bankAccount1.AddBalance(4000));
            Console.WriteLine(bankAccount1.WithdrawBalance(4100));
        }               
    }
}
