using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models.Dto
{
    public class SchedulesDto
    {
        public int Id { get; set; }

        public string PsychologistName { get; set; }

        public string CentreName { get; set; }

        [Required]
        [Display(Name = "Schedule Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ScheduleDate { get; set; }


        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

     
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }
        public bool IsBooked { get; set; }
        public int PatientId { get; set; }

    }
}
