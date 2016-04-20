using System;
using System.Collections.Generic;

namespace SchoolAPI.Models
{
    public partial class Department
    {
        public Department()
        {
            this.Courses = new List<Course>();
        
        }

        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public DateTime? StartDate { get; set; }
        public int? InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        
    }
}
