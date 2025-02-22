using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models.Tables
{
    [Table("users")]
    public class User : IContacts
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public ESeniority Seniority { get; set; }

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
        public List<Employee> WorkPlaces { get; set; }
        public List<EnrollmentInteraction> Enrollments { get; set; }
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
