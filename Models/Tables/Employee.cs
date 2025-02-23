using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models.Tables;

public class Employee : ISoftAuditable
{
    //SEARCH VALUES
    public int UserId { get; set; }
    public int SchoolId { get; set; }
    
    //OTHER DATA
    public EDepartment Department { get; set; }
    
    //VIRTUAL VALUES
    public User User { get; set; } 
    public School School { get; set; }
    
    //ISoftAuditable
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string LastUpdatedBy { get; set; }
    public bool IsActive { get; set; }
}

public enum EDepartment
{
    Pedagogical = 1,
    Administrative = 2,
    Salesforce = 3,
    Telemarketing = 4,
    Management = 5
}