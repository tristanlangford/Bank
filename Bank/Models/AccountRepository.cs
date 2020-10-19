using System;
using System.Collections.Generic;
using Bank.Models.Interfaces;
namespace Bank.Models
{
    public class AccountRepository : IAccountRepository
    {
        public List<IAccount> _Accounts
        { get; private set; }

        private int IdCount;

        public AccountRepository()
        {
            _Accounts = new List<IAccount>();
            IdCount = 1;
        }

        public IAccount[] GetAll()
        {
            return _Accounts.ToArray();
        }

        public IAccount GetAccount(int Id)
        {
           return _Accounts.Find(account => account._Id == Id);
        }

        public IAccount[] NewAccount(string name)
        {
            var NewAccount = new Account(IdCount, name);
            _Accounts.Add(NewAccount);
            IdCount++;
            return _Accounts.ToArray();
        }

        public bool DeleteAccount(int Id)
        {
            var accountToRemove = GetAccount(Id);
            return _Accounts.Remove(accountToRemove);
        }

    }
}
