using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Web.Tests
{
    public sealed class SampleControllerTest 
    {
        private readonly SelfhostedServerPageObject _server = new SelfhostedServerPageObject();
        [Fact]
        public async Task Should_Return_EntityTypes()
        {
            var response = await _server.Query("api/Sample");
            response.Should().Be("[{\"Id\":1,\"Url\":\"bluh\"}]");
        }
    }
}
