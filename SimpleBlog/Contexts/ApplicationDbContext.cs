using Microsoft.EntityFrameworkCore;
using SimpleBlog.models;
using SimpleBlog.Models;

namespace SimpleBlog.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
