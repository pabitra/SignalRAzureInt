using System.Data.Entity;
using SchoolAPI.Models.Mapping;

namespace SchoolAPI.Models
{
    public partial class ContosoDBContext : DbContext
    {
        static ContosoDBContext()
        {
            Database.SetInitializer<ContosoDBContext>(null);
        }

        public ContosoDBContext()
            : base("Name=ContosoDBContext")
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new CourseMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new EnrollmentMap());
            modelBuilder.Configurations.Add(new InstructorMap());
            modelBuilder.Configurations.Add(new StudentMap());
        }
    }
}
