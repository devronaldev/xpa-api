namespace xpa_api.Models;

public interface ISoftAuditable
{
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
    string CreatedBy { get; set; }
    string LastUpdatedBy { get; set; }
    bool IsActive { get; set; }
}