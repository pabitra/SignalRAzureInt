using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.ViewModels
{
    public class ApiResult<T>
    {
        public T Data { get; set; }

        public bool IsSuccess { get; set; }

        public IList<Dictionary<string, string>> ErrorList { get; set; }
    }

    public interface IBaseViewModel
    {

    }
}