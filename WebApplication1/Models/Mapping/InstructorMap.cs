using System.Data.Entity.ModelConfiguration;

namespace SchoolAPI.Models.Mapping
{
    public class InstructorMap : EntityTypeConfiguration<Instructor>
    {
        public InstructorMap()
        {
            // Primary Key
            this.HasKey(t => t.InstructorId);

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
            this.ToTable("Instructors");
            this.Property(t => t.InstructorId).HasColumnName("InstructorId");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.FirstMidName).HasColumnName("FirstMidName");
            this.Property(t => t.HireDate).HasColumnName("HireDate");
            this.Property(t => t.DateOfBirth).HasColumnName("DateOfBirth");
            this.Property(t => t.EmailId).HasColumnName("EmailId");
        }
    }
}
