using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xpa_api.Models.Tables;

namespace xpa_api.Configurations;

public class SchoolConfiguration : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> builder)
    {
        builder.ToTable("Schools");
        builder.HasKey(x => x.SchoolId);
        builder.HasMany<Employee>(x => x.Employees)
            .WithOne(x => x.School)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany<Contract>(x => x.Contracts)
            .WithOne(x => x.School)
            .OnDelete(DeleteBehavior.Restrict);
    }
}