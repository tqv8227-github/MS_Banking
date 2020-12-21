using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banking.Models
{
    public class Account
    {
        public int ID { get; set; }
        public int AccountTypeId { get; set; }
        public AccountType accountType { get; set; }

        public int Amount { get; set; }

        public int CustomerId { get; set; }
        public Customer customer { get; set; }


    }
}