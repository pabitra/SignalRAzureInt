using System.Collections.Generic;

namespace SchoolAPI.Models
{
    public partial class Instructor
    {
        public Instructor()
        {

            this.Addresses = new List<Address>();
        }

        public int InstructorId { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public System.DateTime HireDate { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string EmailId { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual OfficeAssignment OfficeAssignment { get; set; }
    }
}
