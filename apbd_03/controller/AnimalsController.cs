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
    
    [HttpPost]
    public IActionResult CreateAnimal(AnimalModel animal)
    {
        int createdAnimalId = _animalsService.CreateAnimal(animal);
        Animal createdAniaml = new Animal(animal, createdAnimalId);
        return Created("api/animals/" + createdAnimalId, createdAniaml);
    }
    
    [HttpPut("{idAnimal:int}")]
    public IActionResult UpdateAnimal(int idAnimal, AnimalModel animalModel)
    {
        var updatedObjects = _animalsService.UpdateAnimal(idAnimal, animalModel);
        return NoContent();
    }
    
    [HttpDelete("{idAnimal:int}")]
    public IActionResult DeleteAnimal(int idAnimal)
    {
        var updatedObjects = _animalsService.DeleteAnimal(idAnimal);
        return NoContent();
    }
}