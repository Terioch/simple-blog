namespace SimpleBlog.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task Upload(string path, IFormFile file)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, path);

            string completeFilePath = Path.Combine(uploadsFolder, file.FileName);

            var fileStream = new FileStream(completeFilePath, FileMode.Create);

            await file.CopyToAsync(fileStream);

            fileStream.Close();
        }
    }
}
