using _5_aspnetcore_model_validations.CustomValidators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding; //x binding
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace _5_aspnetcore_model_validations.Models;

public class Person : IValidatableObject
{
    [Required(ErrorMessage ="person name can't be empty or null")]
    [Display(Name ="Person Name")]
    [StringLength(40,MinimumLength =3, ErrorMessage ="{0} should be between {2 and {1} chars long")]
    [RegularExpression("^[A-Za-z .]$", ErrorMessage="{0} should contain only alphabets space and dot (.)")]
    public string? PersonName { get; set; }

    [EmailAddress(ErrorMessage ="{0} should be a proper email address")]
    public string? Email { get; set; }

    [Phone(ErrorMessage ="{0} should contain 10 digits.")]
    //[ValidateNever]
    public string? Phone { get; set; }

    [Required(ErrorMessage ="{0} can't be blank")]
    public string? Psw { get; set; }

    [Required(ErrorMessage = "{0} can't be blank")]
    [Compare("Psw", ErrorMessage ="{0} and {1} don't match")]
    [Display(Name ="re-enter psw")]
    public string? ConfirmPsw { get; set; }

    [Range(0, 999.99, ErrorMessage ="{0} should be between {1} and {2}")]
    public double? Price { get; set; }


    [MinimumYearValidator(2005)]  //here i'm using my custom validator!!! here run default error mex
    [BindNever]  // this will prevent binding this property from request data
    public DateTime? DateOfBirth { get; set; }

    public DateTime? FromDate { get; set; }

    [DateRangeValidator("FromDate", ErrorMessage="'from date' should be older than or equal to 'to date'")]
    public DateTime? ToDate { get; set; }

    public int? Age { get; set; }

    public override string ToString()
    {
        return $"PersonName: {PersonName}, Email: {Email}, Phone: {Phone}, Psw: {Psw}, ConfirmPsw: {ConfirmPsw}, Price: {Price}";
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (DateOfBirth.HasValue == false && Age.HasValue == false) {
            yield return new ValidationResult("either of date of birth or age must be supplied", new[] { nameof(Age) });
        }
    }
}
