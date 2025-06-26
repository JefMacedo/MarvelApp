namespace MarvelApp.Infrastructure.Services;

public class MarvelApiOptions
{
    public string PublicKey { get; set; } = default!;
    public string PrivateKey { get; set; } = default!;
    public string BaseUrl { get; set; } = default!;
}
