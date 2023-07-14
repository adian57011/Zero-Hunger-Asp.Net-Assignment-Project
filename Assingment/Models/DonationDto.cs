using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assingment.Models
{
    public class DonationDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [ForeignKey("DonorDto")]
        public int DonorId { get; set; }

        public string Status { get; set; }

        public virtual DonorDto DonorDto { get; set; }

    }
}