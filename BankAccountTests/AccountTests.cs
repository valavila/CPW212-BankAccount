using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc;
        [TestInitialize] //Code runs before EACH test
        public void Initialize()
        {
            acc = new Account();
        }

        [TestMethod]
        [DataRow(10000)]
        [DataRow(11234.12)]
        [DataRow(10001)]
        [DataRow(10000.01)]
        public void Deposit_TooLarge_ThrowsArgumentException(double tooLargeDeposit)
        {
            //arrange


            Assert.ThrowsException<ArgumentException>(() => acc.Desposit(tooLargeDeposit));
        }

        [TestMethod()] 
        [DataRow(100)]
        [DataRow(9999.99)]
        [DataRow(.01)]
        public void Deposit_PositiveAmount_AddsTobalance(double initialDeposit)
        {
            //AAA - Arrange Act Assert

            //Arrangew- Creating variables/objects

            const double startBalance = 0;
            

            //Act- Escute method under test
            acc.Desposit(initialDeposit);

            //Asser- Check a condition
            Assert.AreEqual(startBalance + initialDeposit, acc.Balance);
        }

        [TestMethod]
        public void Deposit_PositiveAmount_ReurnsUpdatedBalance()
        {
            //Arange 

            double initialBalance = 0;
            double depositAmount = 10.55;

            //Act - calling the method we are testing
            double newBalance = acc.Desposit(depositAmount);
           
            //Assert
            double expectedBalance = initialBalance + depositAmount;
            Assert.AreEqual(expectedBalance, newBalance);

        }

        [TestMethod]
        public void Deposit_MultipleAmounts_ReturnsAccumulatedBalance()
        {
            //Arrange

            double deposit1 = 10;
            double deposit2 = 25;
            double expecrtedBalance = deposit1 + deposit2;

            //Act
            double intermadiateBalance = acc.Desposit(deposit1);
            double finalBalance = acc.Desposit(deposit2);

            //Assert
            Assert.AreEqual(deposit1, intermadiateBalance);
            Assert.AreEqual(expecrtedBalance, finalBalance);
        }

        [TestMethod]
        public void Deposit_NegativeAmounts_ThrowsArgumentException()
        {
            //Arrange

            double neativeDeposit = -1;

            //Act => Assert

            Assert.ThrowsException<ArgumentException>
                (
                    () => acc.Desposit(neativeDeposit)
                );
        }

        [TestMethod]
        [DataRow(100, 50)]
        [DataRow(50,50)]
        [DataRow(9.99, 9.99)]
        public void Withdraw_PositiveAmount_SubtractsFromBalance(double initialDeposit, double withdrawAmount)
        {

            double expectedBalance = initialDeposit - withdrawAmount;

            acc.Desposit(initialDeposit);
            acc.Withdraw(withdrawAmount);

            Assert.AreEqual(expectedBalance, acc.Balance);
        }

        [TestMethod]
        public void Withdraw_MoreThanBlance_ThrowsArgumentException()
        {
            //double initialBalance = 0;  an account created with the default contructor has 0 balance
            double withdrawAmount = 1000;
            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(withdrawAmount));
        }

        [TestMethod]
        public void Withdraw_NegativeAmount_ThrowsArgumentException()
        {
            Assert.Fail();
        }
    }
}