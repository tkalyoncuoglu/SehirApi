using Microsoft.EntityFrameworkCore;
using SehirApi.Models;
using SehirApi.Data;
using System.Linq.Expressions;

namespace SehirApi.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {
        protected readonly DataContext _dataContext;

        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(T entity)
        {
            _dataContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
        }

        public List<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dataContext.Set<T>().Where(predicate).ToList();
        }

        public List<T> GetAll()
        {
            return _dataContext.Set<T>().ToList();
        }

        public T? GetById(int id, string[]? includes = null)
        {
            var query = _dataContext.Set<T>().AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool SaveAll()
        {
            return _dataContext.SaveChanges() > 0;
        }
    }
}
