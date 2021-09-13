using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Banking.BLL;
using Banking.DAL;
using Banking.Models;

namespace Banking.Controllers
{
    public class BankerController : Controller
    {
        private BankingDBContext db = new BankingDBContext();
        private BankerService service = new BankerService();

        // GET: Bankers
        public ActionResult Index()
        {
            List<Banker> bankerList = db.Banker.Include(banker => banker.BankerType).ToList();
            return View(bankerList);
        }

        // GET: Bankers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Banker banker = db.Banker.Find(id);
            Banker banker = db.Banker.Include(a => a.BankerType).Where(a => a.ID == id).SingleOrDefault();

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

            //Banker banker = db.Banker.Include(a=>a.BankerType).Where(a => a.ID == id).FirstOrDefault();//.Include(b => b.BankerType);//.Find(id);
            /*Banker banker = db.Banker.Find(id);
            List<BankerType> bankerTypeList = db.BankerType.ToList<BankerType>();

            if (banker == null)
            {
                return HttpNotFound();
            }

            ViewBag.BankerTypeList = bankerTypeList;
            BankerView bankerView = new BankerView() { Banker = banker, BankerTypeList =bankerTypeList };*/
            BankerView bankerView = service.getBankerView(id);
            return View(bankerView);
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
