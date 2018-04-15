using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = @"Pleas enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = @"Pleas enter valid email adress.")]
        public string Email { get; set; }

        [Required(ErrorMessage = @"Pleas enter your phone.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = @"Pleas specify whether you will attend.")]
        public bool? WillAttend { get; set; }

    }
}
