using SehirApi.Models;

namespace SehirApi.Repository
{
    public interface IPhotosRepository : IBaseRepository<Photo>
    {
        List<Photo> GetPhotosByCity(int cityId);
    }
}
