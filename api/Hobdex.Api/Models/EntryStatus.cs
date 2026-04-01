namespace Hobdex.Api.Models;

public class EntryStatus
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Entry> Entries { get; set; } = new List<Entry>();
}