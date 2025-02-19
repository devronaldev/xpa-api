using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xpa_api.Models.Tables;

namespace xpa_api.Configurations;

public class AttendanceListConfiguration : IEntityTypeConfiguration<AttendanceList>
{
    public void Configure(EntityTypeBuilder<AttendanceList> builder)
    {
        builder.HasKey(x => x.AttendanceListId);
        builder.HasOne<ClassDay>(x => x.ClassDay)
            .WithMany()
            .HasForeignKey(x => x.ClassDayId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}