using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models.Tables;

public sealed class AttendanceList{
    public int AttendanceListId { get; set; }
    public int ClassDayId { get; set; }
    public ClassDay ClassDay{ get; set; }
    public DateTime Date { get; set; }
    public int Type { get; set; }
}