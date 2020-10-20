using System;
using Xunit;
using Bank.Models;

namespace Bank_Tests
{
    public class InteractionTest
    {
        public Interaction interaction;

        public InteractionTest()
        {
            interaction = new Interaction(30.00m, 10.00m, () => new DateTime(2018, 03, 22));
        }

        [Fact]
        public void StoresOldBalance()
        {
            Assert.Equal(10.00m, interaction.GetOldBalance());
        }

        [Fact]
        public void SetsNewBalance()
        {
            Assert.Equal(40.00m, interaction.GetNewBalance());
        }

        [Fact]
        public void StoresCreationDate()
        {
            Assert.Equal("22/03/2018", interaction.GetDate());
        }

    }
}
