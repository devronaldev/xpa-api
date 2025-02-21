using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models.Tables;

public class CurriculumCourses
{
    public int CurriculumId { get; set; }
    public Curriculum Curriculum { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
}