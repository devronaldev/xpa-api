using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xpa_api.Models.Tables;

[Table("Contract")]
public class Contract
{
    //SEARCH VALUES
    [Key]
    public int ContractId { get; set; }
    [ForeignKey("YouthId")]
    public int YouthId { get; set; }
    [ForeignKey("SchoolId")]
    public int SchoolId { get; set; }
    [ForeignKey("ClassId")]
    public int ClassId { get; set; }
    //CPF or another document value
    public string IdentificationDocument { get; set; }
    public int Index { get; set; }
    // Change to Enum
    public int StatusValue {get; set; }
    
    //Virtual Values
    public virtual Youth Youth { get; set; }
    public virtual School School { get; set; }
    public virtual Class Class { get; set; }
    
    //PERSONAL DATA
    public string Nacionality { get; set; }
    public string Schooling { get; set; }
    public string ResponsibleName { get; set; }
    public string Relationship { get; set; }
    public string FatherName { get; set; }
    public string MotherName { get; set; }
}