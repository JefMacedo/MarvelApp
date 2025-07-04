﻿using MarvelApp.Core.Models;

namespace MarvelApp.Core.Interfaces;

public interface IMarvelApiClient
{
    Task<MarvelEnvelope<CharacterDto>> GetCharacterAsync(string characterId);
    Task<MarvelEnvelope<ComicDto>> GetComicsAsync(string characterId);
}
