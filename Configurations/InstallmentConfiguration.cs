using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xpa_api.Models.Tables;

namespace xpa_api.Configurations;

public class InstallmentConfiguration : IEntityTypeConfiguration<Installment>
{
    public void Configure(EntityTypeBuilder<Installment> builder)
    {
        builder.ToTable("Installments");
        builder.HasKey(x => x.ContractId);
        builder.HasOne<Contract>(x => x.Contract)
            .WithMany()
            .HasForeignKey(x => x.ContractId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(x => x.Amount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        builder.Property(x => x.AmountPaid)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        builder.Property(x => x.Fee)
            .HasColumnType("decimal(5,2)");
    }
}