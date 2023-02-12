using SimpleBlog.Dtos;
using SimpleBlog.Entities;
using SimpleBlog.Models;
using SimpleBlog.Repositories;

namespace SimpleBlog.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;

        public PostService(IUnitOfWork unitOfWork, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
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

        public async Task<ActionWrapper<PostDto>> NewPost(PostDto postDto)
        {          
            var post = new Post 
            { 
                UserId = postDto.UserId,
                Title = postDto.Title,
                Excerpt = postDto.Excerpt,
                Content = postDto.Content,
                Image = postDto.Image.FileName,
                Created = DateTime.UtcNow,
            };

            await _imageService.Upload("Images/Posts", postDto.Image);

            await _unitOfWork.Posts.Add(post);

            await _unitOfWork.Complete();

            return new ActionWrapper<PostDto>().Success("New Post added succesfully", postDto);
        }
    }
}
