using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        public string CentreName { get; set; }

        public string PsychologistName { get; set; }

        public Psychologist Psychologist { get; set; }
        [Display(Name = "Psychologist Name")]
        public int PsychologistId { get; set; }
<<<<<<< HEAD
        
=======

>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        [Required]
        [Display(Name = "Schedule Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ScheduleDate { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }

        public bool IsBooked { get; set; }

        public int PatientId { get; set; }


    }
}