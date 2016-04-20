using System.Collections.Generic;

namespace SchoolAPI.ViewModels
{
    public partial class Instructor
    {
        public Instructor()
        {
           
        }

        public int InstructorId { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public System.DateTime HireDate { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string EmailId { get; set; }
       
    }
}
