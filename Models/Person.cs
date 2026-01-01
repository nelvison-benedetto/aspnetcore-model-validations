using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace _5_aspnetcore_model_validations.Models;

public class Person
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

    [Range(0, 999, ErrorMessage ="{0} should be between {1} and {2}")]
    public double? Price { get; set; }

    public override string ToString()
    {
        return $"PersonName: {PersonName}, Email: {Email}, Phone: {Phone}, Psw: {Psw}, ConfirmPsw: {ConfirmPsw}, Price: {Price}";
    }
}
