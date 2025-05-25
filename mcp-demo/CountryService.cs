using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace mcp_demo
{
    /// <summary>
    /// 
    /// </summary>
    public class CountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            var response = await _httpClient.GetAsync("https://restcountries.com/v3.1/all");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            };
            return JsonSerializer.Deserialize<List<Country>>(json, options);
        }

        public async Task<Country> GetCountryByNameAsync(string name)
        {
            var response = await _httpClient.GetAsync($"https://restcountries.com/v3.1/name/{name}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            };
            return JsonSerializer.Deserialize<List<Country>>(json, options).FirstOrDefault();
        }
        
        public async Task<Country> GetCountryByCodeAsync(string code)
        {
            var response = await _httpClient.GetAsync($"https://restcountries.com/v3.1/alpha/{code}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            };
            return JsonSerializer.Deserialize<List<Country>>(json, options).FirstOrDefault();
        }

        public async Task<List<Country>> GetTopAfricanCountriesAsync()
        {
            var allCountries = await GetAllCountriesAsync();
            return allCountries
                .Where(c => c.Region?.Equals("Africa", StringComparison.OrdinalIgnoreCase) == true)
                .OrderBy(c => c.Name?.Common)
                .Take(10)
                .ToList();
        }
    }
}