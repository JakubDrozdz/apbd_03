using Microsoft.AspNetCore.Mvc;

namespace apbd_03;

[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private IAnimalsService _animalsService;
    
    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }

    [HttpGet]
    public IActionResult GetAnimals([FromQuery(Name = "orderBy")] string orderBy = "name")
    {
        if (!AnimalUtils.IsOrderByColumnNameValid(orderBy))
        {
            return BadRequest("Invalid query string");
        }
        var animals = _animalsService.GetAnimals(orderBy);
        return Ok(animals);
    }
}