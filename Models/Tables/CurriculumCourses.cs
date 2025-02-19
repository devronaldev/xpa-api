using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models.Tables;

public class CurriculumCourses
{
    [ForeignKey("CurriculumId")]
    public int CurriculumId { get; set; }
    [ForeignKey("CourseId")]
    public int CourseId { get; set; }
}