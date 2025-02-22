using System.ComponentModel.DataAnnotations;

namespace xpa_api.Models.Tables;

public class School : IContacts
{
    public int SchoolId { get; set; }
    public string Name { get; set; }
    
    //IContact Implement
    public string Number1 { get; set; }
    public string Number2 { get; set; } = string.Empty;
    public string Number3 { get; set; } = string.Empty;
    public string Email { get; set; }
    public string HouseNumber { get; set; }
    public string Address { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    
    //Relations
    public List<Employee> Employees { get; set; }
    public List<Contract> Contracts { get; set; }
}