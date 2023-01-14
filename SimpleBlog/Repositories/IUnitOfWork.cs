using SimpleBlog.models;
using SimpleBlog.Models;

namespace SimpleBlog.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Post> Posts { get; }

        IRepository<User> Users { get; }

        Task<int> Complete();
    }
}
