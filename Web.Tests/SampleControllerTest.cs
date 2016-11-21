using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Web.Tests
{
    public sealed class SampleControllerTest : ControllerTestBase
    {
        [Fact]
        public async Task Should_Return_EntityTypes()
        {
            var response = await Query("api/Sample");
            response.ToString().Should().Be(
                "[\r\n" +
                "  {\r\n" +
                "    \"Id\": 1,\r\n" +
                "    \"Url\": \"bluh\"\r\n" +
                "  }" +
                "\r\n]");
        }
    }
}
