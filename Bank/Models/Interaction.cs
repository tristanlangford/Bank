using System;
using Bank.Models.Interfaces;

namespace Bank.Models
{
    public class Interaction : IInteraction
    {
        private readonly double _OldBalance;

        private readonly double _NewBalance;

        private readonly string Date;

        private readonly Func<DateTime> _DateTimeProvider;

        public Interaction(double value, double oldBalance, Func<DateTime> DateTimeProvider)
        {
            _OldBalance = oldBalance;
            _NewBalance = _OldBalance + value;
            _DateTimeProvider = DateTimeProvider;
            Date = _DateTimeProvider().ToString("dd/MM/yyyy");
        }

        public double GetOldBalance()
        {
            return Math.Round(_OldBalance, 2);
        }

        public double GetNewBalance()
        {
            return Math.Round(_NewBalance, 2);
        }

        public string GetDate()
        {
            return Date;
        }
    }
}
