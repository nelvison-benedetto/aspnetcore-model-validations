using _5_aspnetcore_model_validations.Models;
using Microsoft.AspNetCore.Mvc;

namespace _5_aspnetcore_model_validations.Controllers;

public class HomeController : ControllerBase
{
    [Route("register")]
    public IActionResult Index(Person person) {
        if(!ModelState.IsValid) {
            string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
            return BadRequest(errors);
        }
        return Content($"{person}");
    }

}
