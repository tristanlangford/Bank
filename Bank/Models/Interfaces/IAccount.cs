using System;
namespace Bank.Models.Interfaces
{
    public interface IAccount
    {
        public double Balance
        { get; }

        public void Deposit(double value);

        public void Withdraw(double value);

        public string Statement();
    }
}
