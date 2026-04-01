namespace Hobdex.Api.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public int? CreatedBy { get; set; } = null;
    public int? UpdatedBy { get; set; } = null;

    public ICollection<Hobby> Hobbies { get; set; } = new List<Hobby>();
    public ICollection<EntryType> EntryTypes { get; set; } = new List<EntryType>();
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
}