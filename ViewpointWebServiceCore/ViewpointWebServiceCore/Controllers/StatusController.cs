using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ViewpointWebServiceCore.Controllers
{

    public class StatusController : ControllerBase
    {
        [HttpGet()]
        [Route("api/Status")]
        [Authorize]
        public IActionResult Test()
        {
            string message = "Hello World";
            return Ok(new { message });
        }
    }
}
