using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xpa_api.Models.Tables;

namespace xpa_api.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(x => x.UserId);
        builder.Property(x => x.UserId).ValueGeneratedOnAdd();
        builder.HasMany<Employee>(x => x.WorkPlaces)
            .WithOne(x => x.User)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany<EnrollmentInteraction>(x => x.Enrollments)
            .WithOne(x => x.User)
            .OnDelete(DeleteBehavior.Cascade);
    }
}