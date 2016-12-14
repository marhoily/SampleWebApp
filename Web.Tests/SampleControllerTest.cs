using System.Threading.Tasks;
using Xunit;

namespace Web.Tests
{
    public sealed class SampleControllerTest
    {
        private readonly SelfhostedServerPageObject _server = new SelfhostedServerPageObject();
        [Fact]
        public async Task Should_Return_EntityTypes()
        {
            await _server.Query("api/Sample")
                .ShouldBe(new[] { new { Id = 1, Url = "bluh" } });
        }
    }
}
