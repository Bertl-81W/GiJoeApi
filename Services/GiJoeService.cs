namespace GiJoeApi.Services;

using System.Net.Http;
using System.Text.Json;
using GiJoeApi.Models;

public class GiJoeService
{
    private readonly HttpClient _httpClient;

    public GiJoeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Joe>> GetExternalJoesAsync()
    {
        var response = await _httpClient.GetAsync("https://gijoe-api.onrender.com/api/characters");


        if (!response.IsSuccessStatusCode)
            return new List<Joe>();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<Joe>>(json)
               ?? new List<Joe>();
    }
}
