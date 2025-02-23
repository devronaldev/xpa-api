using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models.Tables;

[Table("Youth")]
public class Youth : IContacts, IAuditable
{
    public int YouthId { get; set; }
    public string Name { get; set; }
    public string SchoolName { get; set; }
    public DateTime Birthday { get; set; }
    
    public Contract? Contract { get; set; }
    public int ContractId { get; set; }
    
    //IContact Implement
    public string Number1 { get; set; }
    public string Number2 { get; set; } = string.Empty;
    public string Number3 { get; set; } = string.Empty;
    public string Email { get; set; }
    public string Number { get; set; }
    public string City { get; set; }
    public string Neighborhood { get; set; }
    public string Address { get; set; }
    public string HouseNumber { get; set; }
    public string ZipCode { get; set; }
    
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