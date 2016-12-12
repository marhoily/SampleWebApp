using Microsoft.EntityFrameworkCore;

namespace Statistics.Web.Controllers
{
    internal class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

      

        public DbSet<Blog> Blogs { get; set; }
    }
}