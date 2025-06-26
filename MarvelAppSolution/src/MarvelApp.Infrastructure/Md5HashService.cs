using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using MarvelApp.Core.Interfaces;
using MarvelApp.Infrastructure.Services;

namespace MarvelApp.Infrastructure;

public class Md5HashService : IHashService
{
    private readonly string _privateKey;
    private readonly string _publicKey;

    public Md5HashService(IOptions<MarvelApiOptions> options)
    {
        _privateKey = options.Value.PrivateKey;
        _publicKey = options.Value.PublicKey;
    }

    public string GenerateHash(string timestamp)
    {
        var raw = timestamp + _privateKey + _publicKey;
        var bytes = Encoding.UTF8.GetBytes(raw);

        using var md5 = MD5.Create();
        var hash = md5.ComputeHash(bytes);
        return Convert.ToHexString(hash).ToLower();
    }
}
