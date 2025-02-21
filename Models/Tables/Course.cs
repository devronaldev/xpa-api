using System.ComponentModel.DataAnnotations;

namespace xpa_api.Models.Tables;

public class Course
{
    public int CourseId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<CurriculumCourses>? Curriculums { get; set; }
}