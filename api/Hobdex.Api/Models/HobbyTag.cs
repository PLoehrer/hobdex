namespace Hobdex.Api.Models;

public class HobbyTag
{
    public int HobbyId { get; set; }
    public int TagId { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }

    public Hobby Hobby { get; set; } = null!;
    public Tag Tag { get; set; } = null!;
}