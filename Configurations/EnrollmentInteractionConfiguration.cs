using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xpa_api.Models.Tables;

namespace xpa_api.Configurations;

public class EnrollmentInteractionConfiguration : IEntityTypeConfiguration<EnrollmentInteraction>
{
    public void Configure(EntityTypeBuilder<EnrollmentInteraction> builder)
    {
        builder.ToTable("EnrollmentInteractions");
        builder.HasKey(x => x.Id);
        builder.HasOne<User>(x=> x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Youth>(x => x.Youth)
            .WithMany()
            .HasForeignKey(x => x.YouthId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}