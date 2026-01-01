using System.ComponentModel.DataAnnotations;

namespace _5_aspnetcore_model_validations.Models;

public class Person
{
    [Required(ErrorMessage ="person name can't be empty or null")]
    public string? PersonName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Psw { get; set; }
    public string? ConfirmPsw { get; set; }
    public double? Price { get; set; }

    public override string ToString()
    {
        return $"PersonName: {PersonName}, Email: {Email}, Phone: {Phone}, Psw: {Psw}, ConfirmPsw: {ConfirmPsw}, Price: {Price}";
    }
}
