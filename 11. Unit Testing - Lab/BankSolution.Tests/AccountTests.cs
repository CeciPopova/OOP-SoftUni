using NUnit.Framework;
using System;

namespace BankSolution.Tests
{

    internal class AccountTests
    {
        [Test]
        public void WithNegativeStartingBalanceShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var account = new Account(-100);
            }, "You cannot have a negative balance.");
        }
        [Test]
        public void DepositWithPositiveAmountShouldAddToBalance()
        {
            //Arrange
            var account = new Account(100);
            //Act
            account.Deposit(200, "salary");
            //Assert
            Assert.That(account.Balance, Is.EqualTo(300));
        }
        [Test]
        public void WithdrawWhithValidAmountShouldSubstractFromBalance()
        {
            Account account = new Account(100);
            account.Withdraw(40);
            Assert.That(account.Balance, Is.EqualTo(59.5));
        }
        [Test]
        public void WhithdrawWithInvalidAmountShouldTrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var account = new Account(500);
                account.Withdraw(1000);
            }, "You dont have enough money for this operation.");
        }
        [Test]
        public void TranzactionHistoryShouldReturnCorrectValues()
        {
            //Arrange
            var account = new Account(100);

            account.Deposit(500, "From Parents");
            account.Deposit(1500, "Salary");
            account.Withdraw(300);
            account.Withdraw(800);
            account.Deposit(2000, "Car Trade");
            account.Withdraw(450);
            //Act
            var tranzactionHistory = account.TransactionHistory();
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(tranzactionHistory[0], Contains.Substring("Deposit: 100.00 - Initial Balance"));
                Assert.That(tranzactionHistory[1], Contains.Substring("Deposit: 500.00 - From Parents"));
                Assert.That(tranzactionHistory[2], Contains.Substring("Deposit: 1500.00 - Salary"));
                Assert.That(tranzactionHistory[3], Contains.Substring("Withdrawal: -300.00 - Withdrawal ATM"));
            });
        }
    }
}
