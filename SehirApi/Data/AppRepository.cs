using Microsoft.EntityFrameworkCore;
using SehirRehberi.API.Data;
using SehirRehberi.API.Models;

namespace SehirApi.Data
{
    public class AppRepository : IAppRepository
    {
        private readonly DataContext _dataContext;

        public AppRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _dataContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _dataContext.Remove(entity);
        }

        public List<City> GetCities()
        {
            var cities = _dataContext.Cities.Include(x=>x.Photos).ToList();
            return cities;
        }

        public City GetCityById(int cityId)
        {
            var city = _dataContext.Cities.Include(x => x.Photos).FirstOrDefault(x=>x.Id==cityId);
            return city;
        }

        public Photo GetPhoto(int id)
        {
            var photo=_dataContext.Photos.FirstOrDefault(x=>x.Id==id);
            return photo;
        }

        public List<Photo> GetPhotosByCity(int cityId)
        {
            var photos=_dataContext.Photos.Where(x=>x.Id== cityId).ToList();
            return photos;
        }

        public bool SaveAll()
        {
            return _dataContext.SaveChanges() > 0;
        }
    }
}
