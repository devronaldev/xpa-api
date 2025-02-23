using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models.Tables;

public sealed class AttendanceList : IAuditable
{
    public int AttendanceListId { get; set; }
    public int ClassDayId { get; set; }
    public ClassDay ClassDay{ get; set; }
    public DateTime Date { get; set; }
    public int Type { get; set; }
    
    //IAuditable
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string LastUpdatedBy { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? RestoredAt { get; set; }
}