using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Banking.DAL;
using Banking.Models;

namespace Banking.Controllers
{
    public class CustomerTransactionController : Controller
    {
        private BankingDBContext db = new BankingDBContext();

        // GET: CustomerTransactions
        public ActionResult Index()
        {
            List<CustomerTransaction> transactionList = db.CustomerTransaction.Include(a => a.Banker).Include(c => c.Account).Include(t=>t.TransactionType).ToList<CustomerTransaction>();
            return View(transactionList);
        }

        // GET: CustomerTransactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerTransaction customerTransaction = db.CustomerTransaction.Find(id);
            if (customerTransaction == null)
            {
                return HttpNotFound();
            }
            return View(customerTransaction);
        }

        // GET: CustomerTransactions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TransactionTypeId,BankerId,AccountId,Amount")] CustomerTransaction customerTransaction)
        {
            if (ModelState.IsValid)
            {
                db.CustomerTransaction.Add(customerTransaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerTransaction);
        }

        // GET: CustomerTransactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerTransaction customerTransaction = db.CustomerTransaction.Find(id);
            if (customerTransaction == null)
            {
                return HttpNotFound();
            }
            return View(customerTransaction);
        }

        // POST: CustomerTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TransactionTypeId,BankerId,AccountId,Amount")] CustomerTransaction customerTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerTransaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerTransaction);
        }

        // GET: CustomerTransactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerTransaction customerTransaction = db.CustomerTransaction.Find(id);
            if (customerTransaction == null)
            {
                return HttpNotFound();
            }
            return View(customerTransaction);
        }

        // POST: CustomerTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerTransaction customerTransaction = db.CustomerTransaction.Find(id);
            db.CustomerTransaction.Remove(customerTransaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
