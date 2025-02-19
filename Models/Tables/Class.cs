using System.ComponentModel.DataAnnotations;

namespace xpa_api.Models.Tables;

public class Class
{
    [Key]
    public int ClassId { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
}