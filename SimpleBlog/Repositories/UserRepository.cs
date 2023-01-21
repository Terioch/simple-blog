using SimpleBlog.Contexts;
using SimpleBlog.Entities;

namespace SimpleBlog.Repositories
{
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
