namespace MarvelApp.Core.Models;

public class ComicDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ThumbnailDto Thumbnail { get; set; } = default!;
}
