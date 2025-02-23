using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models.Tables;

public class ClassDay : ISoftAuditable
{
    public int ClassDayId { get; set; }
    public int ClassId { get; set; }
    public int CurriculumId { get; set; }
    public int RoomId { get; set; }
    
    public virtual Class? Class { get; set; }
    public virtual Curriculum? Curriculum { get; set; }
    public virtual Room? Room { get; set; }
    
    public int WeekDay { get; set; }
    public int StartHour { get; set; }
    public int StartMinute { get; set; }
    public int EndHour { get; set; }
    public int EndMinute { get; set; }
    
    //ISoftAuditable
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string LastUpdatedBy { get; set; }
    public bool IsActive { get; set; }
}