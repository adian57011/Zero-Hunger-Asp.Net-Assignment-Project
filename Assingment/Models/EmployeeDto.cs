using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assingment.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Enter Name")]
        public string Name { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        
        [Required(ErrorMessage ="Enter Password")]
        public string Password { get; set; }
    }
}