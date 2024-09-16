using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationDemo.CustomValidators
{
    public class GPAValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            double gpa = value != null ? (double)value : -1;
            if (gpa >= 0 && gpa <= 4)
                return ValidationResult.Success;
            return new ValidationResult("GPA values must be between 0 and 4");
        }
    }
}
