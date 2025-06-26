using MarvelApp.Core.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MarvelApp.Api;

public class MarvelConsoleRunner : IHostedService
{
    private readonly IMarvelApiClient _marvelClient;
    private readonly ILogger<MarvelConsoleRunner> _logger;

    public MarvelConsoleRunner(IMarvelApiClient marvelClient, ILogger<MarvelConsoleRunner> logger)
    {
        _marvelClient = marvelClient;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            const string characterName = "Hulk";
            const string characterId = "1009351";

            _logger.LogInformation("Consultando personagem: {Character}", characterName);
            var characterResult = await _marvelClient.GetCharacterAsync(characterId);
            if (characterResult.Data == null)
            {
                _logger.LogWarning("Resposta da API sem dados para o personagem {Character}.", characterName);
                return;
            }

            var character = characterResult.Data.Results.FirstOrDefault();

            if (character is null)
            {
                _logger.LogWarning("Personagem não encontrado.");
                return;
            }

            _logger.LogInformation("Nome: {Name}", character.Name);
            _logger.LogInformation("Descrição: {Description}", character.Description);

            _logger.LogInformation("Buscando quadrinhos do personagem...");
            var comicsResult = await _marvelClient.GetComicsAsync(characterId);

            if (comicsResult.Data == null)
            {
                _logger.LogWarning("Resposta da API sem dados de quadrinhos para o personagem ID {CharacterId}.", characterId);
                return;
            }

            foreach (var comic in comicsResult.Data.Results.Take(5))
            {
                _logger.LogInformation("📖 {Title}", comic.Title);
            }

            _logger.LogInformation("Consulta finalizada com sucesso!");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro durante a execução do MarvelConsoleRunner.");
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

}
