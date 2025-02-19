using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models.Tables;

public class Installment
{
    [Key]
    public int InstallmentId { get; set; }
    [ForeignKey("ContractId")]
    public int ContractId { get; set; }
    public virtual Contract Contract { get; set; }
    public DateTime DueDate { get; set; }
    public int InstallmentIndex { get; set; }
    public decimal Amount { get; set; }
    public decimal AmountPaid { get; private set; }
    public decimal Fee { get; set; }
}