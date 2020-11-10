using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.CollectionViewModels
{
    public class PaymentCollection
    {
        public Payment  Payment { get; set; }
        public IEnumerable<Patient> Patients { get; set; }
<<<<<<< HEAD
        public IEnumerable<Psychologist> Psychologists { get; set; }
=======
        //public IEnumerable<Psychologist> Psychologists { get; set; }
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
     
    }
}