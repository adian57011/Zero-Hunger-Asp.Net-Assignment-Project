using Assingment.Db;
using Assingment.Db.Models;
using Assingment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assingment.Controllers
{
    public class HomeController : Controller
    {
       public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(DonorDto donor)
        {
            var db = new ZHContext();

            if(ModelState.IsValid)
            {
                db.Donors.Add(Convert(donor));
                db.SaveChanges();
                TempData["msg"] = "User Added!";
                return RedirectToAction("Login", "Home");
            }

            else
            {
                TempData["msg"] = "Signup failed";
                return View();
            }

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDto obj)
        {
            var db = new ZHContext();

            var donor = (from u in db.Donors
                        where u.Email.Equals(obj.Email) &&
                        u.Password.Equals(obj.Password)
                        select u).SingleOrDefault();

            var admin = (from u in db.Admins
                         where u.Email.Equals(obj.Email) &&
                         u.Password.Equals(obj.Password)
                         select u).SingleOrDefault();

            var employee = (from u in db.Employees
                         where u.Email.Equals(obj.Email) &&
                         u.Password.Equals(obj.Password)
                         select u).SingleOrDefault();

            if (donor != null)
            {
                Session["Id"] = donor.Id;
                Session["Name"] = donor.Name;
                Session["Email"] = donor.Email;
                return RedirectToAction("Index", "Donor");
            }


            else if (admin != null)
            {
                Session["Id"] = admin.Id;
                Session["Email"] = admin.Email;
                return RedirectToAction("Index", "Admin");
            }

            else if (employee != null)
            {
                Session["Id"] = employee.Id;
                Session["Email"] = employee.Email;
                return RedirectToAction("Index", "Employee");
            }

            else
            {
                TempData["msg"] = "Login Failed!";
                return View(obj);
            }




            
        }


        DonorDto Convert(Donor donor)
        {
            var dono = new DonorDto()
            {
                Name = donor.Name,
                Email = donor.Email,
                Address = donor.Address,
                Password = donor.Password
            };

            return dono;
        }

        Donor Convert(DonorDto donor)
        {
            var dono = new Donor()
            {
                Name = donor.Name,
                Email = donor.Email,
                Address = donor.Address,
                Password = donor.Password
            };

            return dono;

        }
    }
}