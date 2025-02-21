using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xpa_api.Models.Tables;

namespace xpa_api.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");
        builder.HasOne<User>(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);
        builder.HasOne<School>(x => x.School)
            .WithMany()
            .HasForeignKey(x => x.SchoolId);
        builder.HasKey(x => new { x.UserId, x.SchoolId });
    }
}