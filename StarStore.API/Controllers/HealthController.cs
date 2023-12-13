using Microsoft.AspNetCore.Mvc;

namespace StarStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get()
    {
        try
        {
            var response = new
            {
                AccessDate = DateTime.Now.ToLongDateString()
            };
            return Ok(response);
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }
}
