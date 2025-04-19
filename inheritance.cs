using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Inheritance
{
    public class BankAccount
    {
        public int AccountNumber { get; set; }
        public string AccountHolder { get; set; }

        public double Balance {  get; protected set; }
        private static int nextAccountNumber = 1;

        public BankAccount(string accountHolder,double balance)
        {
            
            AccountHolder= accountHolder;
            AccountNumber = GenerateAccountNumber();
            Balance = balance;
        }
        private int GenerateAccountNumber()
        {
            return nextAccountNumber++;
        }
    }

    public class SavingAccounts : BankAccount
    {
        public double InterestRate {  get; private set; }

        public SavingAccounts(string accountHolder,double balance,double interestRate):base(accountHolder,balance)
        {
            InterestRate = interestRate;
        }

        public double CalculateIntersest(int months)
        {
            return Balance * InterestRate * months / 12;
        }
    }

    public class CheckingAccount : BankAccount
    {
        public double OverdraftLimit { get; private set; }

        public CheckingAccount(string accountHolder, double balance,double overdraftLimit):base(accountHolder,balance)
        {
            OverdraftLimit = overdraftLimit;
        }

        public void Withdraw(double amount)
        {
            if(Balance-amount >= OverdraftLimit)
            {
                Console.WriteLine("withdraw Successful");
            }
            else
            {
                Console.WriteLine($"Withdrawl not successfull for exceeding the limit {amount}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SavingAccounts sv_account = new SavingAccounts("Seerat", 5000, 0.03);
            Console.WriteLine($"Saving ACCount Information=Account HolderName= {sv_account.AccountHolder},Account Number = {sv_account.AccountNumber}, Balance = {sv_account.Balance}, Interest Rate = {sv_account.InterestRate}");
            Console.WriteLine("*****************************");
            double interest_rate=sv_account.CalculateIntersest(3);
            Console.WriteLine($"Interest Rate for 3 months = {interest_rate}");
            Console.WriteLine("**********************************");

            CheckingAccount CH_Account = new CheckingAccount("Azhar", 2000, 5000);
            Console.WriteLine($"Checking Account Informtiom = Account Holdr Name: {CH_Account.AccountHolder},Account Number = {CH_Account.AccountNumber}, Balance = {CH_Account.Balance}, Interest Rate = {CH_Account.OverdraftLimit}");
            Console.WriteLine("*********************************");
            CH_Account.Withdraw(1000);
        }
    }
}
