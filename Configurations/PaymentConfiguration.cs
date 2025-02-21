using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xpa_api.Models.Tables;

namespace xpa_api.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments");
        builder.HasKey(x => x.PaymentId);
        builder.HasOne<Installment>(x => x.Installment)
            .WithMany()
            .HasForeignKey(x => x.InstallmentId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(x => x.AmountPaid)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
    }
}