using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace xpa_api.Models.Tables;

public class Contract : IAuditable
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
    
    //Relation Values
    public Youth Youth { get; set; }
    public School School { get; set; }
    public Class Class { get; set; }
    public List<Record> Records { get; set; }
    public List<Installment> Installments { get; set; }
    public List<Attendance> Attendances { get; set; }
    
    //PERSONAL DATA
    public string Nacionality { get; set; }
    public string Schooling { get; set; }
    public string ResponsibleName { get; set; }
    public string Relationship { get; set; }
    public string FatherName { get; set; }
    public string MotherName { get; set; }
    
    //IAuditable
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string LastUpdatedBy { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? RestoredAt { get; set; }
}