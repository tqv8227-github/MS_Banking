using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banking.Models
{
    public class CustomerAccountInfo_Vw
    {
        public String LastName { get; }
        public String FirstName { get; }
        public String MiddleIntial { get; }
        public String Sex { get; }
        public int Amount { get; }
        public String AccountType {get;}
        public int AccountNumber { get; }
        public int CustomerId { get; }

    }
}