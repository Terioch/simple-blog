using SimpleBlog.Entities;

namespace SimpleBlog.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Post> Posts { get; }

        IRepository<User> Users { get; }

        Task<int> Complete();
    }
}
