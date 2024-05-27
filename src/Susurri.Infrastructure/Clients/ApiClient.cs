using System.Text.Json;
using Susurri.Core.DTO;

namespace Susurri.Infrastructure.Clients;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    private const string Host = "https://localhost:7083/";

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(Host);
    }
    public async Task<JwtDto> GetProfileAsync()
    {
        var response = await _httpClient.GetAsync($"api/User/token/");

        if (response.IsSuccessStatusCode is false)
        {
            return default;
        }
        
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<JwtDto>(json, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        })!;
    }
}