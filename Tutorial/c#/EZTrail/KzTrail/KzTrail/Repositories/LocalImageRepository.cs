using KzTrail.Data;
using KzTrail.Models.Domain;

namespace KzTrail.Repositories
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnviornement;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly KzTrailDbContext dbContext;

        public LocalImageRepository(IWebHostEnvironment webHostEnviornement, IHttpContextAccessor contextAccessor, KzTrailDbContext dbContext
            )
        {
            this.webHostEnviornement = webHostEnviornement;
            this.contextAccessor = contextAccessor;
            this.dbContext = dbContext;
        }

        public async Task<Image> Upload(Image image)
        {
            var localFilePath = Path.Combine(webHostEnviornement.ContentRootPath, "Images",
                $"{image.FileName}{image.FileExtention}");
            //Upload image to local path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            // create a file to a path
            // https://localhost:123/images/image.jpg
            var urlFilePath = $"{contextAccessor.HttpContext.Request.Scheme}://{contextAccessor.HttpContext.Request.Host}{contextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtention}";

            image.FilePath = urlFilePath;

            //Add image to image table
            await dbContext.Images.AddAsync(image);
            await dbContext.SaveChangesAsync();

            return image;

        }
    }
}
