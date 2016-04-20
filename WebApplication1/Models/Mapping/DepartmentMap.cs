using System.Data.Entity.ModelConfiguration;

namespace SchoolAPI.Models.Mapping
{
    public class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.DepartmentName)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Departments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.DepartmentName).HasColumnName("DepartmentName");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.DepartmentHeadId).HasColumnName("DepartmentHeadId");
        }
    }
}
