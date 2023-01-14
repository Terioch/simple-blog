using SimpleBlog.Contexts;
using SimpleBlog.models;

namespace SimpleBlog.Repositories
{
    public class PostRepository : Repository<Post>, IRepository<Post>
    {
        public PostRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
