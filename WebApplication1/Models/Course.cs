using System;
using System.Collections.Generic;

namespace SchoolAPI.Models
{
    public partial class Course
    {
        public Course()
        {
            this.Enrollments = new List<Enrollment>();
        }

        public int CourseId { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual Department Department { get; set; }
        
    }
}
