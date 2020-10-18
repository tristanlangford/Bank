using System;
using Xunit;
using Moq;
using Bank.Models;
using Bank.Models.Interfaces;

namespace Bank_Tests
{
    public class AccountRepositoryTest
    {
        public IAccountRepository accountRepository;
        public AccountRepositoryTest()
        {
            accountRepository = new AccountRepository();
            accountRepository.NewAccount("Personal");
            accountRepository.NewAccount("Business");
        }

        [Fact]
        public void GetsAccounts()
        {
            Assert.Equal(2, accountRepository.GetAll().Length);
        }

        [Fact]
        public void AddsAccount()
        {
            accountRepository.NewAccount("Tristan's");
            Assert.Equal("Tristan's", accountRepository.GetAccount(3)._Name);
        }

        [Fact]
        public void FindsCorrectAccount()
        {
            var account = accountRepository.GetAccount(2);
            Assert.Equal("Business", account._Name);
        }

        [Fact]
        public void DeletesAccount()
        {
            accountRepository.DeleteAccount(1);
            Assert.Equal(1, accountRepository.GetAll().Length);
        }
    }
}
