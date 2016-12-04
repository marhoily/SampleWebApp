using Microsoft.EntityFrameworkCore;

namespace Sample.Web.Controllers
{
    internal class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

      

        public DbSet<Blog> Blogs { get; set; }
    }
}