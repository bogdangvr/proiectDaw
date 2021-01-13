using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace fantasyF1.CustomValidation
{
    public class DateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime DateComment = Convert.ToDateTime(value);
            return DateComment <= DateTime.Now;
        }
    }
}