using System.Data.Entity.ModelConfiguration;

namespace SchoolAPI.Models.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            // Primary Key
            this.HasKey(t => t.AddressId);

            // Properties
            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.LaneDetails)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.Locality)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PinCode)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Addresses");
            this.Property(t => t.AddressId).HasColumnName("AddressId");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.LaneDetails).HasColumnName("LaneDetails");
            this.Property(t => t.Locality).HasColumnName("Locality");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.PinCode).HasColumnName("PinCode");

            // Relationships
            this.HasMany(t => t.Instructors)
                .WithMany(t => t.Addresses)
                .Map(m =>
                    {
                        m.ToTable("InstructorAddresses");
                        m.MapLeftKey("AddressId");
                        m.MapRightKey("InstructorId");
                    });

            this.HasMany(t => t.Students)
                .WithMany(t => t.Addresses)
                .Map(m =>
                    {
                        m.ToTable("StudentAddresses");
                        m.MapLeftKey("AddressId");
                        m.MapRightKey("StudentId");
                    });

            


        }
    }
}
