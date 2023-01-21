using SimpleBlog.Contexts;
using SimpleBlog.Entities;

namespace SimpleBlog.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Posts = new PostRepository(_db);
            Users = new UserRepository(_db);
        }

        public IRepository<Post> Posts { get; private set; }

        public IRepository<User> Users { get; set; }

        public async Task<int> Complete()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _db.Dispose();
        }
    }
}
