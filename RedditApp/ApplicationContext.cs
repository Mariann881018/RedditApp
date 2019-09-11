using Microsoft.EntityFrameworkCore;
using RedditApp.Models;

namespace RedditApp
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }


        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
    }
}
