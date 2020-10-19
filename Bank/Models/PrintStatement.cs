using System;
using Bank.Models.Interfaces;
using System.Collections.Generic;

namespace Bank.Models
{
    public class PrintStatement : IPrintStatement
    {
        private const string Title = "date || credit || debit || balance";

        public List<string> Print(List<IInteraction> history)
        {
            List<string> Statement = new List<string> { Title };
            foreach (IInteraction i in history)
            {
                if (GetValue(i) > 0)
                {
                    Statement.Add(PrintDeposit(i));
                }
                else
                {
                    Statement.Add(PrintWithdrawal(i));
                }
            }
            return Statement;
        }

        private decimal GetValue(IInteraction interaction)
        {
            return interaction.GetNewBalance() - interaction.GetOldBalance();
        }

        private string PrintDeposit(IInteraction interaction)
        {
            return $"{interaction.GetDate()} || || {string.Format("{0:0.00}", (GetValue(interaction)))} || {string.Format("{0:0.00}", interaction.GetNewBalance())}";
        }

        private string PrintWithdrawal(IInteraction interaction)
        {
            return $"{interaction.GetDate()} || {string.Format("{0:0.00}", -GetValue(interaction))} || || {string.Format("{0:0.00}", interaction.GetNewBalance())}";
        }
    }
}
