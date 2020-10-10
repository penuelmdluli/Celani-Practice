using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Hospital_Management_System.Models.Dto
{
    public class AppointmentDto
    {
        public int Id { get; set; }

        public string PatientName { get; set; }
        public string PsychologistName { get; set; }
      
        [Display(Name = "Appointment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AppointmentDate { get; set; }

        public string Problem { get; set; }

        [Display(Name = "Aprove Appointment")]
        public bool Status { get; set; }

    }
}