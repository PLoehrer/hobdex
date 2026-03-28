namespace Hobdex.Api.Models;

public class Hobby
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public string IconName { get; set; } = string.Empty;
}