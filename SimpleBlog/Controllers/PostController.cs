using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using SimpleBlog.models;

namespace SimpleBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private static List<Post> posts = new List<Post>()
        {
            new Post { Id = 1, Title = "First Post", Excerpt = "This is my first post" },
            new Post { Id = 2, Title = "Second Post", Excerpt = "This is my second post" },
            new Post { Id = 3, Title = "Third Post", Excerpt = "This is my third post" },
            new Post { Id = 4, Title = "Fourth Post", Excerpt = "This is my fourth post" },
            new Post { Id = 5, Title = "Fifth Post", Excerpt = "This is my fifth post" },
        };

        [HttpGet] 
        public IActionResult GetPosts([FromQuery] string? searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var filteredPosts = posts.Where(x => 
                    x.Title.ToLower().Contains(searchTerm.ToLower()));
                return Ok(filteredPosts);
            }

            return Ok(posts);
        }        

        [HttpGet("{id}")]
        public IActionResult GetPost([FromRoute] int id)
        {
            var post = posts.FirstOrDefault(x => x.Id == id);            
            return Ok(post);
        }
    }
}
