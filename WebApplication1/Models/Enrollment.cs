using System;

namespace SchoolAPI.Models
{
    public partial class Enrollment
    {
        public int Id { get; set; }
        public int? EnrollmentId { get; set; }
        public int? StudentId { get; set; }
        public Grade? Grade { get; set; }
        public int? ScoredMarks { get; set; }
        public int? CourseId { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }

    }

    public enum Grade
    {
        A, B, C, D, F
    }
}
