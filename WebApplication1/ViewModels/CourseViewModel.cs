using System;

namespace SchoolAPI.ViewModels
{
    public partial class CourseViewModel : IBaseViewModel
    {
        public CourseViewModel()
        {
          
        }

        public int CourseId { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public int? PersonId { get; set; }
        public string DepartmentName { get; set; }
    }
}
