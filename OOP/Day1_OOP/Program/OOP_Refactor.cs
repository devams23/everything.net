using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;




namespace Day1_OOP.Program
{

    /*
     * changes done after refactoring: 
     * 1. made it more generic and reusable by creating an interface IBankAccount
     * 2. made it easy to add new account types without modifying existing code
     * 
     */

    interface IBankAccount
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        void DisplayAccountInfo();
    }

    // making it abstract, so that no one can create an instance of BankAccount directly.
    public abstract class BankAccount : IBankAccount
    {
        public string AccountNumber { get; }
        public string HolderName { get; }
        public decimal Balance { get; protected set; }

        // using abstract, because we want derived classes to implement their own version of AccountType and INTEREST_RATE
        public abstract string AccountType { get; }
        public abstract decimal INTEREST_RATE { get; } 
        protected BankAccount(string accNo, string holder, decimal balance)
        {
            Console.WriteLine("bank account constructor called");
            AccountNumber = accNo;
            HolderName = holder;
            Balance = balance;
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Invalid amount");
            Balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount > Balance) throw new InvalidOperationException("Insufficient funds");
            Balance -= amount;
        }
        public virtual void DisplayAccountInfo()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Holder Name: {HolderName}");
            Console.WriteLine($"Account Type: {AccountType}");
            Console.WriteLine($"Balance: {Balance}");
            
        }
    }

    public class SavingsAccount : BankAccount
    {
        // making the field readonly because it doesnt change laters, once assigned.
        public override decimal INTEREST_RATE { get; } = 2.5m;
        public override string AccountType => "SAVINGS";


        public override void DisplayAccountInfo()
        {
            base.DisplayAccountInfo();
            Console.WriteLine($"Interest Rate: {INTEREST_RATE}%");
        }
        public SavingsAccount(string accNumber, string holderName, decimal balance) : base( accNumber, holderName, balance)
        {
 
        }
    }

    public class CurrentAccount : BankAccount
    {
        public override string AccountType => "CURRENT";
        public override decimal INTEREST_RATE => 0m;
        // here we dont have to re-write other methods, but we have the ability to add new methods.
        public CurrentAccount(string accNumber, string holderName, decimal balance)
            : base(accNumber, holderName, balance)
        {
    
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

            IBankAccount currentAccount1 = new CurrentAccount("231sda", "DEvam", 432.4m);
            currentAccount1.DisplayAccountInfo();
            }
        }

    
}

