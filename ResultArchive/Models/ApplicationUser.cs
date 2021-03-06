using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResultArchive.Models
{
    //this class was created to add other attributes not in identity
    public class ApplicationUser : IdentityUser
    {  
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string OtherNames { get; set; }

        public string ProfilePicture { get; set; }

        [NotMapped]
        public bool IsSuperAdmin { get; set; }
    }
}
