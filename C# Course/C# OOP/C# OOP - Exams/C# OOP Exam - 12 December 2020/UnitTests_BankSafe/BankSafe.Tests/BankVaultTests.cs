using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        BankVault bank;

        [SetUp]
        public void Setup()
        {
            bank = new BankVault();
        }

        [Test]
        public void Ctor_ChekcIfCtorIsCreatingInstanceOfBankVault()
        {
            int expectedCount = bank.VaultCells.Count;

            Assert.That(bank.VaultCells.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void AddItem_CheckIfItemIsAddedCorrectly()
        {
            Item item = new Item("Daniel", "10");

            bank.AddItem("A1", item);

            Assert.That(bank.VaultCells["A1"], Is.EqualTo(item));
        }

        [Test]
        public void AddItem_ThrowExceptionIfCellDoesNotExists()
        {
            Item item = new Item("Daniel", "10");

            Assert.Throws<ArgumentException>(() => bank.AddItem("Nikolov", item));
        }

        [Test]
        public void AddItem__ThrowExceptionIfCellIsTaken()
        {
            Item item = new Item("Daniel", "10");
            Item itemTwo = new Item("Daniel", "11");

            bank.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => bank.AddItem("A1", itemTwo));
        }
        
        [Test]
        public void AddItem_ThrowExceptionIfItemExists()
        {
            Item item = new Item("Daniel", "10");

            bank.AddItem("A1", item);

            Assert.Throws<InvalidOperationException>(() => bank.AddItem("A2", item));
        }

        [Test]
        public void AddItem_CheckIfReturnsCorrectStringWhenAnItemIsAdded()
        {
            Item item = new Item("Daniel", "10");

            string output = bank.AddItem("A1", item);
            string expectedOutput = $"Item:{item.ItemId} saved successfully!";

            Assert.That(output, Is.EqualTo(expectedOutput));
        }

        [Test]
        public void RemoveItem_ThrowExceptionIfCellDoesNotExists()
        {
            Item item = new Item("A1", "10");
            Assert.Throws<ArgumentException>(() => bank.RemoveItem("Nikolov", item));
        }

        [Test]
        public void RemoveItem_ThrowExceptionIfItemDiffersFromTheOneInTheCell()
        {
            Item item = new Item("A1", "10");
            Item itemTwo = new Item("A2", "11");

            bank.AddItem("A1", item);
            bank.AddItem("A2", itemTwo);

            Assert.Throws<ArgumentException>(() => bank.RemoveItem("A2", item));
        }

        [Test]
        public void RemoveItem_CheckIfReturnsCorrectStringIfItemIsRemoved()
        {
            Item item = new Item("A1", "10");

            bank.AddItem("A1", item);

            string output = bank.RemoveItem("A1", item);
            string expectedOutput = $"Remove item:{item.ItemId} successfully!";

            Assert.That(output, Is.EqualTo(expectedOutput));
        }

        [Test]
        public void RemoveItem_CheckIfItemIsCorrecltyRemoved()
        {
            Item item = new Item("A1", "10");
            
            bank.AddItem("A1", item);
            bank.RemoveItem("A1", item);

            Assert.That(bank.VaultCells["A1"], Is.EqualTo(null));
        }
    }
}