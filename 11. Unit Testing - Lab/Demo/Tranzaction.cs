using System;

namespace BankSolution
{
    public class Tranzaction
    {
        public Tranzaction(DateTime tranzactionDate, decimal amount, string reference)
        {
            TranzactionDate = tranzactionDate;
            Amount = amount;
            Reference = reference;

        }
        public DateTime TranzactionDate { get; private set; }
        public decimal Amount { get; private set; }
        public string Reference { get; private set; }
        public override string ToString()
        {
            var typeOfTranzaction = this.Amount > 0 ? "Deposit" : "Withdrawal";
            return $"{this.TranzactionDate.ToShortDateString()}:{this.TranzactionDate.ToShortTimeString()}UTC - {typeOfTranzaction}: {Amount:f2} - {Reference}";
        }
    }
}
