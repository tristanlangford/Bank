using System;
using Xunit;
using Moq;
using Bank.Models;
using Bank.Models.Interfaces;

namespace Bank_Tests
{
    public class AccountRepositoryTest
    {
        private IAccountRepository accountRepository;

        private Mock<IPrintStatement> printStatementMock;

        public AccountRepositoryTest()
        {
            accountRepository = new AccountRepository();
            printStatementMock = new Mock<IPrintStatement>();
            accountRepository.NewAccount("Personal", printStatementMock.Object);
            accountRepository.NewAccount("Business", printStatementMock.Object);
        }

        [Fact]
        public void GetsAccounts()
        {
            Assert.Equal(2, accountRepository.GetAll().Length);
        }

        [Fact]
        public void AddsAccount()
        {
            accountRepository.NewAccount("Tristan's", printStatementMock.Object);
            Assert.Equal("Tristan's", accountRepository.GetAccount(3)._Name);
        }

        [Fact]
        public void FindsCorrectAccount()
        {
            var account = accountRepository.GetAccount(2);
            Assert.Equal("Business", account._Name);
        }

        [Fact]
        public void ReturnsFalseWhenNoAccount()
        {
            var account = accountRepository.GetAccount(10);
            Assert.Null(account);
        }

        [Fact]
        public void DeletesAccount()
        {
            accountRepository.DeleteAccount(1);
            Assert.Equal(1, accountRepository.GetAll().Length);
        }
    }
}
