using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Client
{
    public sealed class TypedClient : IDisposable
    {
        private readonly HttpClient _http;

        public TypedClient(HttpClient http)
        {
            _http = http;
        }

        public Task CreateNode(Coordinates coordinates)
        {
            return Post("api/graph/node", coordinates);
        }
        public Task<Graph> GetGraph()
        {
            return Get<Graph>("api/graph");
        }
        private async Task<T> Get<T>(string uri)
        {
            var result = await _http.GetAsync(uri);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(response);
        }

        private async Task Post<T>(string url, T body)
        {
            var result = await _http.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(body),
                    Encoding.UTF8, "application/json"));
            result.EnsureSuccessStatusCode();
        }

        public void Dispose() => _http.Dispose();

    }
}