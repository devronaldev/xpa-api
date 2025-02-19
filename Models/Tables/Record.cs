using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace xpa_api.Models.Tables;

public class Record
{
    [Key]
    public int RecordId { get; set; }
    [ForeignKey("ContractId")]
    public int ContractId { get; set; }
    public virtual Contract Contract { get; set; }
    public EDepartment Department { get; set; }
    [ForeignKey("UserId")]
    public int UserId { get; set; }
    public virtual User User { get; set; }
    [ForeignKey("SchoolId")]
    public int SchoolId { get; set; }
    public virtual School School { get; set; }
    public string Text { get; set; }
}