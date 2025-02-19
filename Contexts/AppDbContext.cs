using Microsoft.EntityFrameworkCore;
using xpa_api.Configurations;
using xpa_api.Models.Tables;

namespace xpa_api.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AttendanceList> AttendanceLists { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassDay> ClassDays { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<CurriculumCourses> CurriculumCourses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EnrollmentInteraction> EnrollmentInteractions { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Youth> Youths { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AttendanceConfiguration());
            modelBuilder.ApplyConfiguration(new AttendanceListConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
