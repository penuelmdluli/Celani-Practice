using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models.Dto
{
    public class PaymentDto
    {
        public int Id { get; set; }

    
        public string PatientName { get; set; }

     
        public string PsychologistName { get; set; }

        [Display(Name = "Payment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PaymentDate { get; set; }

        [Display(Name = "Service Recived")]
        public string ServiceRecived { get; set; }

        [Display(Name = "Hours Of Service")]
        public int HoursOfService { get; set; }

        [Display(Name = "Service Amount (R)")]
        public int ServiceAmount { get; set; }

        [Display(Name = "Paid by Medical Aid (R)")]
        public int PaidbyMedicalAid { get; set; }

        [Display(Name = "Pay by Cash (R)")]
        public int PayByCash { get; set; }

        [Display(Name = "Total Due")]
        public int TotalDue { get; set; }

        [Display(Name = "Invoice Refference")]
        public string InvoiceRefNo { get; set; }
    }
}