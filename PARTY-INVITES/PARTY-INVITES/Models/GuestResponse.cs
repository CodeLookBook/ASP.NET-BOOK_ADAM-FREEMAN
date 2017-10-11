using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PARTY_INVITES.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Pleas enter your name")]
        public string Name       { get; set; }

        [RegularExpression(".+\\@.+\\..+", 
            ErrorMessage = "Pleas enter your email address")]
        public string Email      { get; set; }

        [Required(ErrorMessage = "Pleas enter your phone number")]
        public string Phone      { get; set; }

        [Required(ErrorMessage = "Please specify whether you'll attend")]
        public bool?  WillAttend { get; set; }
    }
}
