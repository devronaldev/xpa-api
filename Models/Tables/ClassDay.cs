using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models.Tables;

public class ClassDay
{
    [Key]
    public int ClassDayId { get; set; }
    [ForeignKey("ClassId")]
    public int ClassId { get; set; }
    [ForeignKey("CurriculumId")]
    public int CurriculumId { get; set; }
    [ForeignKey("RoomId")]
    public int RoomId { get; set; }
    
    public virtual Class? Class { get; set; }
    public virtual Curriculum? Curriculum { get; set; }
    public virtual Room? Room { get; set; }
    
    public int WeekDay { get; set; }
    public int Hour { get; set; }
    public int Minute { get; set; }
}