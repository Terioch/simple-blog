using SimpleBlog.Entities;

namespace SimpleBlog.Services
{
    public interface IPostService
    {
        ICollection<Post> GetPosts(string searchTerm);

        Task<Post> GetPost(int id);

        Task<Post> NewPost(Post post);
    }
}
