using SimpleBlog.Contexts;
using System.Linq.Expressions;

namespace SimpleBlog.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly ApplicationDbContext _db;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _db.Set<T>().ToList();
            }

            return _db.Set<T>().Where(predicate).ToList();
        }

        public async Task<T> Get(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }        

        public async Task Add(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
        }        
    }
}
