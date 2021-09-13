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
    public class TransactionTypesController : Controller
    {
        private BankingDBContext db = new BankingDBContext();

        // GET: TransactionTypes
        public ActionResult Index()
        {
            return View(db.TransactionType.ToList());
        }

        // GET: TransactionTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionType transactionType = db.TransactionType.Find(id);
            if (transactionType == null)
            {
                return HttpNotFound();
            }
            return View(transactionType);
        }

        // GET: TransactionTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] TransactionType transactionType)
        {
            if (ModelState.IsValid)
            {
                db.TransactionType.Add(transactionType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transactionType);
        }

        // GET: TransactionTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionType transactionType = db.TransactionType.Find(id);
            if (transactionType == null)
            {
                return HttpNotFound();
            }
            return View(transactionType);
        }

        // POST: TransactionTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] TransactionType transactionType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transactionType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transactionType);
        }

        // GET: TransactionTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionType transactionType = db.TransactionType.Find(id);
            if (transactionType == null)
            {
                return HttpNotFound();
            }
            return View(transactionType);
        }

        // POST: TransactionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransactionType transactionType = db.TransactionType.Find(id);
            db.TransactionType.Remove(transactionType);
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
