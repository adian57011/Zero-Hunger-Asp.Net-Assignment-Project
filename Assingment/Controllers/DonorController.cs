using Assingment.Auth;
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
    public class DonorController : Controller
    {
        // GET: Donor
        [Logged]
        public ActionResult Index()
        {
            return View();
        }

        [Logged]
        [HttpGet]
        public ActionResult Donation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Donation(DonationDto obj)
        {
            var db = new ZHContext();

            var donation = new Donation()
            {
                Name = obj.Name,
                Qunatity = obj.Quantity,
                ExpiryDate = obj.ExpiryDate,
                Status = "Pending",
                DonorId = (int) Session["Id"]
            };

            db.Donations.Add(donation);
            db.SaveChanges();

            TempData["msg"] = "Donation Added!";
            return View();

        }

        [Logged]
        public ActionResult History()
        {
            int id = (int)Session["Id"];
            var db = new ZHContext();


            var history = (from h in db.Donations
                           where h.DonorId.Equals(id)
                           select h); // this thing returns iqueryable. eta program e error dei. as ami list pathacchilam.

            var historylist = new List<Donation> (history); // eta iqueryable re list banai fele. jeita ami chai!

            return View(Convert(historylist));
            
            
        }

        public ActionResult Logout()
        {
            Session["Id"] = null;
            Session["Name"] = null;
            Session["Email"] = null;
            return RedirectToAction("Index", "Home");
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


        //database er model k dto model banai
        DonationDto Convert(Donation donation)
        {
            DonationDto d = new DonationDto()
            {
                Id = donation.Id,
                Name = donation.Name,
                Quantity = donation.Qunatity,
                ExpiryDate = donation.ExpiryDate,
                Status = donation.Status,
                DonorId = donation.DonorId

            };

            return d;
        }

        List<DonationDto> Convert(List <Donation> donations)
        {
            var nd = new List<DonationDto>();
            
            foreach (var don in donations)
            {
                var d = Convert(don);
                nd.Add(d);
            }

            return nd;
        }

    }
}