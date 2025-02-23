using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace xpa_api.Models.Tables;

[Table("EnrollmentInteraction")]
public class EnrollmentInteraction : ISoftAuditable
{
    //SEARCH VALUES
    public int Id { get; set; }
    public int UserId { get; set; }
    public int YouthId { get; set; }
    
    // OTHER DATA
    public DateTime Date { get; set; }
    public EInteractionType InteractionType { get; set; }
    
    // Virtual Values
    public User User { get; set; }
    public Youth Youth { get; set; }
    
    //ISoftAuditable
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string LastUpdatedBy { get; set; }
    public bool IsActive { get; set; }
}

public enum EInteractionType
{
    Search = 1,
    Project = 2,
    Schedule = 3,
    Reception = 4,
    Enrollment = 5
}