using System;
using System.Collections.Generic;
namespace Bank.Models.Interfaces
{
    public interface IAccountRepository
    {
        List<IAccount> _Accounts
        { get; }

        public IAccount[] GetAll();

        public IAccount GetAccount(int id);

        public IAccount[] NewAccount(string name, IPrintStatement printStatement);

        public bool DeleteAccount(int id);
    }
}
