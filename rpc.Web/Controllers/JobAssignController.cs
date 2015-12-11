using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rpc.Web.Controllers
{
    public class JobAssignController : Controller
    {
        private RPC_DBEntities db = new RPC_DBEntities();
        // GET: JobAssign
        public ActionResult Index()
        {
            return View();
        }





    }
}