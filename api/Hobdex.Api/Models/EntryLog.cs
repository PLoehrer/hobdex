namespace Hobdex.Api.Models;

public class EntryLog
{
    public int Id { get; set; }
    public int EntryId { get; set; }
    public string Content { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }

    public Entry Entry { get; set; } = null!;
}