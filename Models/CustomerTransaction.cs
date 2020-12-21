using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banking.Models
{
    public class CustomerTransaction
    {
        public int ID { get; set; }
        public int TransactionTypeId { get; set; }
        public int BankerId { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public Banker Banker { get; set; }

        public TransactionType TransactionType { get; set; }
        public int Amount { get; set; }
    }
}