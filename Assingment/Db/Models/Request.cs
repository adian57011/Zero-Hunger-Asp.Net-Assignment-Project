using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assingment.Db.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string Status { get; set; }

        [ForeignKey("Donor")]
        public int DonorId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public virtual Donor Donor { get; set; }
        public virtual Employee Employee { get; set; }

    }
}