using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId ==  MembershipType.PayAsYouGo || customer.MembershipTypeId == MembershipType.Unknown)
            {
                return ValidationResult.Success;
            }
            if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate required.");
            }

            var ageCalculate = DateTime.Today.Year - customer.Birthdate.Value.Year;

            if (ageCalculate <= 18)
            {
                return new ValidationResult("Need to have at least 18 years to enter.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}