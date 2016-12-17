using Microsoft.EntityFrameworkCore;

namespace Logic.Database
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

      

        public DbSet<Blog> Blogs { get; set; }
    }
}