using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xpa_api.Models.Tables;

namespace xpa_api.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Rooms");
        builder.HasKey(x => x.RoomId);
        builder.HasOne<School>(x => x.School)
            .WithMany()
            .HasForeignKey(x => x.SchoolId);
        builder.Property(x => x.Name).IsRequired();
    }
}