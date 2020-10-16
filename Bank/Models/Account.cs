using System;
using System.Collections.Generic;
using Bank.Models.Interfaces;

namespace Bank.Models
{
    public class Account
    {
        public double Balance
        { get; private set; }

        public List<IInteraction> history = new List<IInteraction>();
        public IPrintStatement _printStatement;

        public Account(IPrintStatement printStatement = null)
        {
            Balance = 0;
            if (printStatement == null)
            {
                _printStatement = new PrintStatement();
            } else
            {
                _printStatement = printStatement;
            }
        }

        public void Deposit(double value)
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

        public void Withdraw(double value)
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

        public string Statement()
        {
            return _printStatement.Print(history);
        }
    }
}
