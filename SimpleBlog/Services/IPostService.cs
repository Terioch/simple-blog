using SimpleBlog.Dtos;
using SimpleBlog.Entities;
using SimpleBlog.Models;

namespace SimpleBlog.Services
{
    public interface IPostService
    {
        ICollection<Post> GetPosts(string searchTerm);

        Task<Post> GetPost(int id);

        Task<ActionWrapper<PostDto>> NewPost(PostDto postDto);
    }
}
