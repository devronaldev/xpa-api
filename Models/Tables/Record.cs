using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace xpa_api.Models.Tables;

public class Record : ISoftAuditable
{
    public int RecordId { get; set; }
    public int ContractId { get; set; }
    public Contract Contract { get; set; }
    public EDepartment Department { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int SchoolId { get; set; }
    public School School { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }
    
    //ISoftAuditable
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string LastUpdatedBy { get; set; }
    public bool IsActive { get; set; }
}