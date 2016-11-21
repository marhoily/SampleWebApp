using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Web.Tests
{
    public sealed class EntityTypesTest : ControllerTestBase
    {
        [Fact]
        public async Task Should_Return_EntityTypes()
        {
            var response = await Query("api/Sample");
            ((JArray)response).Count.Should().Be(3);
        }
    }
}
