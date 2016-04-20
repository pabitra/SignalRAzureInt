using System.Data.Entity.ModelConfiguration;

namespace SchoolAPI.Models.Mapping
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            // Primary Key
            this.HasKey(t => t.StudentId);

            // Properties
            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.FirstMidName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.EmailId)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Students");
            this.Property(t => t.StudentId).HasColumnName("StudentId");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.FirstMidName).HasColumnName("FirstMidName");
            this.Property(t => t.EnrollmentDate).HasColumnName("EnrollmentDate");
            this.Property(t => t.DateOfBirth).HasColumnName("DateOfBirth");
            this.Property(t => t.EmailId).HasColumnName("EmailId");
        }
    }
}
