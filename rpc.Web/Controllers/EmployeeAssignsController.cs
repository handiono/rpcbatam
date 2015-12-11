using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using rpc.Web;

namespace rpc.Web.Controllers
{
    public class EmployeeAssignsController : Controller
    {
        private RPC_DBEntities db = new RPC_DBEntities();

        // GET: EmployeeAssigns
        public ActionResult Index()
        {
            var employeeAssigns = db.EmployeeAssigns.Include(e => e.Employee);
            return View(employeeAssigns.ToList());
        }

        // GET: EmployeeAssigns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAssign employeeAssign = db.EmployeeAssigns.Find(id);
            if (employeeAssign == null)
            {
                return HttpNotFound();
            }
            return View(employeeAssign);
        }

        // GET: EmployeeAssigns/Create
        public ActionResult Create(string employeeid)
        {
         

            var selectemp = (from a in db.Employees
                             where a.Manager != "1"
                             select new { a.EmployeeID ,oprname = a.EmployeeID + "-" + a.Name });
            ViewBag.EmployeeID = new SelectList(selectemp.ToList(), "EmployeeID", "oprname");



            var selectleader = (from r in db.Employees
                                where r.Manager == "1"
                                select new { r.EmployeeID , leader= r.EmployeeID + "-" + r.Name });
            ViewBag.Leader = new SelectList( selectleader.ToList(),"EmployeeID","leader");


        

            return View();
        }

        // POST: EmployeeAssigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,EmployeeName,Leader,StartDate,EndDate")] EmployeeAssign employeeAssign)
        {

            if (ModelState.IsValid)
            {
                db.EmployeeAssigns.Add(employeeAssign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeID", employeeAssign.EmployeeID);
            ViewBag.Leader = new SelectList(db.Employees, "EmployeeID", "EmployeeID", employeeAssign.Leader);

        
           
            return View(employeeAssign);
        }

        // GET: EmployeeAssigns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAssign employeeAssign = db.EmployeeAssigns.Find(id);
            if (employeeAssign == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeID", employeeAssign.EmployeeID);
            return View(employeeAssign);
        }

        // POST: EmployeeAssigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeAssignID,EmployeeID,Leader,StartDate,EndDate")] EmployeeAssign employeeAssign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeAssign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeID", employeeAssign.EmployeeID);
            return View(employeeAssign);
        }

        // GET: EmployeeAssigns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAssign employeeAssign = db.EmployeeAssigns.Find(id);
            if (employeeAssign == null)
            {
                return HttpNotFound();
            }
            return View(employeeAssign);
        }

        // POST: EmployeeAssigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeAssign employeeAssign = db.EmployeeAssigns.Find(id);
            db.EmployeeAssigns.Remove(employeeAssign);
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
