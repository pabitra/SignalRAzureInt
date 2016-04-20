using System;

namespace SchoolAPI.ViewModels
{
    public partial class Enrollment
    {
        public int Id { get; set; }
        public Nullable<int> EnrollmentId { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<decimal> Grade { get; set; }
        public Nullable<int> ScoredMarks { get; set; }
        public Nullable<int> CourseId { get; set; }
       
    }
}
