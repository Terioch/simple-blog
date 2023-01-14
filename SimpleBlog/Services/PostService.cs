using SimpleBlog.models;
using SimpleBlog.Repositories;

namespace SimpleBlog.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Post> GetPost(int id)
        {
            var post = await _unitOfWork.Posts.Get(id);
            return post;
        }

        public ICollection<Post> GetPosts(string? searchTerm = null)
        {
            var posts = _unitOfWork.Posts.GetAll();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                var filteredPosts = posts.Where(x =>
                    x.Title.ToLowerInvariant().Contains(searchTerm.ToLowerInvariant()));

                return filteredPosts.ToList();
            }

            return posts;
        }

        public async Task<Post> NewPost(Post post)
        {
            await _unitOfWork.Posts.Add(post);
            await _unitOfWork.Complete();
            return post;
        }
    }
}
