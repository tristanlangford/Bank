using System;
using System.Collections.Generic;
using Bank.Models.Interfaces;

namespace Bank.Models
{
    public class Account : IAccount
    {
        public decimal Balance
        { get; private set; }

        public string _Name
        { get; private set; }

        public int _Id
        { get; private set; }

        public string[] _Statement
        {
            get { return Statement().ToArray(); }
            private set { }
        }

        public List<IInteraction> history = new List<IInteraction>();

        public IPrintStatement _printStatement;

        public Account(int Id, string Name, IPrintStatement printStatement = null)
        {
            _Id = Id;
            _Name = Name;

            Balance = 0.00m;
            if (printStatement == null)
            {
                _printStatement = new PrintStatement();
            } else
            {
                _printStatement = printStatement;
            }
        }

        public void Deposit(decimal value)
        {
            if(value <= 0)
            {
                throw new InvalidOperationException("Cannot deposit less than 0.01");
            } else
            {
                history.Add(new Interaction(value, Balance, () => DateTime.Now));
                Balance += value;
            }
        }

        public void Withdraw(decimal value)
        {
            if (value <= 0)
            {
                throw new InvalidOperationException("Cannot withdraw less than 0.01");
            }
            else
            {
                history.Add(new Interaction(-value, Balance,() => DateTime.Now));
                Balance -= value;
            }
        }

        public List<string> Statement()
        {
            return _printStatement.Print(history);
        }
    }
}
