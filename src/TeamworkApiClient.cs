using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace IdleSnitch
{
    public class TeamworkApiClient
    {
        private readonly string _apiToken;
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;

        public TeamworkApiClient(string apiToken, string baseUrl)
        {
            _apiToken = apiToken;
            _baseUrl = baseUrl.TrimEnd('/');
            _httpClient = new HttpClient();
            var authToken = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_apiToken}:xxx"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
        }

        // Returns true if a timer is currently running for the user
        public async Task<bool> IsTimerRunningAsync()
        {
            var url = $"{_baseUrl}/me/time_entries.json?filter=active";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Teamwork API error: {response.StatusCode}");
            var json = await response.Content.ReadAsStringAsync();
            var obj = JObject.Parse(json);
            // Teamwork returns an array of time-entries; if any are running, the array is non-empty
            var entries = obj["time-entries"] as JArray;
            return entries != null && entries.Count > 0;
        }
    }
}
