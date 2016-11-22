using System.Threading.Tasks;
using Autofac;
using Microsoft.Owin.Testing;
using Sample.Web;
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
            var scope = builder.Build();
            _startup = new Startup(scope);
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