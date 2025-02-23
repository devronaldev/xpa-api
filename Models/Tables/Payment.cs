using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpa_api.Models.Tables;

public class Payment : IAuditable
{
    public int PaymentId { get; set; }
    public int InstallmentId { get; set; }
    public Installment Installment { get; set; }
    public decimal AmountPaid { get; set; }
    public DateTime PaymentDate { get; set; }
    public EPaymentType PaymentType { get; set; }
    
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

public enum EPaymentType
{
    Cash = 1,
    CreditCard = 2,
    DebitCard = 3,
    Pix = 4,
    BankTransfer = 5,
    BarCode = 6,
    Link = 7,
}