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
    public class BankerTypesController : Controller
    {
        private BankingDBContext db = new BankingDBContext();

        // GET: BankerTypes
        public ActionResult Index()
        {
            return View(db.BankerType.ToList());
        }

        // GET: BankerTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankerType bankerType = db.BankerType.Find(id);
            if (bankerType == null)
            {
                return HttpNotFound();
            }
            return View(bankerType);
        }

        // GET: BankerTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankerTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] BankerType bankerType)
        {
            if (ModelState.IsValid)
            {
                db.BankerType.Add(bankerType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bankerType);
        }

        // GET: BankerTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankerType bankerType = db.BankerType.Find(id);
            if (bankerType == null)
            {
                return HttpNotFound();
            }
            return View(bankerType);
        }

        // POST: BankerTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] BankerType bankerType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankerType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bankerType);
        }

        // GET: BankerTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankerType bankerType = db.BankerType.Find(id);
            if (bankerType == null)
            {
                return HttpNotFound();
            }
            return View(bankerType);
        }

        // POST: BankerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BankerType bankerType = db.BankerType.Find(id);
            db.BankerType.Remove(bankerType);
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
