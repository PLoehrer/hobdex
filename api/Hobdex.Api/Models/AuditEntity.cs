namespace Hobdex.Api.Models;

public class AuditEntity
{
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
}