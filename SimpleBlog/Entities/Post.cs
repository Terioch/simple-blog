namespace SimpleBlog.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Title { get; set; }

        public string Excerpt { get; set; }

        public string Content { get; set; }
        public string Image { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public DateTime Deleted { get; set; }
    }
}
