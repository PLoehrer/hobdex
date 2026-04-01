namespace Hobdex.Api.Models;

public class Tag : AuditEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Color { get; set; }

    public User User { get; set; } = null!;
    public ICollection<EntryTag> EntryTags { get; set; } = [];
    public ICollection<HobbyTag> HobbyTags { get; set; } = [];
}