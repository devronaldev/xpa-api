using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xpa_api.Models.Tables;

namespace xpa_api.Configurations;

public class CurriculumCourseConfiguration : IEntityTypeConfiguration<CurriculumCourses>
{
    public void Configure(EntityTypeBuilder<CurriculumCourses> builder)
    {
        builder.ToTable("CurriculumCourses");
        builder.HasKey(x => new { x.CurriculumId, x.CourseId });
        builder.HasOne<Curriculum>(x => x.Curriculum)
            .WithMany(x => x.CurriculumCourses)
            .HasForeignKey(x => x.CurriculumId);
        builder.HasOne<Course>(x => x.Course)
            .WithMany(x => x.Curriculums)
            .HasForeignKey(x => x.CourseId);
    }
}