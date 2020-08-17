using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace ViewpointWebServiceCore.Controllers
{

    public class StatusController : ControllerBase
    {
        [HttpGet()]
        [Route("api/Status")]
        [Authorize]
        [EnableCors]
        public IActionResult ValidateToken()
        {
            string message = "Validate Token";
            return Ok(new { message });
        }
    }
}
