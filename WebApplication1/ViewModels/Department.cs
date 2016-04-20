using System;
using System.Collections.Generic;

namespace SchoolAPI.ViewModels
{
    public partial class Department
    {
        public Department()
        {
         
        }

        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> DepartmentHeadId { get; set; }
     
    }
}
