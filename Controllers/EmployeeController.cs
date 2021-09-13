using Banking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Banking.Controllers
{
    public class EmployeeController : Controller
    {
        public static List<Employee_bak> empList = new List<Employee_bak>{
                   new Employee_bak{
                      ID = 1,
                      Name = "William",
                      JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                      Age = 23
                   },

                   new Employee_bak{
                      ID = 2,
                      Name = "Carson",
                      JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                      Age = 45
                   },

                   new Employee_bak{
                      ID = 3,
                      Name = "Carson",
                      JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                      Age = 37
                   },

                   new Employee_bak{
                      ID = 4,
                      Name = "Laura",
                      JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                      Age = 26
                   }
        };

        [NonAction]
        public List<Employee_bak> getEmplist2()
        {
            List<Employee_bak> empListLocal = new List<Employee_bak>();
            foreach (Employee_bak e in empList)
            {
                empListLocal.Add(e);
            }

            return empListLocal;
        }

        // GET: Employee
        public ActionResult Index()
        {
            var employees = from e in empList//GetEmployeeList()
                            orderby e.ID
                            select e;

            //return View(employees);
            return View(this.getEmplist2().OrderBy(a => a.Age));
        }

        // DELETE: Employee
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            Employee_bak currEmp = empList.Single(emp => emp.ID == id);

            empList.Remove(currEmp);
            return RedirectToAction("Index");
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View(empList.Single(emp => emp.ID == id));
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Employee_bak newEmp = new Employee_bak();
                int newId = 1;
                
                if (empList.Count > 0)
                {
                    newId = empList.Select(a => a.ID).Max()+1;
                }

                newEmp.ID = newId;
                newEmp.Age = int.Parse(collection["Age"]);

                DateTime jDate;
                DateTime.TryParse(collection["JoiningDate"], out jDate);
                newEmp.JoiningDate = jDate;
                newEmp.Name = collection["Name"];

                empList.Add(newEmp);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        //GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
           return View(empList.Single(m => m.ID == id));
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var employee = empList.Single(m => m.ID == id);
                if (TryUpdateModel(employee))
                {
                    //To Do:- database code
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch
            {
                return View();
            }
        }

        [NonAction]
        public List<Employee_bak> GetEmployeeList()
        {
            return new List<Employee_bak>
            {
              new Employee_bak{
                 ID = 1,
                 Name = "Allan",
                 JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                 Age = 23
              },

              new Employee_bak{
                 ID = 2,
                 Name = "Carson",
                 JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                 Age = 45
              },

              new Employee_bak{
                 ID = 3,
                 Name = "Carson",
                 JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                 Age = 37
              },

              new Employee_bak{
                 ID = 4,
                 Name = "Laura",
                 JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                 Age = 26
              },
            };
        }
    }
}