using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models.Tables;

[Table("Employees")]
public class Employee
{
    //SEARCH VALUES
    [ForeignKey("UserId")]
    public int UserId { get; set; }
    [ForeignKey("SchoolId")]
    public int SchoolId { get; set; }
    
    //OTHER DATA
    public EDepartment Department { get; set; }
    
    //VIRTUAL VALUES
    public virtual User User { get; set; } 
    public virtual School School { get; set; }
}

public enum EDepartment
{
    Pedagogical = 1,
    Administrative = 2,
    Salesforce = 3,
    Telemarketing = 4,
    Management = 5
}