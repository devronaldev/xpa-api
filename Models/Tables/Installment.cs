using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models.Tables;

public class Installment : IAuditable
{
    public int InstallmentId { get; set; }
    public int ContractId { get; set; }
    public Contract Contract { get; set; }
    public DateTime DueDate { get; set; }
    public int InstallmentIndex { get; set; }
    public decimal Amount { get; set; }
    public decimal AmountPaid { get; private set; }
    public decimal Fee { get; set; }
    
    //IAuditable
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string LastUpdatedBy { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? RestoredAt { get; set; }
}