using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models.Extensions
{
    public class RestrictedDate : ValidationAttribute
    {
        public override bool IsValid(object datevv)
        {
            DateTime date = (DateTime)datevv;
            return date < DateTime.Now;
        }
    }
}