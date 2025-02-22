using Microsoft.EntityFrameworkCore;
using xpa_api.Configurations;
using xpa_api.Models;
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
            modelBuilder.ApplyConfiguration(new ClassConfiguration());
            modelBuilder.ApplyConfiguration(new ClassDayConfiguration());
            modelBuilder.ApplyConfiguration(new ContractConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new CurriculumConfiguration());
            modelBuilder.ApplyConfiguration(new CurriculumCourseConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EnrollmentInteractionConfiguration());
            modelBuilder.ApplyConfiguration(new InstallmentConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new RecordConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new SchoolConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new YouthConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
        
        public async Task<int> SaveChangesAsync(User user)
        {
            var entities = ChangeTracker.Entries<ISoftAuditable>();
            foreach (var entity in entities)
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.CreatedAt = DateTime.UtcNow;
                        entity.Entity.UpdatedAt = DateTime.UtcNow;
                        entity.Entity.CreatedBy = user.Name;
                        break;
                    case EntityState.Modified:
                        entity.Entity.UpdatedAt = DateTime.UtcNow;
                        entity.Entity.LastUpdatedBy = user.Name;
                        break;
                }
            }

            var softDeleteEntities = ChangeTracker.Entries<IAuditable>();
            foreach (var entity in softDeleteEntities)
            {
                if (entity.State == EntityState.Deleted)
                {
                    entity.State = EntityState.Modified;
                    entity.Entity.IsDeleted = true;
                    entity.Entity.DeletedAt = DateTime.UtcNow;
                    entity.Entity.LastUpdatedBy = user.Name;
                }
            }
            return await base.SaveChangesAsync();
        }
    }
}
