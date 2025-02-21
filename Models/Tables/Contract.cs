using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xpa_api.Models.Tables;

[Table("Contract")]
public class Contract
{
    //SEARCH VALUES
    public int ContractId { get; set; }
    public int YouthId { get; set; }
    public int SchoolId { get; set; }
    public int ClassId { get; set; }
    //CPF or another document value
    public string IdentificationDocument { get; set; }
    public int? CTR { get; set; }
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