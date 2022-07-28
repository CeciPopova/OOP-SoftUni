namespace BankSolution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Account
    {
        private decimal balance;
        private readonly List<Tranzaction> tranzactions;
        public Account(decimal amount)
        {

            this.Balance = amount;
            this.tranzactions = new List<Tranzaction>
            {
                new Tranzaction(DateTime.UtcNow, amount, "Initial Balance")
            };
        }
        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("You cannot have a negative balance. ");
                }
                this.balance = value;
            }
        }



        public void Deposit(decimal amount, string reference)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("You need to deposit a positive amounof money ");
            }
            this.Balance += amount;
            this.tranzactions.Add(new Tranzaction(DateTime.UtcNow, amount, reference));
        }
        public void Withdraw(decimal amount)
        {

            const decimal withdrawTax = 0.5m;
            amount += withdrawTax;
            if (this.Balance < amount)
            {
                throw new InvalidOperationException("You cannot have enough money for this operation.");
            }

            this.balance -= amount;
            this.tranzactions.Add(new Tranzaction(DateTime.UtcNow, -amount + withdrawTax, "Withdrawal ATM"));
            this.tranzactions.Add(new Tranzaction(DateTime.UtcNow, -withdrawTax, "Withdrawal Bank Tax"));
        }
        public List<string> TransactionHistory()
        {
            return this.tranzactions.Select(t => t.ToString()).ToList();
        }
    }
}
