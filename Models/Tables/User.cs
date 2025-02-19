using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models.Tables
{
    [Table("users")]
    public class User : IContacts
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string CPF { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public ESeniority Seniority { get; set; }

        //IContact Implement
        public string Number1 { get; set; }
        public string Number2 { get; set; } = string.Empty;
        public string Number3 { get; set; } = string.Empty;
        public string Email { get; set; }
    }
    
    public enum ESeniority
    {
        Student = 0,
        Intern = 1,
        Assistant = 2,
        Leader = 3,
        Manager = 4,
        Director = 5,
        Executive = 6
    }
}
