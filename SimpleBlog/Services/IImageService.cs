namespace SimpleBlog.Services
{
    public interface IImageService
    {
        Task Upload(string path, IFormFile file);
    }
}
