using _5_aspnetcore_model_validations.Models;
using Microsoft.AspNetCore.Mvc;

namespace _5_aspnetcore_model_validations.Controllers;

public class HomeController : ControllerBase
{
    [Route("register")]
    public IActionResult Index(
    //[Bind(nameof(Person.PersonName), nameof(Person.Email), nameof(Person.Psw), nameof(Person.ConfirmPsw) ) ] , aspnetcore fa sempre in auto il binding di tutti i fields public, se non vuoi che target fields sia bindato allora su field [BindNever]
    [FromBody]Person person, [FromHeader(Name = "User-Agent")] string UserAgent )
    {  // da body prendi i dati e fai il model binding su person, anche senza scrivere [FromBody] esso è implicito w apicontroller,  da header prendi User-Agent e bindalo su string UserAgent
        if (!ModelState.IsValid) {
            string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
            return BadRequest(errors);
        }
        return Content($"{person}, {UserAgent}");
    }

    [HttpGet("search")]  //è Route+GET, Route da solo non va bene puo rispondere anche a post/put/delete/ect
    public IActionResult Search(
    [FromQuery] string? name,
    [FromQuery] int? minAge,
    [FromQuery] int? maxAge
)
    {
        return Ok(new
        {
            name,
            minAge,
            maxAge
        });
    }
    //GET /search?name=nevil&minAge=16&maxAge=46
    //w [FromQuery] binding auto di name, minAge,maxAge dai query string params

    [HttpGet("person/{id}")]
    public IActionResult GetPerson(
    [FromRoute] int id
)
    {
        return Ok($"Requested person id = {id}");
    }
    //GET /person/42
    //w [FromRoute] binding auto di id dal route url
}
