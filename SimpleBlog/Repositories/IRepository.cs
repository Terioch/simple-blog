using System.Linq.Expressions;

namespace SimpleBlog.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        ICollection<T> GetAll(Expression<Func<T, bool>> predicate = null);

        Task<T> Get(int id);

        Task Add(T entity);

        void Delete(T entity);
    }
}
