using Banking.DAL;
using Banking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Banking.Controllers
{
    public class CustomerController : Controller
    {
        private BankingDBContext customerDB = new BankingDBContext();

        // GET: Customer
        public ActionResult Index()
        {
            var customerList = (from a in customerDB.Customer 
                                orderby a.LastName, a.FirstName
                                          select a).Distinct().ToList();

            //List<Customer> customerList = customerDB.Customer.OrderBy(cust => cust.LastName).ThenBy(cust => cust.FirstName).ToList<Customer>();

            return View(customerList);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            //List<Customer> custObjList = customerDB.Customer.Where(cust => cust.ID != id).OrderBy(cust => cust.LastName).ThenBy(cust => cust.FirstName).ToList<Customer>();
            var custObj = (from a in customerDB.Customer
                           where a.ID == id
                           select a).FirstOrDefault();

            // create new Customer obj
            var newCustObj = (from a in customerDB.Customer join b in customerDB.Account on a.ID equals b.CustomerId
                           where a.ID == id
                           select new
                           {
                               a.FirstName,
                               a.LastName,
                               a.MiddleName,
                               b.ID,
                               b.accountType.Name,
                               b.Amount
                           }).ToList();

            return View(custObj);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var custObj = customerDB.Customer.Find(id);
            return View(custObj);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var custObj = customerDB.Customer.Single(cust => cust.ID == id);
                
                if (TryUpdateModel(custObj))
                { 
                    customerDB.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(customerDB.Customer.Single(cust => cust.ID==id));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
