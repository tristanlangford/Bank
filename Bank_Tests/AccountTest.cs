using System;
using Xunit;
using System.Collections.Generic;
using Bank.Models;
using Bank.Models.Interfaces;
using Moq;

namespace Bank_Tech_Test_C_Unit_Tests
{
    public class AccountTest
    {
        public Account account;
        public Mock<IPrintStatement> printStatement;
        public List<IInteraction> historyMock;

        public AccountTest()
        {
            printStatement = new Mock<IPrintStatement>();
            historyMock = new List<IInteraction>();
            printStatement.Setup(p => p.Print(historyMock));

            account = new Account(printStatement.Object);
        }

        [Fact]
        public void BalanceStartsAt0()
        {
            Assert.Equal(0, account.Balance);
        }

        [Fact]
        public void DepositIncreasesBalance()
        {
            account.Deposit(30);
            Assert.Equal(30, account.Balance);
        }

        [Fact]
        public void DepositWithMinusErrors()
        {
            var err = Assert.Throws<InvalidOperationException>(() => account.Deposit(-10));
            Assert.Equal("Cannot deposit less than 0.01", err.Message);
        }

        [Fact]
        public void DepositAddsToInteractionList()
        {
            account.Deposit(30);
            Assert.IsType<Interaction>(account.history[0]);
        }

        [Fact]
        public void WithdrawDecreasesBalance()
        {
            account.Withdraw(30);
            Assert.Equal(-30, account.Balance);
        }

        [Fact]
        public void WithdrawWithMinusErrors()
        {
            var err = Assert.Throws<InvalidOperationException>(() => account.Withdraw(-30));
            Assert.Equal("Cannot withdraw less than 0.01", err.Message);
        }

        [Fact]
        public void WithdrawAddsToInteractionList()
        {
            account.Withdraw(30);
            Assert.IsType<Interaction>(account.history[0]);
        }

        [Fact]
        public void CallsPrintStatement()
        {
            account.Statement();
            printStatement.Verify(p => p.Print(historyMock), Times.Once());
        }

    }
}
