using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xpa_api.Models.Tables;

namespace xpa_api.Configurations;

public class YouthConfiguration : IEntityTypeConfiguration<Youth>
{
    public void Configure(EntityTypeBuilder<Youth> builder)
    {
        builder.ToTable("Youths");
        builder.HasKey(x => x.YouthId);
        builder.HasOne<Contract>(x => x.Contract)
            .WithOne(x => x.Youth)
            .HasForeignKey<Contract>(x => x.YouthId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}