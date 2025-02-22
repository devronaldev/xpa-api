using System.ComponentModel.DataAnnotations;

namespace xpa_api.Models.Tables;

public class Room
{
    public int RoomId { get; set; }
    public int SchoolId { get; set; }
    public School School { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public int Type { get; set; }
}