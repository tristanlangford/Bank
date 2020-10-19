using System;
namespace Bank.Models.Interfaces
{
    public interface IInteraction
    {
        public decimal GetOldBalance();

        public decimal GetNewBalance();

        public string GetDate();

    }
}
