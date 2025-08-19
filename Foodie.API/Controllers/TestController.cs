using Microsoft.AspNetCore.Mvc;

namespace Foodie.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get()
    {
        return Ok("Foodie API is running! 🍕");
    }

    [HttpGet("health")]
    public ActionResult<string> Health()
    {
        return Ok("Healthy! ✅");
    }
}
