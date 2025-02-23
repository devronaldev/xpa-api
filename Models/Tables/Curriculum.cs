using System.ComponentModel.DataAnnotations;

namespace xpa_api.Models.Tables;

public class Curriculum : ISoftAuditable
{
    public int CurriculumId { get; set; }
    public string Name { get; set; }
    public IEnumerable<CurriculumCourses>? CurriculumCourses { get; set; }
    
    //ISoftAuditable
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string LastUpdatedBy { get; set; }
    public bool IsActive { get; set; }
}