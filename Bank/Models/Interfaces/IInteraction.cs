using System;
namespace Bank.Models.Interfaces
{
    public interface IInteraction
    {
        public double GetOldBalance();

        public double GetNewBalance();

        public string GetDate();

    }
}
