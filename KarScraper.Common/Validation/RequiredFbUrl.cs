using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbScraper.Common.Validation
{

    public class RequiredFbUrl : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value.ToString().Contains("https://www.facebook.com/"))
                return ValidationResult.Success;
            else
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}
