using System.ComponentModel.DataAnnotations;

namespace xpa_api.Models.Tables;

public class Curriculum
{
    [Key]
    public int CurriculumId { get; set; }
    public string Name { get; set; }
}