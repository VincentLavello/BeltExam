using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // You first may want to unbox "value" here and cast to to a DateTime variable!
        if (value == null) 
        {
            return ValidationResult.Success;

        }
        else 
        {
            DateTime eventDate = (DateTime) value;
            return eventDate >= DateTime.Now ? ValidationResult.Success : new ValidationResult("Event date cannot be in the past");
        }

        // return new ValidationResult( (bool) (eventDate > DateTime.Now) ? "True" : "Date must be future." );

    }

}
