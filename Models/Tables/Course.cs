using System.ComponentModel.DataAnnotations;

namespace xpa_api.Models.Tables;

public class Course
{
    [Key]
    public int CourseId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}