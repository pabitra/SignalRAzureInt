using System.Collections.Generic;

namespace SchoolAPI.Models
{
    public partial class Student
    {
        public Student()
        {
            this.Enrollments = new List<Enrollment>();
            this.Enrollments1 = new List<Enrollment>();
            this.Addresses = new List<Address>();
            this.Addresses1 = new List<Address>();
        }

        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public System.DateTime EnrollmentDate { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string EmailId { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Enrollment> Enrollments1 { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Address> Addresses1 { get; set; }
    }
}
