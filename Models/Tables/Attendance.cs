using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models.Tables;

public class Attendance : ISoftAuditable
{
    public int ContractId { get; set; }
    public Contract Contract { get; set; }
    public int AttendanceListId { get; set; }
    public AttendanceList AttendanceList { get; set; }
    public EAttendanceType AttendanceType { get; set; }
    public DateTime? PresentAt { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    
    //ISoftAuditable
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string LastUpdatedBy { get; set; }
    public bool IsActive { get; set; }
}

public enum EAttendanceType
{
    Absent = 0,
    Online = 1,
    Presencial = 2,
    Virtual = 3
}