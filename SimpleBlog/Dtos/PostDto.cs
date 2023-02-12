namespace SimpleBlog.Dtos
{
    public class PostDto
    {
        public int UserId { get; set; }

        public string Title { get; set; }

        public string Excerpt { get; set; }

        public string Content { get; set; }
        
        public IFormFile Image { get; set; }
    }
}
