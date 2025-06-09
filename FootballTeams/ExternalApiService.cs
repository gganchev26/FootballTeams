using System.Net.Http;
using System.Text.Json;
using FootballTeams.Models.DTO;

public class ExternalApiService
{
    private readonly HttpClient _httpClient;

    public ExternalApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Players>> GetExternalPlayersAsync()
    {
        var response = await _httpClient.GetAsync("https://myexternalapi.com/api/players");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Players>>(content) ?? new();
    }
}