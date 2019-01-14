using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Route("identity")]
[Authorize]
public class IdentityController : ControllerBase
{   
    
    [Authorize(Roles = "admin")]
    [HttpGet]
    public IActionResult Get()
    {   
        return new JsonResult(from c in HttpContext.User.Claims select new { c.Type, c.Value });
    }

    [Authorize(Roles = "admin")]
    [Route("{id}")]
    [HttpGet]
    public string Get(int id)
    {
        return id.ToString();
    }

}