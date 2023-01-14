using SimpleBlog.Contexts;
using SimpleBlog.Models;

namespace SimpleBlog.Repositories
{
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
