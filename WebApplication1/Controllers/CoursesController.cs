using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolAPI.Core;
using SchoolAPI.ViewModels;

namespace SchoolAPI.Controllers
{
    public class CoursesController : BaseController<CourseViewModel>
    {
        // GET: api/Course
        public ApiResult<List<CourseViewModel>> Get()
        {
            
        }

        // GET: api/Course/5
        public ApiResult<CourseViewModel> Get(int id)
        {
            var apiresult = new ApiResult<CourseViewModel>() {ErrorList = new List<Dictionary<string, string>>()};
            try
            {
                var result = DbContext.Courses.AsNoTracking().FirstOrDefault(c => c.CourseId == id);

                if (result != null)
                    apiresult.Data = new CourseViewModel()
                    {
                        CourseId = result.CourseId,
                        Credits = result.Credits,
                        DepartmentId = result.DepartmentId,
                        DepartmentName=result.Department.DepartmentName,
                        PersonId = result.PersonId,
                        
                    };
            }
            catch (Exception)
            {
                
                throw;
            }


            return apiresult;
        }

        // POST: api/Course
        public ApiResult<string> Post([FromBody]string value)
        {
        }

       
    }
}
