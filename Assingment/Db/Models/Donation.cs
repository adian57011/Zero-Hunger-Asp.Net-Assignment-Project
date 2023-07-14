using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assingment.Db.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qunatity { get; set; }
        public DateTime ExpiryDate { get; set; }

        public string Status { get; set; }

        [ForeignKey("Donor")]
        public int DonorId { get; set; }

        public virtual Donor Donor { get; set; }
    }
}