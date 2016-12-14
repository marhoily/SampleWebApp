using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Sample.Web.Controllers
{
    
    /// <summary>1 </summary>
    public class SampleController : ApiController
    {
        private readonly DbContextOptions<MyContext> _options;
        private readonly ILogger _log;

        /// <summary>2 </summary>
        public SampleController(DbContextOptions<MyContext> options, ILogger log)
        {
            _options = options;
            _log = log;
        }

        /// <summary>13 </summary>
        [Route("api/Sample")]
        public async Task<IEnumerable<object>> Post(int id)
        {
            _log.Information("api/Sample");
            using (var ctx = new MyContext(_options))
            {
                ctx.Add(new Blog { Url = "bluh" });
                await ctx.SaveChangesAsync();
            }
            using (var ctx = new MyContext(_options))
            {
                return await ctx.Blogs.ToListAsync();
            }
        }

        /// <summary>3 </summary>
        [Route("api/Sample")]
        public async Task<IEnumerable<object>> Get()
        {
            _log.Information("api/Sample");
            using (var ctx = new MyContext(_options))
            {
                await ctx.Database.EnsureCreatedAsync();
                ctx.Add(new Blog { Url = "bluh" });
                await ctx.SaveChangesAsync();
            }
            using (var ctx = new MyContext(_options))
            {
                return await ctx.Blogs.ToListAsync();
            }
        }
    }
}