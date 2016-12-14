using System.Threading.Tasks;
using Autofac;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Owin.Testing;
using Sample.Web;
using Sample.Web.Controllers;
using Serilog;

namespace Web.Tests
{
    public sealed class SelfhostedServerPageObject
    {
        private readonly Startup _startup;

        public SelfhostedServerPageObject()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacWeb>();
            builder.RegisterInstance<ILogger>(
                new LoggerConfiguration()
                    .WriteTo.LiterateConsole()
                    .CreateLogger());
            builder.RegisterInstance(GetOptions()).SingleInstance();

        var scope = builder.Build();
            _startup = new Startup(scope);
        }
        private static DbContextOptions<MyContext> GetOptions()
        {
            var inMemorySqlite = new SqliteConnection("Data Source=:memory:");
            inMemorySqlite.Open();
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlite(inMemorySqlite);
            var options = optionsBuilder.Options;
            using (var ctx = new MyContext(options))
                ctx.Database.EnsureCreated();
            return options;
        }
        public async Task<string> Query(string uri)
        {
            using (var server = TestServer.Create(_startup.Configuration))
            {
                var result = await server.HttpClient.GetAsync(uri);
                result.EnsureSuccessStatusCode();
                return await result.Content.ReadAsStringAsync();
            }
        }
    }
}