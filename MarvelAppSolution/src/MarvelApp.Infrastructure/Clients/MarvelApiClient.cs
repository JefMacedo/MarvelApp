using MarvelApp.Core.Interfaces;
using MarvelApp.Core.Models;
using MarvelApp.Infrastructure.Services;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace MarvelApp.Infrastructure.Clients;

class MarvelApiClient : IMarvelApiClient
{
    private readonly HttpClient _http;
    private readonly IHashService _hash;
    private readonly MarvelApiOptions _options;

    public MarvelApiClient(HttpClient httpClient, IOptions<MarvelApiOptions> options, IHashService hashService)
    {
        _http = httpClient;
        _hash = hashService;
        _options = options.Value;
    }

    public async Task<MarvelEnvelope<CharacterDto>> GetCharacterAsync(string name)
    {
        var ts = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
        var hash = _hash.GenerateHash(ts);
        var url = $"characters?name={name}&ts={ts}&apikey={_options.PublicKey}&hash={hash}";

        using var response = await _http.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var stream = await response.Content.ReadAsStreamAsync();

        return await JsonSerializer.DeserializeAsync<MarvelEnvelope<CharacterDto>>(stream)
            ?? throw new InvalidOperationException("Resposta vazia da Marvel API.");
    }

    public async Task<MarvelEnvelope<ComicDto>> GetComicsAsync(int characterId)
    {
        var ts = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
        var hash = _hash.GenerateHash(ts);
        var url = $"characters/{characterId}/comics?ts={ts}&apikey={_options.PublicKey}&hash={hash}";

        using var response = await _http.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var stream = await response.Content.ReadAsStreamAsync();

        return await JsonSerializer.DeserializeAsync<MarvelEnvelope<ComicDto>>(stream)
            ?? throw new InvalidOperationException("Resposta vazia da Marvel API.");
    }
}
