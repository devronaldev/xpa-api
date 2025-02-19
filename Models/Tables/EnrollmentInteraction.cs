using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace xpa_api.Models.Tables;

[Table("EnrollmentInteraction")]
public class EnrollmentInteraction
{
    //SEARCH VALUES
    [Key]
    public int Id { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    [ForeignKey("Youth")]
    public int YouthId { get; set; }
    
    // OTHER DATA
    public DateTime Date { get; set; }
    public EInteractionType InteractionType { get; set; }
    
    // Virtual Values
    public virtual User User { get; set; }
    public virtual Youth Youth { get; set; }
}

public enum EInteractionType
{
    Search = 1,
    Project = 2,
    Schedule = 3,
    Reception = 4,
    Enrollment = 5
}