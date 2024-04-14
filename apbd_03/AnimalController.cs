using Microsoft.AspNetCore.Mvc;

namespace apbd_03;

[Route("api/students")]
[ApiController]
public class AnimalController : ControllerBase
{
    [HttpGet]
    public IActionResult GetStudents()
    {
        return Ok();
    }
}