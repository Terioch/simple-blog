using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Entities;
using SimpleBlog.Services;

namespace SimpleBlog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }        

        [HttpGet] 
        public IActionResult GetPosts([FromQuery] string? searchTerm = null)
        {
            var posts = _postService.GetPosts(searchTerm);            
            return Ok(posts);
        }        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost([FromRoute] int id)
        {
            var post = await _postService.GetPost(id);           
            return Ok(post);
        }

        [HttpPost("create")]
        public async Task<IActionResult> NewPost([FromBody] Post model)
        {
            var post = await _postService.NewPost(model);
            return Ok(post);
        }
    }
}
