using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models
{
    public interface IContacts
    {
        string Number1 { get; set; }
        string Number2 { get; set; } 
        string Number3 { get; set; } 
        string Email { get; set; } 
        string HouseNumber { get; set; }
        string Address { get; set; }
        string Neighborhood { get; set; }
        string City { get; set; }
        string ZipCode { get; set; }
        
    }
}
