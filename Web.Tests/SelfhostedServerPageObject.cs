using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Logic.Database;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;
using Sample.Web;
using Serilog;

namespace Web.Tests
{
    public sealed class SelfhostedServerPageObject : IDisposable
    {
        private readonly TestServer _server;

        public SelfhostedServerPageObject()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacWeb>();
            builder.RegisterInstance<ILogger>(
                new LoggerConfiguration()
                    .WriteTo.LiterateConsole()
                    .CreateLogger());
            builder.RegisterInstance(GetOptions()).SingleInstance();
            var startup = new Startup(builder.Build());
            _server = TestServer.Create(startup.Configuration);
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
        public async Task<string> Get(string uri)
        {
            var result = await _server.HttpClient.GetAsync(uri);
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadAsStringAsync();
        }

        public async Task Post<T>(string url, T body)
        {
            var result = await _server.HttpClient.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(body),
                    Encoding.UTF8, "application/json"));
            result.EnsureSuccessStatusCode();
        }

        public void Dispose() => _server.Dispose();
    }
}