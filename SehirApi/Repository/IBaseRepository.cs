using SehirApi.Models;
using System.Linq.Expressions;

namespace SehirApi.Repository
{
    public interface IBaseRepository<T> where T : class, IEntity
    {
        void Add(T entity);
        void Delete(T entity);
        bool SaveAll();
        List<T> GetAll();
        List<T> Get(Expression<Func<T, bool>> predicate);
        T? GetById(int id, string[]? includes = null);

    }
}
