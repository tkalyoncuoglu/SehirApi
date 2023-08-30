using SehirApi.Data;
using SehirApi.Models;

namespace SehirApi.Repository
{
    public class PhotosRepository : BaseRepository<Photo>, IPhotosRepository
    {
        public PhotosRepository(DataContext context) : base(context) { }

        public List<Photo> GetPhotosByCity(int cityId)
        {
            return _dataContext.Photos.Where(x => x.CityId == cityId).ToList();
        }
    }
}
