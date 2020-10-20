using System;
using Bank.Models;
using Bank.Models.Interfaces;
using System.Collections.Generic;
using Xunit;
using Moq;

namespace Bank_Tests
{
    public class PrintStatementTest
    {
        public List<IInteraction> history;
        public IPrintStatement printStatement;

        public PrintStatementTest()
        {
            printStatement = new PrintStatement();

            var MockInteraction1 = new Mock<IInteraction>();
            MockInteraction1.Setup(p => p.GetDate()).Returns("22/04/2018");
            MockInteraction1.Setup(p => p.GetNewBalance()).Returns(500);
            MockInteraction1.Setup(p => p.GetOldBalance()).Returns(0);

            var MockInteraction2 = new Mock<IInteraction>();
            MockInteraction2.Setup(p => p.GetDate()).Returns("22/09/2020");
            MockInteraction2.Setup(p => p.GetNewBalance()).Returns(50);
            MockInteraction2.Setup(p => p.GetOldBalance()).Returns(500);
            history = new List<IInteraction> { MockInteraction1.Object, MockInteraction2.Object };
        }

        [Fact]
        public void ContainsTitle()
        {
            Assert.Contains("date || credit || debit || balance", printStatement.Print(history));
        }

        [Fact]
        public void PrintsSingleHistory()
        {
            Assert.Contains("22/04/2018 || || 500.00 || 500.00", printStatement.Print(history));
        }

        [Fact]
        public void CorrectFormatForWithdrawal()
        {
            Assert.Contains("22/09/2020 || 450.00 || || 50.00", printStatement.Print(history));
        }

        [Fact]
        public void DealsWithList()
        {
            Assert.Contains("22/04/2018 || || 500.00 || 500.00", printStatement.Print(history));
            Assert.Contains("22/09/2020 || 450.00 || || 50.00", printStatement.Print(history));
        }

    }


}
