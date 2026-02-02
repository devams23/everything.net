using System;
namespace Day1_OOP.Program
{

    /*
     * There are a few issues in Procedural Programming: 
     * 1. What if we had multiple bank accounts to manage, and we want each bank account to have all the 
     * functionality same as everything..
     * 2. what if we want to inherit some properties, and dont have to write the same functions every time
     * 
     */
    public static class ApnaBank
    {

        public static string? AccountNumber;
        public static string? HolderName;
        public static float Balance;
        public static string? AccountType;

        public static void CreateAccount(string accNumber, string holderName, string accType)
        {
            AccountNumber = accNumber;
            HolderName = holderName;
            AccountType = accType;
            Balance = 0;
        }
        //just a helper method to reduce code duplication

        /// <summary>
        /// Prints a string message to the console.
        /// </summary>
        /// <param name="message"></param>
        public static void  CW(string message)
        {
            Console.WriteLine(message);
        }

        public static void Deposit(float amount)
        {
            if (amount <= 0)
            {
                CW("Deposit amount must be positive.");
                return;
            }

            Balance += amount;
            CW($"SUCCESS: Deposited {amount}. New Balance: {Balance}");
        }

        public static void Withdraw(float amount)
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

        public static void DisplayAccountInfo()
        {
            CW($"Account Number: {AccountNumber}");
            CW($"Holder Name: {HolderName}");
            CW($"Account Type: {AccountType}");
            CW($"Balance: {Balance}");
        }
        public static void Main(string[] args)
        {
            CreateAccount("129", "John Doe", "Savings");
            Deposit(1000);
            Withdraw(500);
            DisplayAccountInfo();
        }
    }

}