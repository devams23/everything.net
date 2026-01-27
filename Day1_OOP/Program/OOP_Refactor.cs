using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;




namespace Day1_OOP.Program
{

    /*
     * There are a few issues in Procedural Programming: 
     * 1. What if we had multiple bank accounts to manage, and we want each bank account to have all the 
     * functionality same as everything..
     * 2. what if we want to inherit some properties, and dont have to write the same functions every time
     * 
     */

    interface IBankAccount
    {
        void Deposit(float amount);
        void Withdraw(float amount);
        void DisplayAccountInfo();
    }

    public class SavingsAccount : IBankAccount
    {
        // making the field readonly because it doesnt change laters, once assigned.
        private readonly string? AccountNumber;
        protected float INTEREST_RATE = 2.5f;
        protected string AccountType = "SAVINGS";

        public string? HolderName { get; set; }
        private float Balance;


        public SavingsAccount(string accNumber, string holderName, float balance)
        {
            AccountNumber = accNumber;
            HolderName = holderName;
            Balance = balance ;

        }
        //just a helper method to reduce code duplication

        /// <summary>
        /// Prints a string message to the console.
        /// </summary>
        /// <param name="message"></param>
        public void CW(string message)
        {
            Console.WriteLine(message);
        }
        public  void Deposit(float amount)
        {
            if (amount <= 0)
            {
                CW("Deposit amount must be positive.");
                return;
            }

            Balance += amount;
            CW($"SUCCESS: Deposited {amount}. New Balance: {Balance}");
        }

        public  void Withdraw(float amount)
        {
            if (amount <= 0)
            {
                CW("Withdrawal amount must be positive.");
                return;
            }
            if (amount > Balance)
            {
                CW("Insufficient funds for this withdrawal.");
                return;
            }
            Balance -= amount;
            CW($"SUCCESS: {amount} DEDUCTED. CURRENT BALANCE: {Balance}");
        }

        public  void DisplayAccountInfo()
        {
            CW($"Account Number: {AccountNumber}");
            CW($"Holder Name: {HolderName}");
            CW($"Account Type: {AccountType}");
            CW($"Balance: {Balance}");
            CW("INTEREST RATE: "+ INTEREST_RATE);
        }
    }

    public class CurrentAccount : SavingsAccount
    {
        
        // here we dont have to re-write other methods, but we have the ability to add new methods.
        public CurrentAccount(string accNumber, string holderName, float balance)
            : base(accNumber, holderName, balance)
        {
            AccountType = "CURRENT";
            INTEREST_RATE = 0f;
        }
    }
    internal class OOP_Refactor
    {
            public static void Main(string[] args)
            {

            /* making it loose-couples as, in methods while we pass we dont have to specify the type of
                account, just have to do (IBankAccount account)
            */
            IBankAccount savingsAccount1 = new SavingsAccount("124abc", "DEVAM", 3432);
            savingsAccount1.DisplayAccountInfo();

            IBankAccount currentAccount1 = new CurrentAccount("231sda", "DEvam", 432.4f);
            currentAccount1.DisplayAccountInfo();
            }
        }

    
}

