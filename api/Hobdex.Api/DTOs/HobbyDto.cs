namespace Hobdex.Api.DTOs;

public class HobbyDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public string IconName { get; set; } = string.Empty;
    public int TotalProjects { get; set; }
    public int CompletedProjects { get; set; }
    public int InProgressProjects { get; set; }
}