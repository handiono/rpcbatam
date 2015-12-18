using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rpc.Web.Models
{
    public class Report1
    {


        public string JobID { get; set; }
        public string WorkID { get; set; }
        public string EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int ManHours { get; set; }
        public string LeaderID { get; set; }
        public string LeaderName { get; set; }
    }

}