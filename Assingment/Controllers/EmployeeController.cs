using Assingment.Auth;
using Assingment.Db;
using Assingment.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assingment.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        [Logged]
        public ActionResult Index()
        {
            int id = (int) Session["Id"];
            var db = new  ZHContext();

            var req = (from r in db.Requests
                       where r.EmployeeId.Equals(id)
                       select r);

            var reqList = new List<Request>(req);


            return View(reqList);
        }

        
    }
}