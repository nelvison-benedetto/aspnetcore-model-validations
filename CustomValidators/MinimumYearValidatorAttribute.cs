using System.ComponentModel.DataAnnotations;

namespace _5_aspnetcore_model_validations.CustomValidators;

public class MinimumYearValidatorAttribute : ValidationAttribute
{
    public int MinimumYear { get; set; } = 2000;
    public string DefaultErrorMessage = "The year must be at least {0}";
    public MinimumYearValidatorAttribute()  //prameterless ctor
    {
        
    }
    public MinimumYearValidatorAttribute(int minimumYear)
    {
        MinimumYear = minimumYear;
    }


    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null) {
            DateTime date = (DateTime)value;
            if (date.Year >= MinimumYear)
            {
                return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYear));
            }
            else { 
                return ValidationResult.Success;
            }
        }
        return null;
    }

}
