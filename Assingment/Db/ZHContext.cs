using Assingment.Db.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assingment.Db
{
    public class ZHContext:DbContext
    {
        public DbSet <Admin> Admins { get; set; }
        public DbSet <Donor> Donors { get; set; }
        public DbSet <Employee> Employees { get; set; }
        public DbSet <Donation> Donations { get; set; }
        public DbSet <Request> Requests { get; set; }
    }
}