using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rpc.Web.Controllers
{
    public class Report1Controller : Controller
    {
        private RPC_DBEntities db = new RPC_DBEntities();
        // GET: Report1
        public ActionResult Index()
        {
            //string query = "select Jobs.JobID  ,ManHours.WorkID  ,ManHours.EmployeeID , Employees.Name , ManHours.Date , ManHours.ManHours, EmployeeAssigns.Leader from Jobs JOIN Works  ON Jobs.JobID= Works.JobID JOIN ManHours ON Works.WorkID = ManHours.WorkID JOIN Employees ON ManHours.EmployeeID= Employees.EmployeeID  JOIN EmployeeAssigns ON Employees.EmployeeID=EmployeeAssigns.EmployeeID";
            
            return View();
        }

        
    }
}