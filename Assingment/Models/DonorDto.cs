using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assingment.Models
{
    public class DonorDto
    {
        
        public int Id { get; set; }
       
        [Required]
        public string Name { get; set; }
       
        [EmailAddress]
        public string Email { get; set; }
       
        [Required]
        public string Address { get; set; }
        
        [Required]
        public string Password { get; set; }


    }
}