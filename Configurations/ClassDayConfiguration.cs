using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xpa_api.Models.Tables;

namespace xpa_api.Configurations;

public class ClassDayConfiguration : IEntityTypeConfiguration<ClassDay>
{
    public void Configure(EntityTypeBuilder<ClassDay> builder)
    {
        builder.ToTable("ClassDay");
        builder.HasKey(x => x.ClassDayId);
        
        builder.HasOne<Class>(x => x.Class)
            .WithMany()
            .HasForeignKey(x => x.ClassId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne<Curriculum>(x => x.Curriculum)
            .WithMany()
            .HasForeignKey(x => x.CurriculumId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne<Room>(x => x.Room)
            .WithMany()
            .HasForeignKey(x => x.RoomId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}