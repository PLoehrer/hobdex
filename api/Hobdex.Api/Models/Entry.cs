namespace Hobdex.Api.Models;

public class Entry : AuditEntity
{
    public int Id { get; set; }
    public int HobbyId { get; set; }
    public int EntryStatusId { get; set; }
    public int? EntryTypeId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public double DisplayOrder { get; set; }
    public bool IsDeleted { get; set; }

    public Hobby Hobby { get; set; } = null!;
    public EntryStatus EntryStatus { get; set; } = null!;
    public EntryType? EntryType { get; set; }
    public ICollection<EntryLog> EntryLogs { get; set; } = [];
    public ICollection<EntryTag> EntryTags { get; set; } = [];
}