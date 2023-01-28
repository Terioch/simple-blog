using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostAdminController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPosts()
        {
            return Ok();
        }
    }
}
