using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rpc.Web.Models;

namespace rpc.Web.Controllers
{
    public class Report1Controller : Controller
    {
        private RPC_DBEntities db = new RPC_DBEntities();
        // GET: Report1
        public ActionResult Index(string JobID , string WorkID ,string date, string date2 ,string LeaderID )
         {

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "All", Value = "all" });

            var selectjob = (from a in db.Jobs
                            select a);
            
          
             foreach ( var lead in selectjob)
             {
                 items.Add(new SelectListItem { Text = lead.JobID + "-" + lead.JobName, Value = lead.JobID });
             }
  
            ViewBag.JobID = items;



            List<SelectListItem> leader = new List<SelectListItem>();
            leader.Add(new SelectListItem { Text = "All", Value = "all" });
            var selectleader = (from b in db.Employees
                               where b.Manager == "1"
                               select b);

            foreach (var leaders in selectleader)
            {
                leader.Add(new SelectListItem { Text = leaders.EmployeeID + "-" + leaders.Name, Value = leaders.EmployeeID });
            }
            ViewBag.LeaderID = leader;



        
        if (JobID!="all" && WorkID!=null && date!=null && date2!=null && LeaderID!="all")            
        {

           return RedirectToAction("Report", new { JobID = JobID, WorkID = WorkID, LeaderID = LeaderID, date = date, date2 = date2 });

        }

        else if (JobID != "all" && WorkID != null && date != null && date2 != null && LeaderID == "all")
        {
            return RedirectToAction("Report", new { JobID = JobID, WorkID = WorkID, date = date, date2 = date2 });
        }

        else if(JobID=="all" && LeaderID=="all" && WorkID=="" && date!=null && date2!=null)
        {
            return RedirectToAction("Report", new { date = date , date2=date2 });
           

        }
        return View();
        

        
        }


        public ActionResult Report(string JobID, string WorkID, string date, string date2, string LeaderID)
        {
            
          if ( JobID!="all" && WorkID!=null && date!=null && date2!=null && LeaderID!="all")
            {
                string query = "select Works.JobID  ,ManHours.WorkID ,ManHours.EmployeeID , Employees.Name ,ManHours.Date , ManHours.ManHours , ManHours.LeaderID , A.LeaderName   from Works JOIN ManHours ON Works.WorkID = ManHours.WorkID JOIN Employees ON ManHours.EmployeeID= Employees.EmployeeID JOIN(select Employees.EmployeeID as LeaderID, Employees.Name as LeaderName FROM Employees where Manager='1') AS A ON ManHours.LeaderID= A.LeaderID  WHERE  Works.JobID='" + JobID + "' AND Works.WorkID='" + WorkID + "' AND ManHours.Date between '" + date + "' AND '" + date2 + "' AND ManHours.LeaderID='"+ LeaderID+"' ";
                IEnumerable<Report1> result = db.Database.SqlQuery<Report1>(query);
                ViewBag.query = result.ToList();
            }

            else if (JobID != "all" && WorkID != null && date != null && date2 != null && LeaderID == "all")
            {
                string query = "select Works.JobID  ,ManHours.WorkID ,ManHours.EmployeeID , Employees.Name ,ManHours.Date , ManHours.ManHours , ManHours.LeaderID , A.LeaderName   from Works JOIN ManHours ON Works.WorkID = ManHours.WorkID JOIN Employees ON ManHours.EmployeeID= Employees.EmployeeID JOIN(select Employees.EmployeeID as LeaderID, Employees.Name as LeaderName FROM Employees where Manager='1') AS A ON ManHours.LeaderID= A.LeaderID  WHERE  Works.JobID='" + JobID + "' AND Works.WorkID='" + WorkID + "' AND ManHours.Date between '" + date + "' AND '" + date2 + "'";
                IEnumerable<Report1> result = db.Database.SqlQuery<Report1>(query);
                ViewBag.query = result.ToList();
            }
            else if (JobID=="all" && LeaderID=="all" && WorkID=="" && date!=null && date2!=null)
            {
                string query = "select Works.JobID  ,ManHours.WorkID ,ManHours.EmployeeID , Employees.Name ,ManHours.Date , ManHours.ManHours , ManHours.LeaderID , A.LeaderName   from Works JOIN ManHours ON Works.WorkID = ManHours.WorkID JOIN Employees ON ManHours.EmployeeID= Employees.EmployeeID JOIN(select Employees.EmployeeID as LeaderID, Employees.Name as LeaderName FROM Employees where Manager='1') AS A ON ManHours.LeaderID= A.LeaderID  WHERE  ManHours.Date between '" + date + "' AND '" + date2 + "'";
                IEnumerable<Report1> result = db.Database.SqlQuery<Report1>(query);
                ViewBag.query = result.ToList();
            }

            else
            {
                string query = "select Works.JobID  ,ManHours.WorkID ,ManHours.EmployeeID , Employees.Name ,ManHours.Date , ManHours.ManHours , ManHours.LeaderID , A.LeaderName   from Works JOIN ManHours ON Works.WorkID = ManHours.WorkID JOIN Employees ON ManHours.EmployeeID= Employees.EmployeeID JOIN(select Employees.EmployeeID as LeaderID, Employees.Name as LeaderName FROM Employees where Manager='1') AS A ON ManHours.LeaderID= A.LeaderID ";
                IEnumerable<Report1> result = db.Database.SqlQuery<Report1>(query);
                ViewBag.query = result.ToList();
            }


           return PartialView();
            
        }
        
         public JsonResult getWork(string JobID)
        {
           


            var work = from a in db.Works
                       where a.JobID == JobID
                       select a.WorkID;

            return Json( work , JsonRequestBehavior.AllowGet);
        }



        
    }
}