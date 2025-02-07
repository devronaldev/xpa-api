using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models
{
    public interface IContacts
    {
        public string Number1 { get; set; }
        public string Number2 { get; set; } 
        public string Number3 { get; set; } 
        public string Email { get; set; } 
    }
}
