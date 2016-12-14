using Microsoft.EntityFrameworkCore;

namespace Sample.Web.Controllers
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

      

        public DbSet<Blog> Blogs { get; set; }
    }
}