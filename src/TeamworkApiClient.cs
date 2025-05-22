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
            // Use the correct endpoint for running timers
            var url = $"{_baseUrl}/me/timers.json?runningTimersOnly=true";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Teamwork API error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
            var json = await response.Content.ReadAsStringAsync();
            var obj = JObject.Parse(json);
            // The response contains a 'timers' array; if any are present, a timer is running
            var timers = obj["timers"] as JArray;
            return timers != null && timers.Count > 0;
        }
    }
}
