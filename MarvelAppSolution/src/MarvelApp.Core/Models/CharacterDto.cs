namespace MarvelApp.Core.Models;

public class CharacterDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ThumbnailDto Thumbnail { get; set; } = default!;
}

public class ThumbnailDto
{
    public string Path { get; set; } = default!;
    public string Extension { get; set; } = default!;
}
