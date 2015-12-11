using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using rpc.Web;

namespace rpc.Web.Controllers
{
    public class ManHourController : Controller
    {
        private RPC_DBEntities db = new RPC_DBEntities();

        // GET: ManHour
        public ActionResult Index()
        {
            var manHour = db.ManHours.Include(e => e.Employee);
            return View(manHour.ToList());

        }


        public ActionResult Create(string date)
        {
            var selectwork = (from a in db.JobAssigns
                                where a.LeaderID == "E001"
                                select new { a.WorkID, id = a.WorkID });
            ViewBag.WorkID = new SelectList(selectwork.ToList(), "WorkID", "id");


            var selectemp = (from b in db.Employees
                             where b.Manager == "E001"
                             select new { b.EmployeeID, id = b.EmployeeID });
            ViewBag.EmployeeID = new SelectList(selectemp.ToList(), "EmployeeID", "id");

            return View();
        }
        
        [HttpPost]
        public ActionResult Create([Bind(Include="Date,WorkID,EmployeeID,ManHours")] ManHour manhour)
        {
            if (ModelState.IsValid)
            {
                db.ManHours.Add(manhour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
                     
        }

       
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManHour manhour = db.ManHours.Find(id);
            if (manhour == null)
            {
                return HttpNotFound();
            }
            var selectwork = (from a in db.JobAssigns
                              where a.LeaderID == "E001"
                              select new { a.WorkID, id = a.WorkID });
            ViewBag.WorkID = new SelectList(selectwork.ToList(), "WorkID", "id");


            var selectemp = (from b in db.Employees
                             where b.Manager == "E001"
                             select new { b.EmployeeID, id = b.EmployeeID });
            ViewBag.EmployeeID = new SelectList(selectemp.ToList(), "EmployeeID", "id");

            return View(manhour);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Date,WorkID,EmployeeID,ManHours")] ManHour manhour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manhour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(manhour);
        }


        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}