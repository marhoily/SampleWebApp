using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Statistics.Web.Controllers
{
    /// <summary>1 </summary>
    public class StatisticsController : ApiController
    {
        private readonly ILogger _log;

        /// <summary>2 </summary>
        public StatisticsController(ILogger log)
        {
            _log = log;
        }

        /// <summary>3 </summary>
        [Route("api/Statistics")]
        public async Task<IEnumerable<object>> Get()
        {
            _log.Information("api/Statistics");
            var inMemorySqlite = new SqliteConnection("Data Source=:memory:");
            inMemorySqlite.Open();
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlite(inMemorySqlite);
            using (var ctx = new MyContext(optionsBuilder.Options))
            {
                await ctx.Database.EnsureCreatedAsync();
                ctx.Add(new Blog { Url = "bluh" });
                await ctx.SaveChangesAsync();
            }
            using (var ctx = new MyContext(optionsBuilder.Options))
            {
                return await ctx.Blogs.ToListAsync();
            }
        }
    }
}