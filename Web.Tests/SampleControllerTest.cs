using System;
using System.Threading.Tasks;
using Sample.Web.Controllers;
using Xunit;

namespace Web.Tests
{
    public sealed class SampleControllerTest : IDisposable
    {
        private readonly SelfhostedServerPageObject _server = new SelfhostedServerPageObject();
        [Fact]
        public async Task Should_Return_EntityTypes()
        {
            await _server.Post("api/Sample/1", new SampleArg { Name = "bluh"})
                .ShouldBeOk();
            await _server.Get("api/Sample")
                .ShouldBe(new[] { new { Id = 1, Url = "bluh" } });
        }

        public void Dispose() => _server.Dispose();
    }
}
