using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;

namespace Day3.programs
{
    
    internal class IncufficientBalanceException: Exception
    {
        public float AmountValue;
        internal IncufficientBalanceException() { }
        internal IncufficientBalanceException(string message , float amount) : base(message)
        {
               AmountValue = amount;
        }
    }
    internal class ApnaBank
    {
         
        float balance = 0.0f;

        internal ApnaBank(float balance) {
            this.balance = balance;
        }
        internal float AddBalance(float amount)
        {
            try
            {
                ValidateAmount(amount);

                balance += amount;
                return balance;

            }
            catch (ArgumentOutOfRangeException ex)
            {

                Console.WriteLine(ex.Message);
            }


            return balance;

        }

        internal void ValidateAmount(float amount)
        {
            // if the value is negative or zero than throw exception, as shorthand for if (amount <= 0)
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        }
        internal void ValidateSufficientBalance(float amount)
        {

            ValidateAmount(amount);

            if (amount > balance)
            {
                throw new IncufficientBalanceException("Insufficient Balance in your account", amount);
            }
        }
        internal void DeductMoney(float amount)
        {
            balance -= amount;
            
        }
        internal float WithdrawBalance(float amount)
        {
            Console.WriteLine("Your Current Balance"+ balance);
            try
            {
                Console.WriteLine("Withdrawing Amount"+ amount);
                // checks for if amount is valid and sufficient
                ValidateSufficientBalance(amount);
                DeductMoney(amount);
            }
            catch( ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("EXCEPTION OCCURED: "+ex.Message);
                
            }
            catch (IncufficientBalanceException ex) {
                Console.WriteLine("EXCEPTION OCCURED:"+ ex.Message+ " Can't withraw "+ ex.AmountValue);
            }
            finally
            {
                Console.WriteLine("Remaining Balance!"+ balance);
            }

            return balance;
        }

        internal float  GetBalance()
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
