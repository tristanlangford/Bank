using System;
using Xunit;
using Bank.Models.Interfaces;
using Moq;
using Bank.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Tests
{
    public class AccountsListControllerTest
    {
        Mock<IAccountRepository> _accountRepository;
        Mock<IPrintStatement> _PrintStatementMock;
        AccountsListController accountsListController;
       
        public AccountsListControllerTest()
        {
            _PrintStatementMock = new Mock<IPrintStatement>();

            _accountRepository = new Mock<IAccountRepository>();
            _accountRepository.Setup(m => m.GetAll());
            _accountRepository.Setup(m => m.GetAccount(3));
            _accountRepository.Setup(m => m.NewAccount("test", _PrintStatementMock.Object));
            _accountRepository.Setup(m => m.DeleteAccount(1)).Returns(true);

            accountsListController = new AccountsListController(_accountRepository.Object, _PrintStatementMock.Object);
        }

        [Fact]
        public void GetAllGetsCalled()
        {
            accountsListController.GetAll();
            _accountRepository.Verify(p => p.GetAll(), Times.Once());
        }

        [Fact]
        public void GetAccountGetsCalled()
        {
            accountsListController.GetAccount(3);
            _accountRepository.Verify(p => p.GetAccount(3), Times.Once());
        }

        [Fact]
        public void NewAccountGetsCalled()
        {
            accountsListController.Create("test");
            _accountRepository.Verify(p => p.NewAccount("test", _PrintStatementMock.Object), Times.Once());
        }

        [Fact]
        public void DeleteGetsCalled()
        {
            accountsListController.Delete("1");
            _accountRepository.Verify(p => p.DeleteAccount(1), Times.Once());
        }

        [Fact]
        public void DeleteGetsWithTrueResponse()
        {
            accountsListController.Delete("1");
            _accountRepository.Verify(p => p.GetAll(), Times.Once());
        }

        [Fact]
        public void DeleteReturnsErrorWithFalseResponse()
        {
            _accountRepository.Setup(m => m.DeleteAccount(1)).Returns(false);
            var response = accountsListController.Delete("1");
            response.Should().BeOfType<NotFoundResult>();
        }
    }
}
