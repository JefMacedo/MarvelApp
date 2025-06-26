using MarvelApp.Core.Models;

namespace MarvelApp.Core.Interfaces;

public interface IMarvelApiClient
{
    Task<MarvelEnvelope<CharacterDto>> GetCharacterAsync(string name);
    Task<MarvelEnvelope<ComicDto>> GetComicsAsync(int characterId);
}
