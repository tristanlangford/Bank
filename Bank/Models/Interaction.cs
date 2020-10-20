using System;
using Bank.Models.Interfaces;

namespace Bank.Models
{
    public class Interaction : IInteraction
    {
        private readonly decimal _OldBalance;

        private readonly decimal _NewBalance;

        private readonly string Date;

        private readonly Func<DateTime> _DateTimeProvider;

        public Interaction(decimal value, decimal oldBalance, Func<DateTime> DateTimeProvider)
        {
            _OldBalance = oldBalance;
            _NewBalance = _OldBalance + value;
            _DateTimeProvider = DateTimeProvider;
            Date = _DateTimeProvider().ToString("dd/MM/yyyy");
        }

        public decimal GetOldBalance()
        {
            return _OldBalance;
        }

        public decimal GetNewBalance()
        {
            return _NewBalance;
        }

        public string GetDate()
        {
            return Date;
        }
    }
}
