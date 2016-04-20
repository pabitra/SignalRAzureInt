using System.Collections.Generic;

namespace SchoolAPI.ViewModels
{
    public partial class Student
    {
        public Student()
        {
       
        }

        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public System.DateTime EnrollmentDate { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string EmailId { get; set; }

    }
}
