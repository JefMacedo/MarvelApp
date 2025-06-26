using MarvelApp.Core.Interfaces;
using MarvelApp.Core.Models;
using Microsoft.Extensions.Caching.Memory;

namespace MarvelApp.Infrastructure.Clients;

public class CachingMarvelApiClient : IMarvelApiClient
{
    private readonly IMarvelApiClient _inner;
    private readonly IMemoryCache _cache;

    public CachingMarvelApiClient(IMarvelApiClient inner, IMemoryCache cache)
    {
        _inner = inner;
        _cache = cache;
    }
    public async Task<MarvelEnvelope<CharacterDto>> GetCharacterAsync(string name)
    {
        var cacheKey = $"character_{name.ToLower()}";

        if (!_cache.TryGetValue(cacheKey, out MarvelEnvelope<CharacterDto>? result))
        {
            result = await _inner.GetCharacterAsync(name);
            _cache.Set(cacheKey, result, TimeSpan.FromMinutes(30));
        }

        return result!;
    }

    public async Task<MarvelEnvelope<ComicDto>> GetComicsAsync(string characterId)
    {
        var cacheKey = $"comics_{characterId}";

        if (!_cache.TryGetValue(cacheKey, out MarvelEnvelope<ComicDto>? result))
        {
            result = await _inner.GetComicsAsync(characterId);
            _cache.Set(cacheKey, result, TimeSpan.FromMinutes(30));
        }

        return result!;
    }
}
