using System.Collections.Generic;

namespace SchoolAPI.ViewModels
{
    public partial class Address
    {
        public Address()
        {
            this.Instructors = new List<Instructor>();
            this.Students = new List<Student>();
            this.Students1 = new List<Student>();
        }

        public int AddressId { get; set; }
        public string City { get; set; }
        public string LaneDetails { get; set; }
        public string Locality { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Student> Students1 { get; set; }
    }
}
