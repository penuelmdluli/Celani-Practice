﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        [EmailAddress]
        [Display(Name = "Email Id")]
        public string EmailAddress { get; set; }

        [Display(Name = "Phone No")]
        [StringLength(10, ErrorMessage = "Mobile No: length can't be more than 10.")]
        public string PhoneNo { get; set; }

        [StringLength(10, ErrorMessage = " No: length can't be more than 10.")]

        public string Contact { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Level Of Education")]
        public string LevelOfEducation { get; set; }

        [Display(Name = "Language")]
        public string Language { get; set; }

        public string Gender { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Profile Picture")]
        public string Image { get; set; }

        public string Address { get; set; }
        [Display(Name = "Marital Status ")]
        public string MaritalStatus { get; set; }
        public int BookedPsychologistId { get; set; }
        public bool CompletedStatus { get; set; }

        public bool AppointmentStatus { get; set; }

        public bool IsConsulted { get; set; }
        public bool IsPaid { get; set; }

    }
}