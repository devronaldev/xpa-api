using System.ComponentModel.DataAnnotations;

namespace xpa_api.Models.Tables;

public class Room
{
    [Key]
    public int RoomId { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public int Type { get; set; }
}