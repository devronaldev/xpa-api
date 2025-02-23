using System.ComponentModel.DataAnnotations;

namespace xpa_api.Models.Tables;

public class Class : ISoftAuditable
{
    public int ClassId { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public int SchoolId { get; set; }
    public School School { get; set; }
    
    //ISoftAuditable
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string LastUpdatedBy { get; set; }
    public bool IsActive { get; set; }
}