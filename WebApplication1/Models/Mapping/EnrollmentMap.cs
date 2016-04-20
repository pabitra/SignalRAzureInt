using System.Data.Entity.ModelConfiguration;

namespace SchoolAPI.Models.Mapping
{
    public class EnrollmentMap : EntityTypeConfiguration<Enrollment>
    {
        public EnrollmentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Enrollments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EnrollmentId).HasColumnName("EnrollmentId");
            this.Property(t => t.StudentId).HasColumnName("StudentId");
            this.Property(t => t.Grade).HasColumnName("Grade");
            this.Property(t => t.ScoredMarks).HasColumnName("ScoredMarks");
            this.Property(t => t.CourseId).HasColumnName("CourseId");

            // Relationships
            this.HasOptional(t => t.Course)
                .WithMany(t => t.Enrollments)
                .HasForeignKey(d => d.CourseId);
            this.HasOptional(t => t.Student)
                .WithMany(t => t.Enrollments)
                .HasForeignKey(d => d.EnrollmentId);
            this.HasOptional(t => t.Student1)
                .WithMany(t => t.Enrollments1)
                .HasForeignKey(d => d.StudentId);

        }
    }
}
