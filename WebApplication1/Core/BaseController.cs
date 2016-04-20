using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolAPI.Models;
using SchoolAPI.ViewModels;

namespace SchoolAPI.Core
{
    public class BaseController<TViewModel> : ApiController 
            where TViewModel : IBaseViewModel
    {
        protected readonly ContosoDBContext DbContext;

        protected BaseController()
        {
            DbContext = new ContosoDBContext();
        }

        protected IEnumerable<TViewModel> QueryModels(Func<Predicate<bool>, IEnumerable<TViewModel>> queryFunc)
        {
            
        }
    }

   
}
