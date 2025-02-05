using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models
{
    public abstract class Contacts
    {
        public string Number1 { get; set; } = string.Empty;
        public string Number2 { get; set; } = string.Empty;
        public string Number3 { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
    }
}
