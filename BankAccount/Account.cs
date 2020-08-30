﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Resprents a single bank account
    /// </summary>
    public class Account
    {

        /// <summary>
        /// Deposits the amount in the bank account and returns the new balance
        /// </summary>
        /// <param name="amt">The amount to deposit</param>
        public double Desposit(double amt)
        {
            if(amt >= 10000)
            {
                throw new ArgumentException($"{nameof(amt)} must be smaller than 10000");
            }
            if (amt <= 0)
            {
                throw new ArgumentException($"{nameof(amt)} amount must be a positive value");
                
            }
            Balance += amt;
            return Balance;
        }

        public void Withdraw(double amt)
        {
            if(amt > Balance)
            {
                throw new ArgumentException("You cannot withdraw more than the balance");
            }
            Balance -= amt;
        }

        public double Balance { get; private set; }
    }
}
