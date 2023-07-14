using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assingment.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage ="Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Enter Password")]
        public string Password { get; set; }
    }
}