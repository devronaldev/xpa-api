namespace xpa_api.Models;

public interface IAuditable : ISoftAuditable
{
    bool IsDeleted { get; set; }
    DateTime? DeletedAt { get; set; }
    DateTime? RestoredAt { get; set; }
}