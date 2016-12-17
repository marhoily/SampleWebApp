using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;

namespace Web.Tests
{
    [Binding]
    public sealed class SampleControllerSteps
    {
        private readonly SelfhostedServerPageObject _server = new SelfhostedServerPageObject();
        private Task<string> _response;

        [Given("POST request to (.*)")]
        public void HttpPost(string uri, string args)
        {
            _response = _server.Get(uri);
        }
        [When("GET request to (.*)")]
        public void HttpGet(string uri)
        {
            _response = _server.Get(uri);
        }

        [Then("the response should be")]
        public void ResponseShouldBe(string expected)
        {
            var a = JToken.Parse(_response.Result).ToString(Formatting.Indented);
            var e = JToken.Parse(expected).ToString(Formatting.Indented);
            a.Should().Be(e);
        }
    }
}
