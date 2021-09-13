using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banking.Models
{
    public class BankerView
    {
        public BankerView() { }
        public Banker Banker { get; set; }
        public List<BankerType> BankerTypeList { get; set; }
    }
}