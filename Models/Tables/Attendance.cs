using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models.Tables;

public class Attendance
{
    public int ContractId { get; set; }
    public Contract Contract { get; set; }
    public int AttendanceListId { get; set; }
    public AttendanceList AttendanceList { get; set; }
    public EAttendanceType AttendanceType { get; set; }
    public DateTime? StartTime { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}

public enum EAttendanceType
{
    Online = 1,
    Presencial = 2,
    Virtual = 3
}