using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assingment.Db.Models
{
    public class Donor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }

        public Donor()
        {
            Donations = new List<Donation>();
        }
    }
}