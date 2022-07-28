using System;

namespace BankSolution
{
    public class Program
    {
        static void Main(string[] args)
        {

            var account = new Account(100);
            account.Withdraw(50);
            Console.WriteLine(account.Balance);
            account.Withdraw(200);
        }
    }
}
