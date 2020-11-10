using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    public class Centre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
<<<<<<< HEAD
=======
        [StringLength(10, ErrorMessage = "Mobile No: length can't be more than 10.")]
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        public string Contact { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }
    }
}