using System;
using System.Collections.Generic;
namespace Bank.Models.Interfaces
{
    public interface IAccount
    {
        public decimal Balance
        { get; }

        public string _Name
        { get; }

        public int _Id
        { get; }

        public void Deposit(decimal value);

        public void Withdraw(decimal value);

        public List<string> Statement();
    }
}
