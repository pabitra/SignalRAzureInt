using System.Data.Entity.ModelConfiguration;

namespace SchoolAPI.Models.Mapping
{
    public class CourseMap : EntityTypeConfiguration<Course>
    {
        public CourseMap()
        {
            // Primary Key
            this.HasKey(t => t.CourseId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Courses");
            this.Property(t => t.CourseId).HasColumnName("CourseId");
            this.Property(t => t.Credits).HasColumnName("Credits");
            this.Property(t => t.DepartmentId).HasColumnName("DepartmentId");
            

            // Relationships
            this.HasMany(t => t.Instructors)
                .WithMany(t => t.Courses)
                .Map(m =>
                    {
                        m.ToTable("CourseInstructor");
                        m.MapLeftKey("CourseId");
                        m.MapRightKey("InstructorId");
                    });

            this.HasOptional(t => t.Department)
                .WithMany(t => t.Courses)
                .HasForeignKey(d => d.DepartmentId);

            

        }
    }
}
