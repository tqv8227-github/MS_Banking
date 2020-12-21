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
    public class BankerController : Controller
    {
        private BankingDBContext db = new BankingDBContext();

        // GET: Bankers
        public ActionResult Index()
        {
            return View(db.Banker.ToList());
        }

        // GET: Bankers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banker banker = db.Banker.Find(id);
            if (banker == null)
            {
                return HttpNotFound();
            }
            return View(banker);
        }

        // GET: Bankers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bankers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,BankerTypeId")] Banker banker)
        {
            if (ModelState.IsValid)
            {
                db.Banker.Add(banker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banker);
        }

        // GET: Bankers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banker banker = db.Banker.Find(id);
            if (banker == null)
            {
                return HttpNotFound();
            }
            return View(banker);
        }

        // POST: Bankers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,BankerTypeId")] Banker banker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banker);
        }

        // GET: Bankers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banker banker = db.Banker.Find(id);
            if (banker == null)
            {
                return HttpNotFound();
            }
            return View(banker);
        }

        // POST: Bankers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Banker banker = db.Banker.Find(id);
            db.Banker.Remove(banker);
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
