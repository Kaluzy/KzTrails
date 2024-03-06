using KzTrail.Models.Domain;

namespace KzTrail.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
