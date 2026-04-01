namespace Hobdex.Api.Models;

public class EntryTag
{
    public int EntryId { get; set; }
    public int TagId { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }

    public Entry Entry { get; set; } = null!;
    public Tag Tag { get; set; } = null!;
}