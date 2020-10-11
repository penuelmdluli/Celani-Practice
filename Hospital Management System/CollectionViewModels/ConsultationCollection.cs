using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.CollectionViewModels
{
    public class ConsultationCollection
    {
        public Consultation Consultation{ get; set; }
        public IEnumerable<Psychologist> Psychologists { get; set; }
        public IEnumerable<Patient> Patients { get; set; }

    }
}