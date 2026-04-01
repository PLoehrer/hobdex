namespace Hobdex.Api.Models;

public class EntryType : AuditEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Color { get; set; }
    public bool IsGlobal { get; set; }

    public User User { get; set; } = null!;
    public ICollection<Entry> Entries { get; set; } = [];
}