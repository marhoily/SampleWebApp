using System.Threading.Tasks;
using Autofac;
using Sample.Web;
using Microsoft.Owin.Testing;
using Newtonsoft.Json.Linq;
using Serilog;

namespace Web.Tests
{
    public abstract class ControllerTestBase
    {
        private readonly Startup _startup;

        protected ControllerTestBase()
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
        protected async Task<JToken> Query(string uri)
        {
            using (var server = TestServer.Create(_startup.Configuration))
            {
                var result = await server.HttpClient.GetAsync(uri);
                result.EnsureSuccessStatusCode();
                var responseContent = await result.Content.ReadAsStringAsync();
                return JToken.Parse(responseContent);
            }
        }
    }
}