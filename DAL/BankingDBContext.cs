using Banking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Banking.DAL
{
    public class BankingDBContext : DbContext
    {
        private static string connString = "name=BankConnStr";

        public BankingDBContext() : base(connString)
        {
            //Database.SetInitializer<CustomerDBContext>(null);
            
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Banker> Banker { get; set; }
        public DbSet<BankerType> BankerType { get; set; }

        public DbSet<CustomerTransaction> CustomerTransaction { get; set; }

        public DbSet<TransactionType> TransactionType { get; set; }

        //public DbSet<CustomerAccountInfo_Vw> CustomerAccountInfo_Vw { get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // configures one-to-many relationship
            /*modelBuilder.Entity<Account>()
                .HasRequired<AccountType>(a => a.accountType)
                .WithMany(g => g.Account)
                .HasForeignKey<int>(s => s.AccountTypeId);*/
        }
    }
}