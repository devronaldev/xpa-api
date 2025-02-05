using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models.Tables
{
    [Table("users")]
    public class User : Contacts
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }
        public int SchoolId { get; set; }
    }
}
