using System.ComponentModel.DataAnnotations;

namespace xpa_api.Models.Tables;

public class Curriculum
{
    public int CurriculumId { get; set; }
    public string Name { get; set; }
    public IEnumerable<CurriculumCourses>? CurriculumCourses { get; set; }
}