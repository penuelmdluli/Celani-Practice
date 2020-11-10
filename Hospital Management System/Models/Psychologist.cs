using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    public class Psychologist
    {
        public int Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

        public string FullName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public Centre Centre { get; set; }
        [Display(Name = "Centre")]
        public int DepartmentId { get; set; }

        public string Address { get; set; }
<<<<<<< HEAD

        [Phone]
        [Display(Name = "Phone No")]
        public string PhoneNo { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Mobile No")]
=======
        [Display(Name = "Phone No")]
        [StringLength(10, ErrorMessage = "Phone No: length can't be more than 10.")]
        public string PhoneNo { get; set; }

        [Required]
        [Display(Name = "Mobile No")]
        [StringLength(10, ErrorMessage = "Mobile No: length can't be more than 10.")]
        
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        public string ContactNo { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        public string Gender { get; set; }

<<<<<<< HEAD
        [Required]
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
=======
       
        
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
       [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
       
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Education/Degree")]
        public string Education { get; set; }

        [Required]
        public string Status { get; set; }

    }
}