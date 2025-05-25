using System.ComponentModel;
using ModelContextProtocol.Server;

namespace mcp_demo
{
    [McpServerToolType]
    public static class CountryTools
    {
        [McpServerTool, Description("Get all countries.")]
        public static async Task<List<Country>> GetAllCountriesAsync(CountryService countryService)
        {
            return await countryService.GetAllCountriesAsync();
        }

        [McpServerTool, Description("Get a country by name.")]
        public static async Task<Country> GetCountryByNameAsync(CountryService countryService, string name)
        {
            return await countryService.GetCountryByNameAsync(name);
        }

        [McpServerTool, Description("Get a country by code.")]
        public static async Task<Country> GetCountryByCodeAsync(CountryService countryService, string code)
        {
            return await countryService.GetCountryByCodeAsync(code);
        }

        [McpServerTool, Description("Get top 10 African countries by alphabetic order.")]
        public static async Task<List<Country>> GetTopAfricanCountriesAsync(CountryService countryService)
        {
            return await countryService.GetTopAfricanCountriesAsync();
        }
    }
}
