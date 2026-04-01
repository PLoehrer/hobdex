namespace Hobdex.Api.Models;

public class Hobby : AuditEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string? IconName { get; set; }
    public string? ImageUrl { get; set; }
    public double DisplayOrder { get; set; }
    public bool IsDeleted { get; set; }
    
    public User User { get; set; } = null!;
    public ICollection<Entry> Entries { get; set; } = new List<Entry>();
    public ICollection<HobbyTag> HobbyTags { get; set; } = new List<HobbyTag>();
}