using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Dtos;
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
        [Authorize]
        public async Task<IActionResult> NewPost([FromForm] PostDto postDto)
        {
            var result = await _postService.NewPost(postDto);
            return Ok(result);
        }
    }
}
