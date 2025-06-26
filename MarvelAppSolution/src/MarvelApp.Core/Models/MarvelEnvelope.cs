namespace MarvelApp.Core.Models;

public class MarvelEnvelope<T>
{
    public MarvelDataContainer<T> Data { get; set; } = default!;
}

public class MarvelDataContainer<T>
{
    public int Offset { get; set; }
    public int Limit { get; set; }
    public int Total { get; set; }
    public int Count { get; set; }
    public List<T> Results { get; set; } = new();
}
