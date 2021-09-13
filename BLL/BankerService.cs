using Banking.DAL;
using Banking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banking.BLL
{
    public class BankerService
    {
        private BankingDBContext context = new BankingDBContext();
        public Banker Banker { get; set; }
        public List<BankerType> BankerTypeList { get; set; }

        public BankerView getBankerView(int? id)
        {
            try
            {
                Banker banker = context.Banker.Where(a => a.ID == id).FirstOrDefault();
                if (banker == null)
                {
                    return null;
                }

                List<BankerType> bankerTypeList = context.BankerType.ToList<BankerType>();
                if (bankerTypeList == null)
                {
                    return null;
                }

                BankerView bankerView = new BankerView() { Banker = banker, BankerTypeList = bankerTypeList };
                return bankerView;

            } catch(Exception e)
            {
                throw (e);
            }
        }
        /////////////////////////////////////////////////////////////
        public List<Banker> getBankerByLastName(string lastName)
        {
            return context.Banker.Where(a => a.LastName.Contains(lastName)).ToList<Banker>();
        }
        /////////////////////////////////////////////////////////////
        public List<Banker> getBankerByFirstName(string firstName)
        {
            return context.Banker.Where(a => a.FirstName.Contains(firstName)).ToList<Banker>();
        }
    }
}