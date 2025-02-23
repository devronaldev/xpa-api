using System.ComponentModel.DataAnnotations;

namespace xpa_api.Models.Tables;

public class Course : ISoftAuditable
{
    public int CourseId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<CurriculumCourses>? Curriculums { get; }
    
    //ISoftAuditable
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string LastUpdatedBy { get; set; }
    public bool IsActive { get; set; }
}