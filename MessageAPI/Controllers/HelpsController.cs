using System.Web.Mvc;

namespace MessageAPI.Controllers
{
    public class HelpsController : Controller
    {
        // GET: Help
        public ActionResult Index()
        {
            return View();
        }
    }
}