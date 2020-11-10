using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.CollectionViewModels
{
    public class ConsultationCollection
    {
        public Consultation Consultation{ get; set; }
<<<<<<< HEAD

=======
      
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        [DataType(DataType.Upload)]
       public  HttpPostedFileBase ImageUpload { get; set; }

        public IEnumerable<Psychologist> Psychologists { get; set; }

        public IEnumerable<Patient> Patients { get; set; }
<<<<<<< HEAD
=======
        public IEnumerable<Appointment>  Appointments{ get; set; }
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4

    }
}