using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xpa_api.Models.Tables;

namespace xpa_api.Configurations;

public class ContractConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.ToTable("Contracts");
        builder.HasKey(x => x.ContractId);
        
        builder.HasOne<Youth>(x => x.Youth)
            .WithOne(x => x.Contract)
            .HasForeignKey<Contract>(x => x.YouthId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne<School>(x => x.School)
            .WithMany()
            .HasForeignKey(x => x.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne<Class>(x => x.Class)
            .WithMany()
            .HasForeignKey(x => x.ClassId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany<Record>(x => x.Records)
            .WithOne(x => x.Contract)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany<Installment>(x => x.Installments)
            .WithOne(x => x.Contract)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany<Attendance>(x => x.Attendances)
            .WithOne(x => x.Contract)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(x => x.CTR).ValueGeneratedNever();
    }
}