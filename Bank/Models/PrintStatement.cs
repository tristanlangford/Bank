using System;
using Bank.Models.Interfaces;
using System.Collections.Generic;

namespace Bank.Models
{
    public class PrintStatement : IPrintStatement
    {
        private const string Title = "date || credit || debit || balance";

        public string Print(List<IInteraction> history)
        {
            string statement = Title;
            foreach(IInteraction i in history)
            {
                if (GetValue(i) > 0)
                {
                    statement += "\n" + PrintDeposit(i);
                }
                else
                {
                    statement += "\n" + PrintWithdrawal(i);
                }
            }
            return statement;
        }

        private double GetValue(IInteraction interaction)
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
